using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using Connectors;
using Connectors.Connectors.RedisTestConnector;
using Connectors.Events;
using Connectors.Models;

namespace Test
{
    class StrategyTestProgram
    {
        private static List<Trade> trades { get; set; }

        static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        static void TradeClose(iConnector connector, OnTradeEventArgs args)
        {
            trades.Add(args.Trade);
        }

        static void Main(string[] args)
        {
            trades = new List<Trade>();
            SymbolTimeFrame[] symbolTimeFrames =
            {
                new SymbolTimeFrame {symbol = "EURUSD", timeFrame = 15},
                new SymbolTimeFrame {symbol = "EURUSD", timeFrame = 60}
            };
            RedisTestConnector connector = new RedisTestConnector("192.168.1.8", symbolTimeFrames);
            var Strategy = new Strategies.TrendFollowing.ForexProfitSystem(connector,
                new SymbolTimeFrame() {symbol = "EURUSD", timeFrame = 60});
            //var Strategy = new Strategies.IndicatorBased.Stochastic(connector,
            //    new SymbolTimeFrame() {symbol = "EURUSD", timeFrame = 240});
            connector.OnTradeClose += new OnTradeEventHandler(TradeClose);
            var done = false;
            while (!done)
            {
                done = !connector.Next();
            }

            var totalProfit = trades.Sum(t => t.profitInPips);
            var StopLoss = trades.Where(t => t.closeReason == "StopLoss").ToList();
            var StrategyExit = trades.Where(t => t.closeReason == "StrategyExit").ToList();
            var takeProfit = trades.Where(t => t.closeReason == "TakeProfit").ToList();
            Environment.Exit(0);
        }
    }
}