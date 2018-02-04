using System;
using System.Diagnostics;
using System.Net.Mime;
using Connectors;
using Connectors.Connectors.RedisTestConnector;
using Connectors.Events;
using Connectors.Models;

namespace Test
{
    class ConnectorTestProgram
    {
        static void OnTick(iConnector connector, OnTickEventArgs args)
        {
            var Time = UnixTimeStampToDateTime(connector.GetTime());
            var Quote = connector.GetQuote(args.Symbol);
            Console.WriteLine(String.Format("Tick {0} {1}: {2}", Time.ToShortDateString(), Time.ToShortTimeString(), Quote));

        }
        static void OnBar(iConnector connector, OnTickEventArgs args)
        {
            var Time = UnixTimeStampToDateTime(connector.GetTime());
            var Quote = connector.GetQuote(args.Symbol);
            Console.WriteLine(String.Format("Bar {0} {1}: {2}", Time.ToShortDateString(), Time.ToShortTimeString(), Quote));

        }
        static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
            return dtDateTime;
        }/*
        static void Main(string[] args)
        {
            SymbolTimeFrame[] symbolTimeFrames = {new SymbolTimeFrame {symbol = "EURUSD", timeFrame =15}, new SymbolTimeFrame {symbol = "EURUSD", timeFrame =60}};
            RedisTestConnector connector = new RedisTestConnector("192.168.1.8", symbolTimeFrames);
            //connector.OnTick += new OnTickEventHandler(OnTick);
            //connector.OnBar += new OnTickEventHandler(OnBar);
            var done = false;
            while (!done)
            {
                done = !connector.Next();
            }
            Environment.Exit(0);
        }
        */
    }
}