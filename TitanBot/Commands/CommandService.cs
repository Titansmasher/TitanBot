﻿using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TitanBot.Commands.Responses;
using TitanBot.Storage;
using TitanBot.Dependencies;
using TitanBot.Logging;
using TitanBot.Settings;
using TitanBot.TypeReaders;
using TitanBot.Util;
using TitanBot.TextResource;

namespace TitanBot.Commands
{
    public class CommandService : ICommandService
    {
        public IReadOnlyList<CommandInfo> CommandList { get; }
        private List<CommandInfo> Command { get; } = new List<CommandInfo>();
        private IDependencyFactory DependencyFactory { get; }
        private ILogger Logger { get; }
        private ITypeReaderCollection Readers { get; }
        private IDatabase Database { get; }
        private ISettingsManager SettingsManager { get; }
        private BotClient Client { get; }
        private DiscordSocketClient DiscordClient { get; }
        private IPermissionManager PermissionManager { get; }

        public CommandService(IDependencyFactory factory)
        {
            DependencyFactory = factory;
            Logger = factory.Get<ILogger>();
            DiscordClient = factory.Get<DiscordSocketClient>();
            Client = factory.Get<BotClient>();
            Readers = factory.Get<ITypeReaderCollection>();
            Database = factory.Get<IDatabase>();
            CommandList = Command.AsReadOnly();
            SettingsManager = factory.Get<ISettingsManager>();
            PermissionManager = factory.GetOrStore<IPermissionManager>();
        }

