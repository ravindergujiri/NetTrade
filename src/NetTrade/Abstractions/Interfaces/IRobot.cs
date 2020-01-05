﻿using NetTrade.Enums;
using System;

namespace NetTrade.Abstractions.Interfaces
{
    public interface IRobot
    {
        IRobotSettings Settings { get; }

        RunningMode RunningMode { get; }

        void Start();

        void Stop();

        void Pause();

        void Resume();

        void OnStart();

        void OnPause();

        void OnResume();

        void OnStop();

        void OnBar(ISymbol symbol, int index);

        void OnTick(ISymbol symbol);

        void SetTimeByBacktester(IBacktester backtester, DateTimeOffset time);
    }
}