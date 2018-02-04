using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Connectors.Models;
using Newtonsoft.Json;
using System.Linq;
namespace Connectors.Connectors.RedisTestConnector
{
    public partial class PairTimeFrame
    {
        private void loadData()
        {
            this.history = new History();
            var indexDb = this.redis.GetDatabase(0);
            var blockDb = this.redis.GetDatabase(1);
            var symbolTimeFrame = new SymbolTimeFrame() {symbol = this.Symbol, timeFrame = this.TimeFrame};
            var key = JsonConvert.SerializeObject(symbolTimeFrame);
            var index = indexDb.StringGet(key).ToString();
            var blocks = JsonConvert.DeserializeObject<List<Block>>(index);
            foreach (Block block in blocks)
            {
                var buffer = blockDb.StringGet(block.key);
                var protoBlock = Proto.Block.Parser.ParseFrom(buffer);
                history.Time.AddRange(protoBlock.Time);
                history.Open.AddRange(protoBlock.Open);
                history.High.AddRange(protoBlock.High);
                history.Low.AddRange(protoBlock.Low);
                history.Close.AddRange(protoBlock.Close);                              
            }
        }

        public int GetEndTime()
        {
            return history.Time[history.Time.Count - 1];
        }

        public int GetStartTime()
        {
            return history.Time[0];
        }

        public bool SetTime(Int32 time)
        {
            var oldIndex = this.index;
            var quotesTimeLength = this.history.Time.Count; 
            for (var i = this.index; i < quotesTimeLength; i++) {
                if (this.history.Time[i] > time)
                    break;
                this.index = i;
            }

            return this.index != oldIndex;
        }
    }
}