﻿using System;
using System.Collections.Generic;
using System.Text;
using NetTrade.Models;
using NetTrade.Enums;

namespace NetTrade.Interfaces
{
    public interface ISymbol
    {
        List<Bar> Data { get; set; }

        string Name { get; }

        double TickSize { get; }

        double Commission { get; }

        int Digits { get; }

        long MinVolume { get; }

        long MaxVolume { get; }

        long VolumeStep { get; }

        double Bid { get; }

        double Ask { get; }

        Bars Bars { get; }

        double GetPrice(TradeType tradeType);
    }
}
