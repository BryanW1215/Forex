using System.ComponentModel;
using Connectors.Models;
using System.Linq;
namespace Connectors.Connectors.RedisTestConnector
{
    public partial class RedisTestConnector
    {
        public double GetAsk(string symbol)
        {
            var value = (GetPipValue(symbol) * GetSpread(symbol)) / 2;
            return GetQuote(symbol) + value;
        }
        public double GetBid(string symbol)
        {
            var value = (GetPipValue(symbol) * GetSpread(symbol)) / 2;
            return GetQuote(symbol) - value;
        }
        public double GetQuote(string symbol)
        {
            return this.pairTimeFrames.First(ptf => ptf.Symbol == symbol && ptf.TimeFrame == this.lowestTimeFrame).GetQuote();
        }
        public History GetHistory(string symbol, int timeFrame, int length)
        {
            return this.pairTimeFrames.First(ptf => ptf.Symbol == symbol && ptf.TimeFrame == timeFrame).History(length);
        }
        public double GetPipValue(string symbol)
        {
            return symbol.IndexOf("JPY") > -1 ? .01 : .0001;
        }
        public float GetSpread(string symbol)
        {
            return 3;
        }
    }
}