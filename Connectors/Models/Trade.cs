using System;
using Shared.Enums;

namespace Connectors.Models
{
    public class Trade
    {
        public Guid id { get; set; }
        public Guid connectorId { get; set; }
        public Guid strategyId { get; set; }

        public TradeType tradeType { get; set; }
        public string symbol { get; set; }
        public double lots { get; set; }
        public int openTime { get; set; }
        public double openPrice { get; set; }
        public int closeTime { get; set; }
        public double closePrice { get; set; }
        public string closeReason { get; set; }
        
        public int trailingStopPips { get; set; }
        public double stopLossValue { get; set; }
        public double initialStopLossValue { get; set; }
        public double takeProfitValue { get; set; }
        public double profitInPips { get; set; }
    }
}