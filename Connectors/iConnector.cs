using System;
using System.Collections.Generic;
using Connectors.Events;
using Connectors.Models;
using Shared;
using Shared.Enums;

namespace Connectors
{
    public interface iConnector
    {
        double GetQuote(string symbol);
        double GetAsk(string symbol);
        double GetBid(string symbol);
        History GetHistory(string symbol, int timeFrame, int length);
        double GetPipValue(string symbol);
        int GetTime();
        Trade OpenTrade(string symbol, TradeType direction, Guid strategyId,int stopLoss, int takeProfit, int trailingStop);
        Trade CloseTrade(Trade trade, string reason);
        List<Trade> GetTrades();
        event OnTradeEventHandler OnTradeOpen;
        event OnTradeEventHandler OnTradeClose;
        event OnTickEventHandler OnBar;
        event OnTickEventHandler OnTick;
    }
}