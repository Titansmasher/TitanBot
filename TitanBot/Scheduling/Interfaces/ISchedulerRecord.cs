﻿using System;

namespace TitanBot.Scheduling
{
    public interface ISchedulerRecord
    {
        bool IsComplete { get; }
        string Data { get; set; }
        DateTime? CompleteTime { get; set; }
        DateTime EndTime { get; set; }
        ulong? GuildId { get; set; }
        ulong Id { get; set; }
        TimeSpan Interval { get; set; }
        DateTime StartTime { get; set; }
        ulong UserId { get; set; }
        ulong? MessageId { get; set; }
        ulong? ChannelId { get; set; }
        string Callback { get; set; }
    }
}