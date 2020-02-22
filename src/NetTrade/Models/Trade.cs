﻿using NetTrade.Abstractions.Interfaces;
using System;

namespace NetTrade.Models
{
    public class Trade : ITrade
    {
        public Trade(MarketOrder order, DateTimeOffset exitTime, double exitPrice, double equity, double balance,
            double sharpeRatio, double sortinoRatio)
        {
            Order = order;

            ExitTime = exitTime;

            ExitPrice = exitPrice;

            Equity = equity;

            Balance = balance;

            SharpeRatio = sharpeRatio;

            SortinoRatio = sortinoRatio;
        }

        public MarketOrder Order { get; }

        public DateTimeOffset ExitTime { get; }

        public double ExitPrice { get; }

        public double Equity { get; }

        public double Balance { get; }

        public double SharpeRatio { get; }

        public double SortinoRatio { get; }

        public TimeSpan Duration => Order != null ? ExitTime - Order.OpenTime : TimeSpan.FromSeconds(0);
    }
}