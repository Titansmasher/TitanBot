﻿using DC = Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanBot2.Common;
using TitanBot2.Services.CommandService;
using TitanBot2.TypeReaders;

namespace TitanBot2.Commands.Admin
{
    public class NotifyCommand : Command
    {
        public NotifyCommand(TitanbotCmdContext context, TypeReaderCollection readers) : base(context, readers)
        {
            Calls.AddNew(a => ListTypesAsync((NotificationType)a[0]))
                 .WithArgTypes(typeof(NotificationType));
            Calls.AddNew(a => ListTypesAsync((NotificationType)a[0], (IMessageChannel)a[1]))
                 .WithArgTypes(typeof(NotificationType), typeof(IMessageChannel));
            Usage.Add("`{0} <notification> [channel]` - Sets which channel each notification should appear in.");
            Usage.Add("Valid notifications are:\n" + string.Join("\n", Enum.GetNames(typeof(NotificationType))));
            Description = "Used to enable/disable notifications of various bot events";
            RequiredContexts = DC.ContextType.Guild;
            DefaultPermission = 8;
        }

        public async Task ListTypesAsync(NotificationType notificationType, IMessageChannel channel = null)
        {
            switch (notificationType)
            {
                case NotificationType.alive:
                case NotificationType.online:
                    await SetAliveAsync(channel);
                    break;
                case NotificationType.dead:
                case NotificationType.offline:
                    await SetDeadAsync(channel);
                    break;
            }
        }

        public enum NotificationType
        {
            alive,
            online,
            dead,
            offline
        }

        public async Task SetAliveAsync(IMessageChannel channel)
        {
            if (channel != null && !Context.Guild.Channels.Select(c => c.Id).Contains(channel.Id))
            {
                await ReplyAsync("That channel does not exist on this guild!", ReplyType.Error);
                return;
            }

            var guildData = await Context.Database.Guilds.GetGuild(Context.Guild.Id);
            guildData.NotifyAlive = channel?.Id;
            await Context.Database.QueryAsync(conn => conn.GuildTable.Update(guildData), ex => Context.TitanBot.Logger.Log(ex, "NotifyCmd"));
            if (channel == null)
                await ReplyAsync("This guild will no longer recieve notification when I come onine!", ReplyType.Success);
            else
                await ReplyAsync($"Set <#{channel.Id}> to recieve a message when I come online!", ReplyType.Success);

        }

        public async Task SetDeadAsync(IMessageChannel channel)
        {
            if (channel != null && !Context.Guild.Channels.Select(c => c.Id).Contains(channel.Id))
            {
                await ReplyAsync("That channel does not exist on this guild!", ReplyType.Error);
                return;
            }

            var guildData = await Context.Database.Guilds.GetGuild(Context.Guild.Id);
            guildData.NotifyDead = channel?.Id;
            await Context.Database.QueryAsync(conn => conn.GuildTable.Update(guildData), ex => Context.TitanBot.Logger.Log(ex, "NotifyCmd"));
            if (channel == null)
                await ReplyAsync("This guild will no longer recieve notification when I shutdown!", ReplyType.Success);
            else
                await ReplyAsync($"Set <#{channel.Id}> to recieve a message when I am shutting down!", ReplyType.Success);
        }
    }
}
