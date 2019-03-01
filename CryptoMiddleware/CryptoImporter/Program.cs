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

            KrakenData.RemoveQuoteData();
            KrakenData.RemoveIndicatorsData();
            KrakenData.RemoveAlarmsData();
            KrakenData.RemoveOrdersData();

            while (true)
            { 
                KrakenFunctions.GetKrakenMarketData();
                Thread.Sleep(3000);
            }
        }
    }
}
