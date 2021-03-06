﻿using NetTrade.Abstractions.Interfaces;
using NetTrade.Enums;
using System.Collections.Generic;

namespace NetTrade.Models
{
    public class RobotParameters : IRobotParameters
    {
        public Mode Mode { get; set; }

        public IEnumerable<ISymbol> Symbols { get; set; }

        public IBacktester Backtester { get; set; }

        public IBacktestSettings BacktestSettings { get; set; }

        public IAccount Account { get; set; }

        public ITradeEngine TradeEngine { get; set; }

        public IServer Server { get; set; }

        public ITimerContainer TimerContainer { get; set; }
        public IEnumerable<ISymbolBacktestData> SymbolsBacktestData { get; set; }
    }
}