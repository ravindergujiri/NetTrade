﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTrade.TradeEngines;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NetTrade.Abstractions.Interfaces;
using NetTrade.Models;
using NetTrade.Enums;
using System.Linq;
using NetTrade.Accounts;
using NetTrade.Symbols;

namespace NetTrade.TradeEngines.Tests
{
    [TestClass()]
    public class BacktestTradeEngineTests
    {
        private readonly BacktestTradeEngine _tradeEngine;

        private readonly ISymbol _symbol;

        public BacktestTradeEngineTests()
        {
            var server = new Server();

            var account = new BacktestAccount(1, 1, "Demo", 500, "Tester");

            account.AddTransaction(new Transaction(10000, DateTimeOffset.Now, string.Empty));

            var barsMock = new Mock<IBars>();

            barsMock.SetReturnsDefault<ISeries<DateTimeOffset>>(new Collections.ExpandableSeries<DateTimeOffset>());
            barsMock.SetReturnsDefault<ISeries<double>>(new Collections.ExpandableSeries<double>());

            _symbol = new OhlcSymbol(barsMock.Object)
            {
                Digits = 5,
                TickSize = 0.00001,
                TickValue = 1,
                VolumeStep = 1000,
                MaxVolume = 100000000,
                MinVolume = 1000,
                VolumeUnitValue = 1,
                Commission = 1,
                Name = "EURUSD",
                Slippage = 0.0001
            };

            _tradeEngine = new BacktestTradeEngine(server, account);
        }

        [TestMethod()]
        public void BacktestTradeEngineTest()
        {
            Assert.IsNotNull(_tradeEngine);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            var orderParameters = new MarketOrderParameters(_symbol)
            {
                Volume = 1000,
                TradeType = TradeType.Buy,
                StopLossInTicks = 5,
                TakeProfitInTicks = 5,
            };

            var result = _tradeEngine.Execute(orderParameters);

            Assert.IsTrue(result.IsSuccessful);
        }

        [TestMethod()]
        public void UpdateSymbolOrdersTest()
        {
            (_symbol as OhlcSymbol).PublishBar(new Bar(DateTimeOffset.Now, 0.9, 1, 1, 0.95, 1000));

            var orderParameters = new MarketOrderParameters(_symbol)
            {
                Volume = 1000,
                TradeType = TradeType.Buy,
                StopLossInTicks = 5,
                TakeProfitInTicks = 5,
            };

            var result = _tradeEngine.Execute(orderParameters);

            Assert.IsTrue(result.IsSuccessful);
            Assert.IsTrue(_tradeEngine.Orders.Contains(result.Order));

            (_symbol as OhlcSymbol).PublishBar(new Bar(DateTimeOffset.Now, 0.95, 1, 0.8, 0.87, 1000));

            _tradeEngine.UpdateSymbolOrders(_symbol);

            Assert.IsTrue(!_tradeEngine.Orders.Contains(result.Order));
        }

        [TestMethod()]
        public void CloseMarketOrderTest()
        {
            var orderParameters = new MarketOrderParameters(_symbol)
            {
                Volume = 1000,
                TradeType = TradeType.Buy,
                StopLossInTicks = 5,
                TakeProfitInTicks = 5,
            };

            var result = _tradeEngine.Execute(orderParameters);

            Assert.IsTrue(result.IsSuccessful);
            Assert.IsTrue(_tradeEngine.Orders.Contains(result.Order));

            _tradeEngine.CloseMarketOrder(result.Order as MarketOrder);

            Assert.IsTrue(!_tradeEngine.Orders.Contains(result.Order));
        }

        [TestMethod()]
        public void CancelPendingOrderTest()
        {
            (_symbol as OhlcSymbol).PublishBar(new Bar(DateTimeOffset.Now, 1, 1, 1, 1.5, 1000));

            var orderParameters = new PendingOrderParameters(OrderType.Limit, _symbol)
            {
                Volume = 1000,
                TargetPrice = 1,
                TradeType = TradeType.Buy,
                StopLossPrice = .95,
                TakeProfitPrice = 1.05,
            };

            var result = _tradeEngine.Execute(orderParameters);

            Assert.IsTrue(result.IsSuccessful);
            Assert.IsTrue(_tradeEngine.Orders.Contains(result.Order));

            _tradeEngine.CancelPendingOrder(result.Order as PendingOrder);

            Assert.IsTrue(!_tradeEngine.Orders.Contains(result.Order));
        }
    }
}