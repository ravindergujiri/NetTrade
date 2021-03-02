﻿using System;
using System.Collections.Generic;

namespace NetTrade.Abstractions.Interfaces
{
    public interface IBacktestResult
    {
        List<ITrade> Trades { get; set; }

        long TotalTradesNumber { get; }

        long LongTradesNumber { get; }

        long ShortTradesNumber { get; }

        double MaxBalanceDrawdown { get; }

        double MaxEquityDrawdown { get; }

        double WinningRate { get; }

        double NetProfit { get; }

        double ProfitFactor { get; }

        double Commission { get; }

        double SharpeRatio { get; }

        double SortinoRatio { get; }

        double AverageProfit { get; }

        double AverageLoss { get; }

        double AverageReturn { get; }

        TimeSpan AverageTradeDuration { get; }

        double AverageBarsPeriod { get; }
    }
}