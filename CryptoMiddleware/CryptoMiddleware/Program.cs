using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoMiddleware
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            { 
                KrakenFunctions.GetKrakenMarketData();
                Thread.Sleep(5000);
            }
        }
    }
}
