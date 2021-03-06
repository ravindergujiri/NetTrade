﻿using NetTrade.Enums;
using NetTrade.Helpers;
using System;

namespace NetTrade.Abstractions.Interfaces
{
    public interface ISymbol : IEquatable<ISymbol>, ICloneable
    {
        string Name { get; }

        double TickSize { get; }

        double TickValue { get; }

        double Commission { get; }

        int Digits { get; }

        double MinVolume { get; }

        double MaxVolume { get; }

        double VolumeStep { get; }

        double VolumeUnitValue { get; }

        double Bid { get; }

        double Ask { get; }

        IBars Bars { get; }

        double Slippage { get; }

        double Spread { get; }

        event OnTickHandler RobotOnTickEvent;

        event OnBarHandler RobotOnBarEvent;

        event OnTickHandler IndicatorOnTickEvent;

        event OnBarHandler IndicatorOnBarEvent;

        double GetPrice(TradeType tradeType);
    }
}