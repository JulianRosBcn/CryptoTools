﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoImporter
{
    class Program
    {
        public static string mySQLServerIP = "192.168.56.50";

        static void Main(string[] args)
        {
            //Delete all existing data in DBs

            if (args.Length > 0) { mySQLServerIP = args[0];  }

            MySQLData.MarketData.RemoveQuoteData("kraken");
            MySQLData.MarketData.RemoveQuoteData("binance");
            MySQLData.MarketData.RemoveAnalyticsData("kraken");
            MySQLData.MarketData.RemoveAnalyticsData("binance");
            MySQLData.MarketData.RemoveOrdersData();

            while (true)
            { 
                Markets.Kraken.GetMarketData();
                Markets.Binance.GetMarketData();
                Thread.Sleep(3000);
            }
        }
    }
}
