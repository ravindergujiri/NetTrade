﻿using System;
using System.Collections.Generic;
using System.Text;
using NetTrade.Helpers;

namespace NetTrade.Interfaces
{
    public interface IBacktester
    {
        event OnBacktestStart OnBacktestStartEvent;

        event OnBacktestPause OnBacktestPauseEvent;

        event OnBacktestStop OnBacktestStopEvent;

        event OnBacktestFinished OnBacktestFinishedEvent;

        void Start(IRobot robot);

        void Pause();

        void Stop();
    }
}
