using System;
using Connectors.Models;
using StackExchange.Redis;

namespace Connectors.Connectors.RedisTestConnector
{
    public partial class PairTimeFrame
    {
        public string Symbol;
        public int TimeFrame;
        public int index = 0;
        private ConnectionMultiplexer redis { get; set; }
        private History history;
        public PairTimeFrame(ConnectionMultiplexer redis, string symbol, int timeFrame)
        {
            this.Symbol = symbol;
            this.TimeFrame = timeFrame;
            this.redis = redis;
            this.loadData();
        }

        public History History(int length)
        {
            var start = this.index - length +1;            
            return new History()
            {
                Time = this.history.Time.GetRange(start, length),
                Open = this.history.Open.GetRange(start, length),
                High = this.history.High.GetRange(start, length),
                Low = this.history.Low.GetRange(start, length),
                Close = this.history.Close.GetRange(start, length)                
            };
        }
        public double GetQuote()
        {
            return this.history.Close[this.index];
        }
        
    }
}