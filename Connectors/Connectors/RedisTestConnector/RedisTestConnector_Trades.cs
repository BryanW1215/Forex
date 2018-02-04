using System;
using System.Collections.Generic;
using Connectors.Events;
using Connectors.Models;
using Shared.Enums;

namespace Connectors.Connectors.RedisTestConnector
{
    public partial class RedisTestConnector
    {
        public Trade OpenTrade(string symbol, TradeType direction, Guid strategyId, int stopLoss, int takeProfit,
            int trailingStop)
        {
            var trade = new Trade()
            {
                id = new Guid(),
                strategyId = strategyId,
                symbol = symbol,
                tradeType = direction,
                openTime = this.time,
                trailingStopPips = trailingStop
            };
            this.trades.Add(trade);
            this.setStopLossAndTakeProfit(trade, stopLoss, takeProfit);
            if (trade.tradeType == TradeType.Long)
                trade.openPrice = GetAsk(trade.symbol);
            else
                trade.openPrice = GetBid(trade.symbol);

            var tradeEventArg = new OnTradeEventArgs(trade);
            if (this.OnTradeOpen != null)
                OnTradeOpen(this, tradeEventArg);
            return trade;
        }

        public Trade CloseTrade(Trade trade, string reason)
        {
            trade.closeReason = reason;
            trade.closeTime = this.time;
            if (trade.tradeType == TradeType.Long)
                trade.closePrice = GetBid(trade.symbol);
            else
                trade.closePrice = GetAsk(trade.symbol);
            this.trades.Remove(trade);
            trade.profitInPips = ((trade.closePrice - trade.openPrice) * (int) trade.tradeType) /
                                 GetPipValue(trade.symbol);
            
            var tradeEventArg = new OnTradeEventArgs(trade);
            if(this.OnTradeClose != null)
                OnTradeClose(this, tradeEventArg);
            return trade;
        }

        public List<Trade> GetTrades()
        {
            return trades;
        }

        public event OnTradeEventHandler OnTradeOpen;
        public event OnTradeEventHandler OnTradeClose;
    }
}