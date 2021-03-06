﻿using System;
using TitanBot.Logging;

namespace LiveBaseTest
{
    class ConsoleLogger : Logger
    {
        protected override LogSeverity LogLevel => LogSeverity.Debug;

        protected override void WriteLog(ILoggable entry)
        {
            Console.WriteLine(entry);
            base.WriteLog(entry);
        }
    }
}
