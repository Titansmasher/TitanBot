﻿using Discord;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TitanBot.Dependencies;
using TitanBot.Formatting;
using TitanBot.Replying;

namespace TitanBot.Commands.DefautlCommands.General
{
    [Description(TitanBotResource.INFO_HELP_DESCRIPTION)]
    public class InfoCommand : Command
    {
        public static List<Func<InfoCommand, (LocalisedString TitleKey, object Value, bool IsInline)>> TechnicalActions { get; } = new List<Func<InfoCommand, (LocalisedString, object, bool)>>();
        private ITextResourceManager TextManager { get; }
        private IDependencyFactory Factory { get; }

        static InfoCommand()
        {
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_GUILDS, c.Client.Guilds.Count, true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_CHANNELS, c.Client.Guilds.Sum(g => g.Channels.Count), true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_USERS, c.Client.Guilds.SelectMany(g => g.Users).Distinct().Count(), true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_COMMANDS, c.CommandService.CommandList.Count, true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_CALLS, c.CommandService.CommandList.Sum(m => m.Calls.Count), true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_COMMANDS_USED, TotalCommands, true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_DATABASE_QUERIES, c.Database.TotalCalls, true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_FACTORY_BUILT, c.Factory.History.Count, true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_RAM, c.Beautify((double)Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024)) + " / " + c.Beautify(PerformanceUtil.getAvailableRAM()), true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_CPU, PerformanceUtil.getCurrentCPUUsage(), true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_TIMERS, c.Scheduler.ActiveCount(), true));
            TechnicalActions.Add(c => (TitanBotResource.INFO_FIELD_UPTIME, DateTime.Now - Process.GetCurrentProcess().StartTime, true));
        }

        public InfoCommand(ITextResourceManager textManager, IDependencyFactory factory)
        {
            TextManager = textManager;
            Factory = factory;
        }

        [Call("Language")]
        [Usage(TitanBotResource.INFO_HELP_USAGE_LANGUAGE)]
        async Task ShowLanguageInfo()
        {
            var builder = new LocalisedEmbedBuilder
            {
                Description = TitanBotResource.INFO_LANGUAGE_EMBED_DESCRIPTION
            };
            foreach (var lang in TextManager.SupportedLanguages)
            {
                builder.AddInlineField(lang.ToString(), (TitanBotResource.INFO_LANGUAGE_COVERAGE, TextManager.GetLanguageCoverage(lang) * 100 ));
            }

            await ReplyAsync(builder);
        }

        [Call("Technical")]
        [Usage(TitanBotResource.INFO_HELP_USAGE_TECHNICAL)]
        async Task ShowInfoAsync()
        {
            var builder = new LocalisedEmbedBuilder
            {
                Title = (TitanBotResource.INFO_TECHNICAL_TITLE, ReplyType.Info),
                Color = System.Drawing.Color.LawnGreen.ToDiscord(),
                Footer = new LocalisedFooterBuilder
                {
                    Text = (TitanBotResource.EMBED_FOOTER, BotUser.Username, "System Data" )
                },
                Timestamp = DateTime.Now
            };

            foreach (var action in TechnicalActions)
            {
                var settings = action(this);
                builder.AddField(settings.TitleKey, new LocalisedString(settings.Value), settings.IsInline);
            }

            await ReplyAsync(builder);
        }
    }
}
