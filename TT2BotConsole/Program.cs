﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanBotBase.Logger;
using TitanBotBase.Util;
using TT2BotCore;

namespace TT2BotConsole
{
    class Program
    {
        static void Main(string[] args)
            => new Program().Start().GetAwaiter().GetResult();

        public async Task Start()
        {
            var client = new TT2BotClient(f => f.Map<ILogger, Logger>());
            await client.StartAsync();

            await Task.Delay(-1);
        }
    }
}