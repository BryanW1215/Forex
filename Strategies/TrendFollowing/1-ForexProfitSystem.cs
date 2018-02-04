using System;
using System.ComponentModel;
using System.Diagnostics;
using Connectors;
using Connectors.Connectors.RedisTestConnector;
using Connectors.Models;
using Shared.Enums;
using TicTacTec.TA.Library;

namespace Strategies.TrendFollowing
{
    public class ForexProfitSystem : StrategyBase
    {
        public static bool isProfitable = false;
        public ForexProfitSystem(iConnector connector, SymbolTimeFrame symbolTimeFrame) : base(connector,
            symbolTimeFrame)
        {
            this.strategyId = Guid.Parse("78f64603-fe88-4a53-ab88-97e9902c3694");
        }

        protected override void onBar()
        {
            var history = base.history(100);
            double ema10 = TALib.OverlapStudies.MovingAverage(history.Close.ToArray(), 10, Core.MAType.Ema);
            double ema25 = TALib.OverlapStudies.MovingAverage(history.Close.ToArray(), 25, Core.MAType.Ema);
            double ema50 = TALib.OverlapStudies.MovingAverage(history.Close.ToArray(), 50, Core.MAType.Ema);
            double sar = TALib.OverlapStudies.SAR(history.High.ToArray(), history.Low.ToArray());

            var quote = getQuote();
            bool LongEntry = ema10 > ema25 && ema10 > ema50 && sar < quote;
            bool ShortEntry = ema10 < ema25 && ema10 < ema50 && sar > quote;
            bool LongExit = quote < ema10 && quote < ema25 && quote < ema50;
            bool ShortExit = quote > ema10 && quote > ema25 && quote > ema50;

            if ((LongEntry || ShortEntry) && this.isTradeOpen == false)
            {
                var stopLoss = LongEntry ? getQuote() - ema50 : ema50 - getQuote();
                
                var direction = LongEntry ? TradeType.Long : TradeType.Short;
                int pipStopLoss = (int) Math.Floor(stopLoss / getPipValue());
                pipStopLoss += 5;
                this.openTrade(direction, pipStopLoss, 0, 0);
                return;
            }
            if(!this.isTradeOpen)
                return;
            if((trade.tradeType == TradeType.Long && LongExit) || (trade.tradeType == TradeType.Short && ShortExit))
                this.closeTrade("StrategyExit");
            
        }

        protected override void onTick()
        {
        }
    }
}