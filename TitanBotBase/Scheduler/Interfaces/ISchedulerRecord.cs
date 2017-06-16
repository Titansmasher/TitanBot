﻿using System;

namespace TitanBotBase.Scheduler
{
    public interface ISchedulerRecord
    {
        bool Complete { get; set; }
        string Data { get; set; }
        DateTime EndTime { get; set; }
        ulong? GuildId { get; set; }
        ulong Id { get; set; }
        TimeSpan Interval { get; set; }
        DateTime StartTime { get; set; }
        ulong UserId { get; set; }
    }
}