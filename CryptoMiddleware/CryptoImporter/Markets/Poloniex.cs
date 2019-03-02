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


    public class Poloniex
    {

        public static void client_DownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Console.WriteLine(e.Result);
        }

        public static void GetMarketData()
        {

            WebClient client = new WebClient();
            QuoteInfo PoloniexInfo = new QuoteInfo();

            try
            {

                // GETTING QUOTES
                string webresponse = client.DownloadString("https://poloniex.com/public?command=returnTicker");

                JObject tmp = JObject.Parse(webresponse);

                PoloniexInfo.ask = Convert.ToDouble(tmp["USDT_BTC"]["lowestAsk"]);
                PoloniexInfo.bid = Convert.ToDouble(tmp["USDT_BTC"]["highestBid"]);
                PoloniexInfo.last = Convert.ToDouble(tmp["USDT_BTC"]["last"]);
                PoloniexInfo.volume = Convert.ToDouble(tmp["USDT_BTC"]["quoteVolume"]);

                Console.WriteLine(string.Format("POLONIEX: Ask:{0} | Bid:{1} | Last:{2} | VolumeToday:{3} | Timestamp:{4}",
                        PoloniexInfo.ask, PoloniexInfo.bid, PoloniexInfo.last, PoloniexInfo.volume, DateTime.Now));

                MySQLData.MarketData.InsertQuoteData("poloniex",PoloniexInfo.ask, PoloniexInfo.bid, PoloniexInfo.last, PoloniexInfo.volume, DateTime.Now);

            }

            catch (Exception ex)
            {

            }
        }

    }



}
