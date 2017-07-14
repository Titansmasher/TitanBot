﻿using System;
using TitanBot;
using TitanBot.Logging;

namespace LiveBaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new BotClient(m => m.Map<ILogger, ConsoleLogger>());
            bot.CommandService.Install(bot.DefaultCommands);

            bot.StartAsync(c =>
            {
                Console.WriteLine("Please enter a bot token:");
                return Console.ReadLine();
            }).Wait();
            bot.UntilOffline.Wait();
        }

        class ConsoleLogger : Logger
        {
            protected override LogSeverity LogLevel => LogSeverity.Critical | LogSeverity.Debug | LogSeverity.Error | LogSeverity.Info | LogSeverity.Verbose;

            protected override void WriteLog(ILoggable entry)
            {
                Console.WriteLine(entry);
                base.WriteLog(entry);
            }
        }
    }
}