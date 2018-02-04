using System;
using Connectors.Models;
using Shared.Enums;

namespace Connectors.Events
{
    public delegate void OnTradeEventHandler(iConnector connector, OnTradeEventArgs e);

    public class OnTradeEventArgs: EventArgs
    {
        public Trade Trade { get; set; }
        public OnTradeEventArgs(Trade trade)
        {
            this.Trade = trade;
        }
    }
}