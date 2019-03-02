using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data;

namespace CryptoImporter.Markets
{


    public class Binance
    {

        public static void client_DownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Console.WriteLine(e.Result);
        }

        public static void GetMarketData()
        {

            WebClient client = new WebClient();
            QuoteInfo BinanceInfo = new QuoteInfo();

            try
            {

                // GETTING QUOTES
                string webresponse = client.DownloadString("https://binance.com/api/v1/ticker/24hr");

                JArray tmp = JArray.Parse(webresponse);

                BinanceInfo.ask = Convert.ToDouble(tmp[11]["askPrice"]);
                BinanceInfo.bid = Convert.ToDouble(tmp[11]["bidPrice"]);
                BinanceInfo.last = Convert.ToDouble(tmp[11]["lastPrice"]);
                BinanceInfo.volume = Convert.ToDouble(tmp[11]["volume"]);

                Console.WriteLine(string.Format("Binance: Ask:{0} | Bid:{1} | Last:{2} | VolumeToday:{3} | Timestamp:{4}",
                        BinanceInfo.ask, BinanceInfo.bid, BinanceInfo.last, BinanceInfo.volume, DateTime.Now));

                MySQLData.MarketData.InsertQuoteData("Binance",BinanceInfo.ask, BinanceInfo.bid, BinanceInfo.last, BinanceInfo.volume, DateTime.Now);

            }

            catch (Exception ex)
            {

            }
        }

    }



}
