﻿using NetTrade.Interfaces;

namespace NetTrade.Implementations
{
    public class BacktestResult : IBacktestResult
    {
        public long TotalTradesNumber { get; set; }

        public long LongTradesNumber { get; set; }

        public long ShortTradesNumber { get; set; }

        public double MaxBalanceDrawdown { get; set; }

        public double MaxEquityDrawdown { get; set; }

        public double WinningRate { get; set; }

        public double NetProfit { get; set; }

        public double ProfitFactor { get; set; }
    }
}