using System.ComponentModel;
using Connectors;
using Connectors.Models;
using Shared.Enums;

namespace Strategies.IndicatorBased
{
    public class Stochastic : StrategyBase
    {
        public Stochastic(iConnector connector, SymbolTimeFrame symbolTimeFrame) : base(connector, symbolTimeFrame)
        {
        }

        protected override void onBar()
        {
            var history = base.history(100);
            var stochastic = TALib.Oscillators.Stochastic(history.High.ToArray(), history.Low.ToArray(),
                history.Close.ToArray(), 16, 5, 3);
            var LongEntry = false;
            var ShortEntry = false;
            if (stochastic.slowD < 30 && stochastic.slowK < 30)
            {
                LongEntry = stochastic.slowK > stochastic.slowD;
            }

            if (stochastic.slowD > 70 && stochastic.slowK > 70)
            {
                ShortEntry = stochastic.slowK < stochastic.slowD;
            }

            if (!ShortEntry && !LongEntry)
                return;
            var tradeType = LongEntry ? TradeType.Long : TradeType.Short;
            openTrade(tradeType, 5, 20, 5);
        }
    }
}