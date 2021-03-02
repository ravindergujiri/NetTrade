﻿using NetTrade.Abstractions.Interfaces;
using System;
using System.Collections.Generic;

namespace NetTrade.Models
{
    public class BacktestResult : IBacktestResult
    {
        public List<ITrade> Trades { get; set; }

        public long TotalTradesNumber { get; set; }

        public long LongTradesNumber { get; set; }

        public long ShortTradesNumber { get; set; }

        public double MaxBalanceDrawdown { get; set; }

        public double MaxEquityDrawdown { get; set; }

        public double WinningRate { get; set; }

        public double NetProfit { get; set; }

        public double ProfitFactor { get; set; }

        public double Commission { get; set; }

        public double SharpeRatio { get; set; }

        public double SortinoRatio { get; set; }

        public double AverageProfit { get; set; }

        public double AverageLoss { get; set; }

        public double AverageReturn { get; set; }

        public TimeSpan AverageTradeDuration { get; set; }

        public double AverageBarsPeriod { get; set; }
    }
}