using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Connectors.Models;
using Shared.Enums;

namespace Connectors.Connectors.RedisTestConnector
{
    public partial class RedisTestConnector
    {
        private void checkStopLossAndTakeProfits()
        {
            var localTrades = trades.ToArray();
            foreach(var trade in localTrades){
                var result = this.checkStopLossAndTakeProfit(trade);
                if (result != "")
                    this.CloseTrade(trade, result);
            }
        }

        private string checkStopLossAndTakeProfit(Trade trade)
        {
            this.adjustTrailingStop(trade);
            var quote = this.GetQuote(trade.symbol);
            if (trade.stopLossValue != 0)
            {
                if ((trade.tradeType == TradeType.Long && quote < trade.stopLossValue) ||
                    (trade.tradeType == TradeType.Short && quote > trade.stopLossValue))
                    return "StopLoss";
            }

            if (trade.takeProfitValue != 0)
            {
                if ((trade.tradeType == TradeType.Long && quote > trade.takeProfitValue) ||
                    (trade.tradeType == TradeType.Short && quote < trade.takeProfitValue))
                    return "TakeProfit";                
            }

            return "";
        }


        private void adjustTrailingStop(Trade trade)
        {
            if (trade.trailingStopPips == 0)
                return;
            var stopLossValue = getRelativePrice(trade.symbol, (int) trade.tradeType * -1, trade.trailingStopPips);
            if (trade.tradeType == TradeType.Long)
                Math.Max(trade.stopLossValue, stopLossValue);
            else
                Math.Min(trade.stopLossValue, stopLossValue);
        }

        private void setStopLossAndTakeProfit(Trade trade, int stopLoss, int takeProfit)
        {
            trade.stopLossValue = 0;
            trade.takeProfitValue = 0;
            if (takeProfit != 0)
                trade.takeProfitValue = getRelativePrice(trade.symbol, (int) trade.tradeType, takeProfit);
            if (stopLoss != 0)
                trade.stopLossValue = getRelativePrice(trade.symbol, (int) trade.tradeType * -1, stopLoss);
            trade.initialStopLossValue = trade.stopLossValue;
            this.adjustTrailingStop(trade);
        }

        private double getRelativePrice(string symbol, int direction, int pips)
        {
            return this.GetQuote(symbol) + (direction * this.GetPipValue(symbol) * pips);
        }
    }
}