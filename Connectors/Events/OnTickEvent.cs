using System;

namespace Connectors.Events
{
    public delegate void OnTickEventHandler(iConnector sender, OnTickEventArgs e);

    public class OnTickEventArgs: EventArgs
    {
        public string Symbol { get; set; }
        public int timeFrame { get; set; }
        public OnTickEventArgs(string symbol, int timeFrame)
        {
            this.Symbol = symbol;
            this.timeFrame = timeFrame;            
        }
    }
}