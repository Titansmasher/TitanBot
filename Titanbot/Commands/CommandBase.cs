﻿using Discord.WebSocket;
using System;
using Titansmasher.Services.Database.Interfaces;
using Titansmasher.Services.Logging.Interfaces;

namespace Titanbot.Commands
{
    public abstract class CommandBase : IDisposable
    {
        #region Fields

        #region Protected

        protected internal MessageContext Context { get; internal set; }
        protected internal IDatabaseService Database { get; internal set; }
        protected internal ILoggerService Logger { get; internal set; }
        protected internal DiscordSocketClient Client { get; internal set; }

        #endregion Protected

        #endregion Fields

        #region IDisposable

        public abstract void Dispose();

        #endregion IDisposable
    }
}