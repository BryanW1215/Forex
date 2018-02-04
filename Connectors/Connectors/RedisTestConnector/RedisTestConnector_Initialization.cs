using System;
using System.Collections.Generic;
using Connectors.Models;

namespace Connectors.Connectors.RedisTestConnector
{
    public partial class RedisTestConnector
    {
        
        private void loadPairTimeFrames(SymbolTimeFrame[] symbolTimeFrames)
        {
            this.pairTimeFrames = new List<PairTimeFrame>();
            foreach (SymbolTimeFrame symbolTimeFrame in symbolTimeFrames)
            {
                this.pairTimeFrames.Add(new PairTimeFrame(this.redis, symbolTimeFrame.symbol, symbolTimeFrame.timeFrame));
            }
            this.startTime = Int32.MinValue;
            this.endTime = Int32.MaxValue;
            this.highestTimeFrame = Int32.MinValue;
            this.lowestTimeFrame = Int32.MaxValue;            
            foreach (var pairTimeFrame in this.pairTimeFrames)
            {
                this.startTime = Math.Max(this.startTime, pairTimeFrame.GetStartTime());
                this.endTime = Math.Min(this.endTime, pairTimeFrame.GetEndTime());
                this.lowestTimeFrame = Math.Min(this.lowestTimeFrame, pairTimeFrame.TimeFrame);
                this.highestTimeFrame = Math.Max(this.highestTimeFrame, pairTimeFrame.TimeFrame);
            }
            this.startTime += this.highestTimeFrame * 150 * 60;
            this.time = this.startTime;
        }
    }
}