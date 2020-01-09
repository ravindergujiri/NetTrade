﻿using NetTrade.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetTrade.Models
{
    public class SymbolBacktestData : ISymbolBacktestData
    {
        private readonly IEnumerable<IBar> _data;

        public SymbolBacktestData(ISymbol symbol, IEnumerable<IBar> data)
        {
            Symbol = symbol;

            _data = data.ToList();
        }

        public ISymbol Symbol { get; }

        public IBar GetBar(DateTimeOffset time) => _data.FirstOrDefault(iBar => iBar.Time == time);
    }
}