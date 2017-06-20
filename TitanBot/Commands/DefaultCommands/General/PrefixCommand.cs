﻿using System.Threading.Tasks;

namespace TitanBot.Commands.DefautlCommands.General
{
    [Description("Gets or sets a custom prefix that is required to use my commands")]
    [DefaultPermission(8)]
    class PrefixCommand : Command
    {
        [Call]
        [DefaultPermission(0, "Show")]
        [Usage("Gets all the available current prefixes")]
        async Task GetPrefixesAsync()
        {
            if (AcceptedPrefixes.Length > 0)
                await ReplyAsync($"Your available prefixes are {string.Join(", ", AcceptedPrefixes)}", ReplyType.Info);
            else
                await ReplyAsync("You do not require prefixes in this channel", ReplyType.Info);
        }

        [Call]
        [DefaultPermission(8, "Set")]
        [RequireContext(ContextType.Guild)]
        [Usage("Sets the custom prefix")]
        async Task SetPrefixAsync(string newPrefix)
        {
            GuildData.Prefix = newPrefix.ToLower();
            SettingsManager.SaveGroup(Guild.Id, GuildData);
            await ReplyAsync($"Your guilds prefix has been set to `{GuildData.Prefix}`", ReplyType.Success);
        }
    }
}
