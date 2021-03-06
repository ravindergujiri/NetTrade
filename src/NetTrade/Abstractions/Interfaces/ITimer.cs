﻿using NetTrade.Helpers;
using System;

namespace NetTrade.Abstractions.Interfaces
{
    public interface ITimer: IDisposable
    {
        TimeSpan Interval { get; }

        bool Enabled { get; }

        DateTimeOffset LastElapsedTime { get; }

        event OnTimerElapsedHandler OnTimerElapsedEvent;

        event OnTimerStartHandler OnTimerStartEvent;

        event OnTimerStopHandler OnTimerStopEvent;

        event OnTimerIntervalChangedHandler OnTimerIntervalChangedEvent;

        void Start();

        void Stop();

        void SetCurrentTime(DateTimeOffset currentTime);

        void SetInterval(TimeSpan interval);
    }
}