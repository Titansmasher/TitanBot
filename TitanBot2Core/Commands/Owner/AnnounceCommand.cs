﻿using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanBot2.Common;
using TitanBot2.Extensions;
using TitanBot2.Services.CommandService;
using TitanBot2.TypeReaders;

namespace TitanBot2.Commands.Owner
{
    public class AnnounceCommand : Command
    {
        public AnnounceCommand(TitanbotCmdContext context, TypeReaderCollection readers) : base(context, readers)
        {
            Calls.AddNew(a => AnnounceAsync((string)a[0]))
                 .WithArgTypes(typeof(string))
                 .WithItemAsParams(0);
            RequireOwner = true;
            Usage.Add("`{0} <message>` - Instructs what message to send");
            Description = "Sends a message to the owners of each server that I am on";
        }

        public async Task AnnounceAsync(string message)
        {
            var builder = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    IconUrl = Context.User.GetAvatarUrl(),
                    Name = Context.User.Username
                },
                Color = System.Drawing.Color.Aqua.ToDiscord(),
                Footer = new EmbedFooterBuilder
                {
                    IconUrl = Context.Client.CurrentUser.GetAvatarUrl(),
                    Text = $"{Context.Client.CurrentUser.Username} | Announcement"
                },
                Title = "Global Announcement",
                Description = message,
                Timestamp = DateTime.Now
            };

            var guilds = Context.Client.Guilds;

            await ReplyAsync("I will notify all my users!", ReplyType.Success);

            foreach (var guild in guilds)
            {
                var dmChannel = (IDMChannel)Context.Client.DMChannels.SingleOrDefault(c => c.Recipient.Id == guild.Owner.Id) ??
                    await guild.Owner.CreateDMChannelAsync();
                await dmChannel.SendMessageSafeAsync($"This announcement was sent to you because you are the owner of the {guild.Name} server, which I am also on.", embed: builder.Build());
            }

            await Task.Delay(20000);
        }
    }
}
