using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Delete all existing data in DBs

            //Kraken.RemoveQuoteData();
            //Kraken.RemoveIndicatorsData();
            //Kraken.RemoveAlarmsData();
            //Kraken.RemoveOrdersData();

            while (true)
            { 
                Markets.Kraken.GetMarketData();
                Markets.Poloniex.GetMarketData();
                Markets.Binance.GetMarketData();
                Thread.Sleep(3000);
            }
        }
    }
}