        public void Install(Assembly assembly)
        {
            var commandTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Command)) &&
                                                              !t.IsAbstract);
            Install(commandTypes.ToArray());
        }

        public void Install(params Type[] commandTypes)
        {
            var built = CommandInfo.BuildFrom(commandTypes).ToList();
            Command.AddRange(built);
            var builtCount = built.Count();
            var callCount = built.SelectMany(c => c.Calls).Count();
            var argCombCount = built.SelectMany(c => c.Calls).SelectMany(c => c.ArgumentPermatations).Count();
            Logger.Log(Logging.LogSeverity.Info, LogType.Command, $"Loaded {builtCount} command(s) | {callCount} call(s) | {argCombCount} argument combination(s)", "CommandService");
        }

        public CommandInfo? Search(string command, out int commandLength)
        {
            foreach (var cmd in CommandList)
            {
                var match = Regex.Match(command, $@"^{cmd.Name}(\b| +)", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    commandLength = match.Length;
                    return cmd;
                }
                foreach (var alias in cmd.Alias)
                {
                    match = Regex.Match(command, $@"^{alias}(\b| +)", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        commandLength = match.Length;
                        return cmd;
                    }
                }
            }
            commandLength = 0;
            return null;
        }

        public Task ParseAndExecute(IUserMessage message)
        {
            var context = DependencyFactory.WithInstance(message)
                                           .Construct<ICommandContext>();
            context.CheckCommand(this, SettingsManager.GlobalSettings.DefaultPrefix);
            if (!context.IsCommand && !context.ExplicitPrefix)
                return Task.CompletedTask;
            else if (!context.IsCommand)
                return message.Channel.SendMessageSafeAsync(DiscordUtil.FormatMessage($"That was not a recognised command! Try using `{context.Prefix}help` for a complete command list.", 1));
            return TryExecute(context);                
        }

        private async Task TryExecute(ICommandContext context)
        {
            if (context.Command == null)
                return;

            var command = context.Command.Value;

            var instance = DependencyFactory.WithInstance(context).Construct(command.CommandType) as Command;
            if (instance == null)
                throw new InvalidOperationException($"Unable to create an instance of the {command.CommandType} command");
            var replier = DependencyFactory.WithInstance(instance).Construct<IReplier>();
            ArgumentCheckResponse response = default(ArgumentCheckResponse);
            var calls = PermissionManager.CheckContext(context, command.Calls.ToArray());
            if (calls.Count() == 0)
            {
                await replier.ReplyAsync(context.Channel, context.Author, "You cannot use that command here!", ReplyType.Error);
                return;
            }
            calls = CheckSubcommands(calls, context);
            if (calls.Count() == 0)
            {
                await replier.ReplyAsync(context.Channel, context.Author, $"That is not a recognised subcommand for `{context.Prefix}{context.CommandText}`! Try using `{context.Prefix}help {context.CommandText}` for usage info.", ReplyType.Error);
                return;
            }
            foreach (var call in calls)
            {
                response = await MatchArguments(call, context);
                if (response.SuccessStatus == ArgumentCheckResult.Successful)
                {
                    var permCheck = PermissionManager.CheckAllowed(context, new CallInfo[] { call });
                    if (!permCheck.IsSuccess)
                    {
                        if (permCheck.ErrorMessage != null)
                            await replier.ReplyAsync(context.Channel, context.Author, permCheck.ErrorMessage, ReplyType.Error);
                    }
                    else
                    {
                        instance.Install(context, DependencyFactory);
                        LogCommand(context, call);
                        using (context.Channel.EnterTypingState())
                        {
                            await (Task)call.Call.Invoke(instance, response.CallArguments);
                        }
                    }
                    return;
                }
            }
            await replier.ReplyAsync(context.Channel, context.Author, response.ErrorMessage, ReplyType.Error);
        }

        private void LogCommand(ICommandContext context, CallInfo call)
        {
            var record = new CommandRecord
            {
                AuthorId = context.Author.Id,
                MessageId = context.Message.Id,
                ChannelId = context.Channel.Id,
                GuildId = context.Guild?.Id,
                MessageContent = context.Message.Content,
                UserName = context.Author.Username,
                ChannelName = context.Channel.Name,
                GuildName = context.Guild?.Name,
                TimeStamp = context.Message.Timestamp,
                Prefix = context.Prefix,
                CommandName = context.Command?.Name
            };
            Logger.LogAsync(TitanBot.Logging.LogSeverity.Debug, LogType.Command, $"{(record.GuildName != null ? $"{record.GuildName} ({record.GuildId}) \n" : "")}#{record.ChannelName} ({record.ChannelId})\n{record.UserName} ({record.AuthorId})\n{record.CommandName}", "CommandService");
            Database.Insert(record);
        }

        private CallInfo[] CheckSubcommands (CallInfo[] calls, ICommandContext context)
        {
            var noSubcalls = calls.Where(c => c.SubCall == null);
            var subcalls = calls.Where(c => c.SubCall != null).GroupBy(c => c.SubCall).OrderByDescending(g => g.Key.Length);
            foreach (var group in subcalls)
            {
                if (context.Message.Content.Substring(context.ArgPos).ToLower().Trim().StartsWith(group.Key.ToLower()))
                    return group.ToArray();
            }
            return noSubcalls.ToArray();
        }

        private async Task<ArgumentCheckResponse> MatchArguments(CallInfo call, ICommandContext context)
        {
            var reader = Readers.NewCache();
            var responses = new List<ArgumentCheckResponse>();
            foreach (var argPattern in call.ArgumentPermatations.OrderByDescending(p => p.Count(a => !a.UseDefault)))
            {
                var denseIndex = argPattern.Select((a, i) => a.IsDense ? i : (int?)null).FirstOrDefault(i => i != null);
                if (call.SubCall != null)
                    denseIndex ++;
                var maxLength = denseIndex.HasValue ? argPattern.Count(a => !a.UseDefault) + (call.SubCall != null ? 1 : 0) : (int?)null;
                var stringArgs = context.SplitArguments(call.Flags.Count() == 0, out(string Key, string Value)[] flagStrings, maxLength, denseIndex);
                var readResult = await ReadArguments(context, reader, stringArgs.Select(s => s.Trim()).ToArray(), flagStrings, argPattern, call);
                if (readResult.SuccessStatus == ArgumentCheckResult.Successful)
                    return readResult;
                responses.Add(readResult);
            }
            return responses.Last();
        }

        private async Task<ArgumentCheckResponse> ReadArguments(ICommandContext context, ITypeReaderCollection reader, string[] argStrings, (string Key, string Value)[] flags, ArgumentInfo[] argPattern, CallInfo call)
        {
            if (call.SubCall != null)
            {
                if (argStrings.Length == 0)
                    return ArgumentCheckResponse.FromError(ArgumentCheckResult.InvalidSubcall, $"You have not specified which sub call you would like to use! Try using `{context.Prefix}help {context.CommandText}` for usage info.");
                if (call.SubCall.ToLower() != argStrings[0].ToLower())
                    return ArgumentCheckResponse.FromError(ArgumentCheckResult.InvalidSubcall, $"The sub call `{argStrings[0]}` is not recognised! Try using `{context.Prefix}help {context.CommandText}` for usage info.");
                argStrings = argStrings.Skip(1).ToArray();
            }

            var acceptedLength = argPattern.Count(a => !a.UseDefault);
            if (argStrings.Length > acceptedLength)
                return ArgumentCheckResponse.FromError(ArgumentCheckResult.InvalidArguments, $"Too many arguments were supplied. Try using `{context.Prefix}help {context.CommandText}` for usage info.");
            else if (argStrings.Length < acceptedLength)
                return ArgumentCheckResponse.FromError(ArgumentCheckResult.InvalidArguments, $"Not enough arguments were supplied. Try using `{context.Prefix}help {context.CommandText}` for usage info.");

            var argResults = new object[argPattern.Length];
            var argIterator = argStrings.GetEnumerator();
            for (int i = 0; i < argResults.Length; i++)
            {
                if (argPattern[i].UseDefault)
                    argResults[i] = argPattern[i].DefaultValue;
                else if (argPattern[i].IsRawArgument)
                    argResults[i] = context.Message.Content.Substring(context.ArgPos);
                else
                {
                    if (!argIterator.MoveNext())
                        return ArgumentCheckResponse.FromError(ArgumentCheckResult.InvalidArguments, $"Not enough arguments were supplied. Try using `{context.Prefix}help {context.CommandText}` for usage info.");
                    var readRes = await reader.Read(argPattern[i].Type, context, (string)argIterator.Current);
                    if (!readRes.IsSuccess)
                        return ArgumentCheckResponse.FromError(ArgumentCheckResult.InvalidArguments, readRes.Message);
                    argResults[i] = readRes.Best;
                }
            }

            var flagResults = call.Flags.Select(f => f.DefaultValue).ToArray();
            for (int i = 0; i < call.Flags.Length; i++)
            {
                var flag = call.Flags[i];
                var flagVals = flags.Where(f => f.Key.ToLower() == flag.LongKey?.ToLower() ||
                                                f.Key.ToLower() == flag.ShortKey.ToString().ToLower());
                foreach (var val in flagVals)
                {
                    if (!flag.RequiresInput)
                        flagResults[i] = true;
                    else
                    {
                        var readResult = await reader.Read(flag.Type, context, val.Value);
                        if (readResult.IsSuccess)
                        {
                            flagResults[i] = readResult.Best;
                            break;
                        }
                    }
                }
            }

            return ArgumentCheckResponse.FromSuccess(argResults, flagResults);
        }
    }
}
