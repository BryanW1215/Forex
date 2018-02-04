using System;
using Connectors;
using Connectors.Events;
using Connectors.Models;
using Shared.Enums;

namespace Strategies
{
    public class StrategyBase
    {
        protected Guid strategyId { get; set; }
        protected iConnector connector { get; set; }
        protected SymbolTimeFrame symbolTimeFrame { get; set; }
        protected Trade trade { get; set; }
        protected bool isTradeOpen { get; set; } = false;
        protected StrategyBase(iConnector connector, SymbolTimeFrame symbolTimeFrame)
        {
            this.connector = connector;
            this.symbolTimeFrame = symbolTimeFrame;
            this.connector.OnBar += new OnTickEventHandler(onBarHandler);
            this.connector.OnTick += new OnTickEventHandler(onTickHandler);
            this.connector.OnTradeClose += new OnTradeEventHandler(OnTradeClose);
        }
        private void onBarHandler(iConnector connector, OnTickEventArgs args)
        {
            if (args.Symbol != this.symbolTimeFrame.symbol && args.timeFrame != this.symbolTimeFrame.timeFrame)
                return;
            this.onBar();
        }
        private void onTickHandler(iConnector connector, OnTickEventArgs args)
        {
            if (args.Symbol != this.symbolTimeFrame.symbol)
                return;
            this.onTick();
        }
        protected double getQuote()
        {
            return connector.GetQuote(this.symbolTimeFrame.symbol);
        }
        protected History history(int length)
        {
            return connector.GetHistory(this.symbolTimeFrame.symbol, this.symbolTimeFrame.timeFrame, length);
        }

        protected double getPipValue()
        {
            return this.connector.GetPipValue(this.symbolTimeFrame.symbol);
        }
        protected void OnTradeClose(iConnector connector, OnTradeEventArgs args)
        {
            if (!this.isTradeOpen || args.Trade.id != this.trade.id)
                return;
            this.isTradeOpen = false;           
        }        
        protected virtual void onBar()
        {
            
        }
        protected virtual void onTick()
        {
            
        }
        protected void openTrade(TradeType direction, int stopLoss, int takeProfit, int trailingStop)
        {
            this.trade = connector.OpenTrade(this.symbolTimeFrame.symbol, direction, this.strategyId, stopLoss,
                takeProfit, trailingStop);
            this.isTradeOpen = true;
        }
        protected void closeTrade(string reason)
        {
            connector.CloseTrade(this.trade, reason);
            this.isTradeOpen = false;
        }
    }
}