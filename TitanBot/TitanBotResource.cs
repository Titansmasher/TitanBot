﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanBot
{
    public static class TitanBotResource
    {
        public const string PING_HELP_DESCRIPTION = "PING_HELP_DESCRIPTION";
        public const string PING_HELP_USAGE = "PING_HELP_USAGE";
        public const string EDITCOMMAND_HELP_DESCRIPTION = "EDITCOMMAND_HELP_DESCRIPTION";
        public const string EDITCOMMAND_HELP_NOTES = "EDITCOMMAND_HELP_NOTES";
        public const string EDITCOMMAND_HELP_USAGE_SETROLE = "EDITCOMMAND_HELP_USAGE_SETROLE";
        public const string EDITCOMMAND_HELP_USAGE_SETPERM = "EDITCOMMAND_HELP_USAGE_SETPERM";
        public const string EDITCOMMAND_HELP_USAGE_RESET = "EDITCOMMAND_HELP_USAGE_RESET";
        public const string EDITCOMMAND_HELP_USAGE_BLACKLIST = "EDITCOMMAND_HELP_USAGE_BLACKLIST";
        public const string SETTINGS_HELP_DESCRIPTION = "SETTINGS_HELP_DESCRIPTION";
        public const string SETTINGS_HELP_USAGE_DEFAULT = "SETTINGS_HELP_USAGE_DEFAULT";
        public const string SETTINGS_HELP_USAGE_TOGGLE = "SETTINGS_HELP_USAGE_TOGGLE";
        public const string SETTINGS_HELP_USAGE_SET = "SETTINGS_HELP_USAGE_SET";
        public const string SETTINGSRESET_HELP_DESCRIPTION = "SETTINGSRESET_HELP_DESCRIPTION";
        public const string SETTINGSRESET_HELP_USAGE_THISGUILD = "SETTINGSRESET_HELP_USAGE_THISGUILD";
        public const string SETTINGSRESET_HELP_USAGE_GIVENGUILD = "SETTINGSRESET_HELP_USAGE_GIVENGUILD";
        public const string ABOUT_HELP_DESCRIPTION = "ABOUT_HELP_DESCRIPTION";
        public const string ABOUT_HELP_USAGE = "ABOUT_HELP_USAGE";
        public const string DONATE_HELP_DESCRIPTION = "DONATE_HELP_DESCRIPTION";
        public const string DONATE_HELP_USAGE = "DONATE_HELP_USAGE";
        public const string HELP_HELP_DESCRIPTION = "HELP_HELP_DESCRIPTION";
        public const string HELP_HELP_USAGE = "HELP_HELP_USAGE";
        public const string HELP_HELP_USAGE_TUTORIAL = "HELP_HELP_USAGE_TUTORIAL";
        public const string INFO_HELP_DESCRIPTION = "INFO_HELP_DESCRIPTION";
        public const string INFO_HELP_USAGE_LANGUAGE = "INFO_HELP_USAGE_LANGUAGE";
        public const string INFO_HELP_USAGE_TECHNICAL = "INFO_HELP_USAGE_TECHNICAL";
        public const string INVITE_HELP_DESCRIPTION = "INVITE_HELP_DESCRIPTION";
        public const string INVITE_HELP_USAGE = "INVITE_HELP_USAGE";
        public const string PREFIX_HELP_DESCRIPTION = "PREFIX_HELP_DESCRIPTION";
        public const string PREFIX_HELP_USAGE_SHOW = "PREFIX_HELP_USAGE_SHOW";
        public const string PREFIX_HELP_USAGE_SET = "PREFIX_HELP_USAGE_SET";
        public const string DBPURGE_HELP_DESCRIPTION = "DBPURGE_HELP_DESCRIPTION";
        public const string DBPURGE_HELP_USAGE = "DBPURGE_HELP_USAGE";
        public const string EXEC_HELP_DESCRIPTION = "EXEC_HELP_DESCRIPTION";
        public const string EXEC_HELP_NOTES = "EXEC_HELP_NOTES";
        public const string EXEC_HELP_USAGE = "EXEC_HELP_USAGE";
        public const string GLOBALSETTINGS_HELP_DESCRIPTION = "GLOBALSETTINGS_HELP_DESCRIPTION";
        public const string GLOBALSETTINGS_HELP_USAGE_DEFAULT = "GLOBALSETTINGS_HELP_USAGE_DEFAULT";
        public const string GLOBALSETTINGS_HELP_USAGE_TOGGLE = "GLOBALSETTINGS_HELP_USAGE_TOGGLE";
        public const string GLOBALSETTINGS_HELP_USAGE_SET = "GLOBALSETTINGS_HELP_USAGE_SET";
        public const string SHUTDOWN_HELP_DESCRIPTION = "SHUTDOWN_HELP_DESCRIPTION";
        public const string SHUTDOWN_HELP_USAGE = "SHUTDOWN_HELP_USAGE";
        public const string SUDOCOMMAND_HELP_DESCRIPTION = "SUDOCOMMAND_HELP_DESCRIPTION";
        public const string SUDOCOMMAND_HELP_USAGE = "SUDOCOMMAND_HELP_USAGE";
        public const string PREFERENCES_HELP_DESCRIPTION = "PREFERENCES_HELP_DESCRIPTION";
        public const string PREFERENCES_HELP_USAGE_DEFAULT = "PREFERENCES_HELP_USAGE_DEFAULT";
        public const string PREFERENCES_HELP_USAGE_TOGGLE = "PREFERENCES_HELP_USAGE_TOGGLE";
        public const string PREFERENCES_HELP_USAGE_SET = "PREFERENCES_HELP_USAGE_SET";
        public const string RELOAD_HELP_DESCRIPTION = "RELOAD_HELP_DESCRIPTION";
        public const string RELOAD_HELP_USAGE = "RELOAD_HELP_USAGE";
        public const string RELOAD_HELP_USAGE_LIST = "RELOAD_HELP_USAGE_LIST";
        public const string EXCEPTION_HELP_DESCRIPTION = "EXCEPTION_HELP_DESCRIPTION";
        public const string EXCEPTION_HELP_USAGE = "EXCEPTION_HELP_USAGE";
        public const string EXCEPTION_HELP_FLAG_F = "EXCEPTION_HELP_FLAG_F";

        public const string SETTINGS_GUILD_GENERAL_DESCRIPTION = "SETTINGS_GUILD_GENERAL_DESCRIPTION";
        public const string SETTINGS_GUILD_GENERAL_NOTES = "SETTINGS_GUILD_GENERAL_NOTES";
        public const string SETTINGS_GLOBAL_GENERAL_DESCRIPTION = "SETTINGS_GLOBAL_GENERAL_DESCRIPTION";
        public const string SETTINGS_USER_GENERAL_DESCRIPTION = "SETTINGS_USER_GENERAL_DESCRIPTION";
        public const string LOCALE_UNKNOWN = "LOCALE_UNKNOWN";
        public const string FORMATTINGTYPE_UNKNOWN = "FORMATTINGTYPE_UNKNOWN";

        public const string COMMANDEXECUTOR_COMMAND_UNKNOWN = "COMMANDEXECUTOR_COMMAND_UNKNOWN";
        public const string COMMANDEXECUTOR_DISALLOWED_CHANNEL = "COMMANDEXECUTOR_DISALLOWED_CHANNEL";
        public const string COMMANDEXECUTOR_SUBCALL_UNKNOWN = "COMMANDEXECUTOR_SUBCALL_UNKNOWN";
        public const string COMMANDEXECUTOR_SUBCALL_UNSPECIFIED = "COMMANDEXECUTOR_SUBCALL_UNSPECIFIED";
        public const string COMMANDEXECUTOR_ARGUMENTS_TOOMANY = "COMMANDEXECUTOR_ARGUMENTS_TOOMANY";
        public const string COMMANDEXECUTOR_ARGUMENTS_TOOFEW = "COMMANDEXECUTOR_ARGUMENTS_TOOFEW";
        public const string COMMANDEXECUTOR_EXCEPTION_ALERT = "COMMANDEXECUTOR_EXCEPTION_ALERT";
        public const string PERMISSIONMANAGER_DISALLOWED_NOTHERE = "PERMISSIONMANAGER_DISALLOWED_NOTHERE";
        public const string PERMISSIONMANAGER_DISALLOWED_NOTOWNER = "PERMISSIONMANAGER_DISALLOWED_NOTOWNER";
        public const string PERMISSIONMANAGER_DISALLOWED_NOPERMISSION = "PERMISSIONMANAGER_DISALLOWED_NOPERMISSION";
        public const string COMMAND_DELAY_DEFAULT = "COMMAND_DELAY_DEFAULT";
        public const string TYPEREADER_UNABLETOREAD = "TYPEREADER_UNABLETOREAD";
        public const string TYPEREADER_NOTYPEREADER = "TYPEREADER_NOTYPEREADER";
        public const string TYPEREADER_ENTITY_NOTFOUND = "TYPEREADER_ENTITY_NOTFOUND";
        public const string UNABLE_SEND = "UNABLE_SEND";
        public const string MESSAGE_TOO_LONG = "MESSAGE_TOO_LONG";
        public const string MESSAGE_CONTAINED_ATTACHMENT = "MESSAGE_CONTAINED_ATTACHMENT";

        public const string PING_INITIAL = "PING_INITIAL";
        public const string PING_VERIFY = "PING_VERIFY";
        public const string INFO_LANGUAGE_EMBED_DESCRIPTION = "INFO_LANGUAGE_EMBED_DESCRIPTION";
        public const string EDITCOMMAND_FINDCALLS_NORESULTS = "EDITCOMMAND_FINDCALLS_NORESULTS";
        public const string EDITCOMMAND_SUCCESS = "EDITCOMMAND_SUCCESS";
        public const string SETTINGS_FOOTERTEXT = "SETTINGS_FOOTERTEXT";
        public const string SETTINGS_TITLE_NOGROUP = "SETTINGS_TITLE_NOGROUP";
        public const string SETTINGS_DESCRIPTION_NOSETTINGS = "SETTINGS_DESCRIPTION_NOSETTINGS";
        public const string SETTINGS_INVALIDGROUP = "SETTINGS_INVALIDGROUP";
        public const string SETTINGS_TITLE_GROUP = "SETTINGS_TITLE_GROUP";
        public const string SETTINGS_NOTSET = "SETTINGS_NOTSET";
        public const string SETTINGS_KEY_NOTFOUND = "SETTINGS_KEY_NOTFOUND";
        public const string SETTINGS_UNABLE_TOGGLE = "SETTINGS_UNABLE_TOGGLE";
        public const string SETTINGS_VALUE_INVALID = "SETTINGS_VALUE_INVALID";
        public const string SETTINGS_VALUE_CHANGED_TITLE = "SETTINGS_VALUE_CHANGED_TITLE";
        public const string SETTING_VALUE_OLD = "SETTING_VALUE_OLD";
        public const string SETTING_VALUE_NEW = "SETTING_VALUE_NEW";
        public const string SETTINGRESET_GUILD_NOTEXIST = "SETTINGRESET_GUILD_NOTEXIST";
        public const string SETTINGRESET_SUCCESS = "SETTINGRESET_SUCCESS";
        public const string ABOUT_MESSAGE = "ABOUT_MESSAGE";
        public const string DONATE_MESSAGE_ADDITIONAL = "DONATE_MESSAGE_ADDITIONAL";
        public const string HELP_LIST_TITLE = "HELP_LIST_TITLE";
        public const string HELP_LIST_DESCRIPTION = "HELP_LIST_DESCRIPTION";
        public const string HELP_LIST_COMMAND = "HELP_LIST_COMMAND";
        public const string HELP_SINGLE_UNRECOGNISED = "HELP_SINGLE_UNRECOGNISED";
        public const string HELP_SINGLE_NOUSAGE = "HELP_SINGLE_NOUSAGE";
        public const string HELP_SINGLE_NODESCRIPTION = "HELP_SINGLE_NODESCRIPTION";
        public const string HELP_SINGLE_NOGROUP = "HELP_SINGLE_NOGROUP";
        public const string HELP_SINGLE_TITLE = "HELP_SINGLE_TITLE";
        public const string HELP_SINGLE_USAGE_FOOTER = "HELP_SINGLE_USAGE_FOOTER";
        public const string INFO_FIELD_GUILDS = "INFO_FIELD_GUILDS";
        public const string INFO_FIELD_CHANNELS = "INFO_FIELD_CHANNELS";
        public const string INFO_FIELD_USERS = "INFO_FIELD_USERS";
        public const string INFO_FIELD_COMMANDS = "INFO_FIELD_COMMANDS";
        public const string INFO_FIELD_CALLS = "INFO_FIELD_CALLS";
        public const string INFO_FIELD_COMMANDS_USED = "INFO_FIELD_COMMANDS_USED";
        public const string INFO_FIELD_DATABASE_QUERIES = "INFO_FIELD_DATABASE_QUERIES";
        public const string INFO_FIELD_RAM = "INFO_FIELD_RAM";
        public const string INFO_FIELD_CPU = "INFO_FIELD_CPU";
        public const string INFO_FIELD_TIMERS = "INFO_FIELD_TIMERS";
        public const string INFO_FIELD_UPTIME = "INFO_FIELD_UPTIME";
        public const string INFO_LANGUAGE_COVERAGE = "INFO_LANGUAGE_COVERAGE";
        public const string INFO_TECHNICAL_TITLE = "INFO_TECHNICAL_TITLE";
        public const string INVITE_MESSAGE = "INVITE_MESSAGE";
        public const string PREFIX_SHOW_NOPREFIX = "PREFIX_SHOW_NOPREFIX";
        public const string PREFIX_SHOW_MESSAGE = "PREFIX_SHOW_MESSAGE";
        public const string PREFIX_SET_MESSAGE = "PREFIX_SET_MESSAGE";
        public const string DBPURGE_SUCCESS = "DBPURGE_SUCCESS";
        public const string EXEC_FOOTER_CONSTRUCTFAILED = "EXEC_FOOTER_CONSTRUCTFAILED";
        public const string EXEC_FOOTER_COMPILEFAILED = "EXEC_FOOTER_COMPILEFAILED";
        public const string EXEC_FOOTER_EXECUTEFAILED = "EXEC_FOOTER_EXECUTEFAILED";
        public const string EXEC_FOOTER_SUCCESS = "EXEC_FOOTER_SUCCESS";
        public const string EXEC_INPUT_FORMAT = "EXEC_INPUT_FORMAT";
        public const string EXEC_OUTPUT_NULL = "EXEC_OUTPUT_NULL";
        public const string EXEC_OUTPUT_FORMAT = "EXEC_OUTPUT_FORMAT";
        public const string EXEC_TITLE_EXCEPTION = "EXEC_TITLE_EXCEPTION";
        public const string EXEC_TITLE_SUCCESS = "EXEC_TITLE_SUCCESS";
        public const string SHUTDOWN_INTIME = "SHUTDOWN_INTIME";
        public const string SUDOCOMMAND_SUCCESS = "SUDOCOMMAND_SUCCESS";
        public const string EXCEPTION_NOTFOUND = "EXCEPTION_NOTFOUND";
        public const string EXCEPTION_MESSAGE = "EXCEPTION_MESSAGE";
        public const string EXCEPTION_CHANNEL = "EXCEPTION_CHANNEL";
        public const string EXCEPTION_GUILD = "EXCEPTION_GUILD";
        public const string EXCEPTION_FULLMESSAGE = "EXCEPTION_FULLMESSAGE";
        public const string EXCEPTION_USER = "EXCEPTION_USER";
        public const string RELOAD_AREA_NOTFOUND = "RELOAD_AREA_NOTFOUND";
        public const string RELOAD_SUCCESS = "RELOAD_SUCCESS";
        public const string RELOAD_LIST = "RELOAD_LIST";

        public const string EMBED_FOOTER = "EMBED_FOOTER";
        public const string REPLYTYPE_SUCCESS = "REPLYTYPE_SUCCESS";
        public const string REPLYTYPE_ERROR = "REPLYTYPE_ERROR";
        public const string REPLYTYPE_INFO = "REPLYTYPE_INFO";
        public const string NOTES = "NOTES";
        public const string GROUP = "GROUP";
        public const string ALIASES = "ALIASES";
        public const string USAGE = "USAGE";
        public const string FLAGS = "FLAGS";
        public const string INPUT = "INPUT";
        public const string ERROR = "ERROR";
        public const string OUTPUT = "OUTPUT";
        public const string UNKNOWNUSER = "UNKNOWNUSER";

        public const string TIMESPAN = "TIMESPAN";
        public const string STRING = "STRING";
        public const string INT64 = "INT64";
        public const string INT32 = "INT32";
        public const string INT16 = "INT16";
        public const string UINT64 = "UINT64";
        public const string UINT32 = "UINT32";
        public const string UINT16 = "UINT16";
        public const string DOUBLE = "DOUBLE";
        public const string FLOAT = "FLOAT";
        public const string DECIMAL = "DECIMAL";
        public const string BOOLEAN = "BOOLEAN";
        public const string DATETIME = "DATETIME";

        public static Dictionary<string, string> GetDefaults()
            => new Dictionary<string, string>
            {
                { PING_HELP_DESCRIPTION, "Basic command for calculating the delay of the bot." },
                { PING_HELP_USAGE, "Replies with a pong and what the current delay is." },
                { EDITCOMMAND_HELP_DESCRIPTION, "Used to allow people with varying roles or permissions to use different commands." },
                { EDITCOMMAND_HELP_NOTES, "To work out just what permission id you need, give the [permission calculator](https://discordapi.com/permissions.html) a try!" },
                { EDITCOMMAND_HELP_USAGE_SETROLE, "Sets a list of roles required to use each command supplied" },
                { EDITCOMMAND_HELP_USAGE_SETPERM, "Sets a permission required to use each command supplied" },
                { EDITCOMMAND_HELP_USAGE_RESET, "Resets the roles and permissions required to use each command supplied" },
                { EDITCOMMAND_HELP_USAGE_BLACKLIST, "Prevents anyone with permissions below the override permissions from using the command in the given channel" },
                { SETTINGS_HELP_DESCRIPTION, "Allows the retrieval and changing of existing settings for the server" },
                { SETTINGS_HELP_USAGE_DEFAULT, "Lists all settings available" },
                { SETTINGS_HELP_USAGE_TOGGLE, "Toggles the given setting. Only works for true/false/yes/no settings" },
                { SETTINGS_HELP_USAGE_SET, "Sets the given setting to the given value." },
                { SETTINGSRESET_HELP_DESCRIPTION, "Resets all settings and command permissions for a guild." },
                { SETTINGSRESET_HELP_USAGE_THISGUILD, "Resets settings for this guild" },
                { SETTINGSRESET_HELP_USAGE_GIVENGUILD, "Resets the given guild" },
                { ABOUT_HELP_DESCRIPTION, "A tiny command that just displays some helpful links :)" },
                { ABOUT_HELP_USAGE, "Shows some about text for me" },
                { DONATE_HELP_DESCRIPTION, "You.. youre thinking of donating? :open_mouth: This command will give you a link to my patreon page" },
                { DONATE_HELP_USAGE, "Gives you the link you awesome person :heart:" },
                { HELP_HELP_DESCRIPTION, "Displays help for any command" },
                { HELP_HELP_USAGE, "Displays a list of all commands, or help for a single command" },
                { HELP_HELP_USAGE_TUTORIAL, "Displays information about a given tutorial" },
                { INFO_HELP_DESCRIPTION, "Displays some technical information about me" },
                { INFO_HELP_USAGE_LANGUAGE, "Displays info about what languages are supported" },
                { INFO_HELP_USAGE_TECHNICAL, "Displays technical info for me" },
                { INVITE_HELP_DESCRIPTION, "Provides a link to invite me to any guild" },
                { INVITE_HELP_USAGE, "Shows the invite link" },
                { PREFIX_HELP_DESCRIPTION, "Gets or sets a custom prefix that is required to use my commands" },
                { PREFIX_HELP_USAGE_SHOW, "Gets all the available current prefixes" },
                { PREFIX_HELP_USAGE_SET, "Sets the custom prefix" },
                { DBPURGE_HELP_DESCRIPTION, "Wipes any database table clean" },
                { DBPURGE_HELP_USAGE, "Wipes the given table." },
                { EXEC_HELP_DESCRIPTION, "Allows for arbitrary code execution" },
                { EXEC_HELP_NOTES, "https://github.com/Titansmasher/TitanBot/blob/rewrite/TitanBotBase/Commands/DefaultCommands/Owner/ExecCommand.cs#L111" },
                { EXEC_HELP_USAGE, "Executes arbitrary code" },
                { GLOBALSETTINGS_HELP_DESCRIPTION, "Allows the retrieval and changing of existing settings for the server" },
                { GLOBALSETTINGS_HELP_USAGE_DEFAULT, "Lists all settings available" },
                { GLOBALSETTINGS_HELP_USAGE_TOGGLE, "Toggles the given setting. Only works for true/false/yes/no settings" },
                { GLOBALSETTINGS_HELP_USAGE_SET, "Sets the given setting to the given value." },
                { SHUTDOWN_HELP_DESCRIPTION, "Shuts me down" },
                { SHUTDOWN_HELP_USAGE, "Shuts me down now, or in the time provided" },
                { SUDOCOMMAND_HELP_DESCRIPTION, "Executes any command on behalf of another user. Requires a prefix in the message" },
                { SUDOCOMMAND_HELP_USAGE, "Will execute any command as the given user" },
                { PREFERENCES_HELP_DESCRIPTION, "Allows you to set some options for how the bot will interact with you." },
                { PREFERENCES_HELP_USAGE_DEFAULT, "Lists all preferences that are available" },
                { PREFERENCES_HELP_USAGE_TOGGLE, "Toggles the given preference. Only works for true/false/yes/no preferences" },
                { PREFERENCES_HELP_USAGE_SET, "Sets the given preference to the given value" },
                { RELOAD_HELP_DESCRIPTION, "Reloads a given area of the bot" },
                { RELOAD_HELP_USAGE, "Reloads the supplied area" },
                { RELOAD_HELP_USAGE_LIST, "Lists all available areas to reload" },
                { EXCEPTION_HELP_DESCRIPTION, "Shows details about exceptions that have occured within the bot" },
                { EXCEPTION_HELP_USAGE, "Shows details about the given exception" },
                { EXCEPTION_HELP_FLAG_F, "Returns the full exception in a file" },

                //Settings stuff

                { SETTINGS_GUILD_GENERAL_DESCRIPTION, "General guild settings" },
                { SETTINGS_GUILD_GENERAL_NOTES, "For DateTimeFormat, you can use [this link](https://www.codeproject.com/Articles/19677/Formats-for-DateTime-ToString) to help determine what is and is not valid!" },
                { SETTINGS_GLOBAL_GENERAL_DESCRIPTION, "General global settings" },
                { SETTINGS_USER_GENERAL_DESCRIPTION, "General user settings" },
                { LOCALE_UNKNOWN, "The locale `{0}` does not yet exist." },
                { FORMATTINGTYPE_UNKNOWN, "The formatting type `{0}` does not exist." },

                //Bot stuff

                { COMMANDEXECUTOR_COMMAND_UNKNOWN, "`{0}{1}` is not a recognised command! Try using `{0}help` for a complete command list." },
                { COMMANDEXECUTOR_DISALLOWED_CHANNEL, "You cannot use that command here!" },
                { COMMANDEXECUTOR_SUBCALL_UNKNOWN, "That is not a recognised subcommand for `{0}{1}`! Try using `{0}help {1}` for usage info." },
                { COMMANDEXECUTOR_SUBCALL_UNSPECIFIED, "You have not specified which sub call you would like to use! Try using `{0}help {1}` for usage info." },
                { COMMANDEXECUTOR_ARGUMENTS_TOOMANY, "Too many arguments were supplied. Try using `{0}help {1}` for usage info." },
                { COMMANDEXECUTOR_ARGUMENTS_TOOFEW, "Not enough arguments were supplied. Try using `{0}help {1}` for usage info." },
                { COMMANDEXECUTOR_EXCEPTION_ALERT, "There was an error when processing your command! ({0}) Please contact Titansmasher asap and give him EXCEPTIONID: {1}" },
                { PERMISSIONMANAGER_DISALLOWED_NOTHERE, "You cannot use that command here!" },
                { PERMISSIONMANAGER_DISALLOWED_NOTOWNER, "Only owners can use that command!" },
                { PERMISSIONMANAGER_DISALLOWED_NOPERMISSION, "You do not have permission to use that command!" },
                { COMMAND_DELAY_DEFAULT, "This seems to be taking longer than expected..." },
                { TYPEREADER_UNABLETOREAD, "I could not read `{2}` as {3}" },
                { TYPEREADER_NOTYPEREADER, "No reader found for `{3}`" },
                { TYPEREADER_ENTITY_NOTFOUND, "{3} `{2}` could not be found" },
                { UNABLE_SEND, "I was unable to send this message in {0} because I did not have permission:\n{1}" },
                { MESSAGE_TOO_LONG, "I tried to send a message that was too long! Here is that message." },
                { MESSAGE_CONTAINED_ATTACHMENT, "This message also contained an attachment, however I was unable to include that here." },

                //Command stuff

                { PING_INITIAL, "| ~{0} ms" },
                { PING_VERIFY, "| {0} ms" },
                { INFO_LANGUAGE_EMBED_DESCRIPTION, "Here are all the supported languages by me!" },
                { EDITCOMMAND_FINDCALLS_NORESULTS, "There were no commands that matched those calls." },
                { EDITCOMMAND_SUCCESS, "{0} set successfully for {1} command(s)!" },
                { SETTINGS_FOOTERTEXT, "{0} | Settings" },
                { SETTINGS_TITLE_NOGROUP, "Please select a setting group from the following:" },
                { SETTINGS_DESCRIPTION_NOSETTINGS, "No settings groups available!" },
                { SETTINGS_INVALIDGROUP, "`{0}`isnt a valid setting group!" },
                { SETTINGS_TITLE_GROUP, "Here are all the settings for the group `{0}`" },
                { SETTINGS_NOTSET, "Not Set" },
                { SETTINGS_KEY_NOTFOUND, "Could not find the `{0}` setting" },
                { SETTINGS_UNABLE_TOGGLE, "You cannot toggle the `{0}` setting" },
                { SETTINGS_VALUE_INVALID, "`{1}` is not a valid value for the setting {0}" },
                { SETTINGS_VALUE_CHANGED_TITLE, "{0} has changed" },
                { SETTING_VALUE_OLD, "Old value" },
                { SETTING_VALUE_NEW, "New value" },
                { SETTINGRESET_GUILD_NOTEXIST, "That guild does not exist." },
                { SETTINGRESET_SUCCESS, "All settings deleted for {0}({1})" },
                { ABOUT_MESSAGE, "'Ello there :wave:, Im Titanbot! Im an open source discord bot library written in C# by Titansmasher, with a fair bit of help from Mildan too!.\n" +
                                            "This is unfortunately just my base functionality, however there are other bots that run using this bot as its core library.\n" +
                                            "If you wish to use this library to make your own bot, feel free to do so! You can find me on github here: <https://github.com/Titansmasher/TitanBot>\n\n" +
                                            "_If you are seeing this on a fully fledged bot, please contact the owner of said bot because they appear to have not supplied their own about message_" },
                { DONATE_MESSAGE_ADDITIONAL, "" },
                { HELP_LIST_TITLE, "These are the commands you can use" },
                { HELP_LIST_DESCRIPTION, "To use a command, type `<prefix><command>`\n  e.g. `{0}help`\n" +
                                                    "To pass arguments, add a list of values after the command separated by space\n  e.g. `{0}command a b c, d`\n" +
                                                    "You can use any of these prefixes: \"{1}\"" },
                { HELP_LIST_COMMAND, "{0} Commands:\n    {1}" },
                { HELP_SINGLE_UNRECOGNISED, "`{0}` is not a recognised command. Use `{1}help` for a list of all available commands" },
                { HELP_SINGLE_NOUSAGE, "No usage available!" },
                { HELP_SINGLE_NODESCRIPTION, "No description!" },
                { HELP_SINGLE_NOGROUP, "No categories!" },
                { HELP_SINGLE_TITLE, "Help for {0}" },
                { HELP_SINGLE_USAGE_FOOTER, "\n\n_`<param>` = required\n`[param]` = optional\n`<param...>` = accepts multiple (comma separated)_" },
                { INFO_FIELD_GUILDS, "Guilds" },
                { INFO_FIELD_CHANNELS, "Channels" },
                { INFO_FIELD_USERS, "Users" },
                { INFO_FIELD_COMMANDS, "Loaded commands" },
                { INFO_FIELD_CALLS, "Loaded calls" },
                { INFO_FIELD_COMMANDS_USED, "Commands used this session" },
                { INFO_FIELD_DATABASE_QUERIES, "Database queries" },
                { INFO_FIELD_RAM, "RAM" },
                { INFO_FIELD_CPU, "CPU" },
                { INFO_FIELD_TIMERS, "Active Timers" },
                { INFO_FIELD_UPTIME, "Uptime" },
                { INFO_LANGUAGE_COVERAGE, "{0}% Coverage" },
                { INFO_TECHNICAL_TITLE, "Current execution statistics" },
                { INVITE_MESSAGE, "Want to invite me to your guild? Click this link!\n<https://discordapp.com/oauth2/authorize?client_id={0}&scope=bot&permissions={1}>" },
                { PREFIX_SHOW_NOPREFIX, "You do not require prefixes in this channel" },
                { PREFIX_SHOW_MESSAGE, "Your available prefixes are {0)}" },
                { PREFIX_SET_MESSAGE, "Your guilds prefix has been set to `{0}`" },
                { DBPURGE_SUCCESS, "Attempted to drop all data from the `{0}` table" },
                { EXEC_FOOTER_CONSTRUCTFAILED, "Failed to construct. Took {0}ms" },
                { EXEC_FOOTER_COMPILEFAILED, "Constructed in: {0}ms | Failed to compile. Took {1}ms" },
                { EXEC_FOOTER_EXECUTEFAILED, "Constructed in: {0}ms | Compiled in: {1}ms | Failed to execute. Took {2}ms" },
                { EXEC_FOOTER_SUCCESS, "Constructed in: {0}ms | Compiled in: {1}ms | Executed in: {2}ms" },
                { EXEC_INPUT_FORMAT, "```csharp\n{0}\n```" },
                { EXEC_OUTPUT_NULL, "No output from execution..." },
                { EXEC_OUTPUT_FORMAT, "Type: {0}\n```csharp\n{1)}\n```" },
                { EXEC_TITLE_EXCEPTION, ":no_entry_sign: Execution Result" },
                { EXEC_TITLE_SUCCESS, ":white_check_mark: Execution Result" },
                { SHUTDOWN_INTIME, "Shutting down in {0}" },
                { SUDOCOMMAND_SUCCESS, "Executing `{0}` as {1}" },
                { EXCEPTION_NOTFOUND, "Exception {0} has not yet occured!" },
                { EXCEPTION_MESSAGE, "Message" },
                { EXCEPTION_CHANNEL, "Channel:\n{0} ({1})" },
                { EXCEPTION_GUILD, "Guild" },
                { EXCEPTION_FULLMESSAGE, "Here is everything that was logged for exception {0}" },
                { EXCEPTION_USER, "USER:\n{0}" },
                { RELOAD_AREA_NOTFOUND, "The area `{0}` does not exist" },
                { RELOAD_SUCCESS, "Reloading {0}" },
                { RELOAD_LIST, "Here are all the areas that can be reloaded:\n{0}" },

                //General stuff

                { EMBED_FOOTER, "{0} | {1}" },
                { REPLYTYPE_SUCCESS, ":white_check_mark: **Got it!** " },
                { REPLYTYPE_ERROR, ":no_entry_sign: **Oops!** " },
                { REPLYTYPE_INFO, ":information_source: " },
                { NOTES, "Notes" },
                { GROUP, "Group" },
                { ALIASES, "Aliases" },
                { USAGE, "Usage" },
                { FLAGS, "Flags" },
                { INPUT, "Input" },
                { ERROR, "Error" },
                { OUTPUT, "Output" },
                { UNKNOWNUSER, "UNKNOWNUSER" },

                //Types

                { TIMESPAN, "a timespan" },
                { STRING, "some text" },
                { INT64, "an integer" },
                { INT32, "an integer" },
                { INT16, "an integer" },
                { UINT64, "a positive integer" },
                { UINT32, "a positive integer" },
                { UINT16, "a positive integer" },
                { DOUBLE, "a number" },
                { FLOAT, "a number" },
                { DECIMAL, "a number" },
                { BOOLEAN, "true/false" },
                { DATETIME, "a date/time" }

            };
    }
}