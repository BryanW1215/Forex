using System;
using System.Collections.Generic;
using System.Dynamic;
using Connectors.Events;
using Connectors.Models;
using StackExchange.Redis;

namespace Connectors.Connectors.RedisTestConnector
{
    public partial class RedisTestConnector : iConnector
    {
        private ConnectionMultiplexer redis { get; set; }
        private List<PairTimeFrame> pairTimeFrames { get; set; }
        private int startTime { get; set; }
        private int time { get; set; }
        private int endTime { get; set; }
        private int highestTimeFrame { get; set; }
        private int lowestTimeFrame { get; set; }
        private List<Trade> trades { get; set; }

        public RedisTestConnector(string redisConnectionString, SymbolTimeFrame[] symbols)
        {
            this.redis = ConnectionMultiplexer.Connect(redisConnectionString);
            this.loadPairTimeFrames(symbols);
            this.trades = new List<Trade>();
        }

        private bool end()
        {
            var localTrades = trades.ToArray();
            foreach (var trade in localTrades)
                CloseTrade(trade, "SimulationEnd");                
            return false;
        }
        public bool Next()
        {
            this.time += this.lowestTimeFrame * 60;
            if (this.time > this.endTime)
                return this.end();

            var pairTimeFrameEvents = new List<PairTimeFrame>();
            foreach (var pairTimeFrame in pairTimeFrames)
            {
                var hasEvent = pairTimeFrame.SetTime(this.time);
                if (hasEvent)
                    pairTimeFrameEvents.Add(pairTimeFrame);
            }

            this.checkStopLossAndTakeProfits();
            foreach (var pairTimeFrame in pairTimeFrameEvents)
            {
                var eventArgs = new OnTickEventArgs(pairTimeFrame.Symbol, pairTimeFrame.TimeFrame);

                if (pairTimeFrame.TimeFrame == this.lowestTimeFrame && this.OnTick != null)
                    this.OnTick(this, eventArgs);
                if(this.OnBar != null)
                    this.OnBar(this, eventArgs);
            }

            return true;
        }

        public int GetTime()
        {
            return this.time;
        }

        public event OnTickEventHandler OnBar;
        public event OnTickEventHandler OnTick;
    }
}