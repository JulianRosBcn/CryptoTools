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
    

    public class Kraken
    {

        public static void client_DownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Console.WriteLine(e.Result);
        }

        public static void GetMarketData()
        {

            WebClient client = new WebClient();
            QuoteInfo krakenInfo = new QuoteInfo();
            string webresponse;
            JObject tmp;

            try
            {
                // GETTING QUOTES BTCUSD
                webresponse = client.DownloadString("https://api.kraken.com/0/public/Ticker?pair=XBTUSD");
                
                tmp = JObject.Parse(webresponse);

                krakenInfo.market = "kraken";
                krakenInfo.coinpair = "btcusd";
                krakenInfo.ask = Convert.ToDouble(tmp["result"]["XXBTZUSD"]["a"][0]);
                krakenInfo.bid = Convert.ToDouble(tmp["result"]["XXBTZUSD"]["b"][0]);
                krakenInfo.last = Convert.ToDouble(tmp["result"]["XXBTZUSD"]["c"][0]);
                krakenInfo.volume = Convert.ToDouble(tmp["result"]["XXBTZUSD"]["c"][1]);

                Console.WriteLine(string.Format("KRAKEN BTCUSD: Ask:{0} | Bid:{1} | Last:{2} | VolumeToday:{3} | Timestamp:{4}",
                        krakenInfo.ask.ToString(), krakenInfo.bid.ToString(), krakenInfo.last.ToString(), krakenInfo.volume.ToString(), DateTime.Now.ToUniversalTime()));

                MySQLData.MarketData.InsertQuoteData(krakenInfo.market, krakenInfo.coinpair, krakenInfo.ask, krakenInfo.bid, krakenInfo.last, krakenInfo.volume, DateTime.Now.ToUniversalTime());

                // GETTING QUOTES BTCLTC
                webresponse = client.DownloadString("https://api.kraken.com/0/public/Ticker?pair=LTCXBT");

                tmp = JObject.Parse(webresponse);

                krakenInfo.market = "kraken";
                krakenInfo.coinpair = "btcltc";
                krakenInfo.ask = Convert.ToDouble(tmp["result"]["XLTCXXBT"]["a"][0]);
                krakenInfo.bid = Convert.ToDouble(tmp["result"]["XLTCXXBT"]["b"][0]);
                krakenInfo.last = Convert.ToDouble(tmp["result"]["XLTCXXBT"]["c"][0]);
                krakenInfo.volume = Convert.ToDouble(tmp["result"]["XLTCXXBT"]["c"][1]);

                Console.WriteLine(string.Format("KRAKEN BTCLTC: Ask:{0} | Bid:{1} | Last:{2} | VolumeToday:{3} | Timestamp:{4}",
                        krakenInfo.ask.ToString(), krakenInfo.bid.ToString(), krakenInfo.last.ToString(), krakenInfo.volume.ToString(), DateTime.Now.ToUniversalTime()));

                MySQLData.MarketData.InsertQuoteData(krakenInfo.market, krakenInfo.coinpair, krakenInfo.ask, krakenInfo.bid, krakenInfo.last, krakenInfo.volume, DateTime.Now.ToUniversalTime());

                // GETTING QUOTES BTCETH
                webresponse = client.DownloadString("https://api.kraken.com/0/public/Ticker?pair=ETHXBT");

                tmp = JObject.Parse(webresponse);

                krakenInfo.market = "kraken";
                krakenInfo.coinpair = "btceth";
                krakenInfo.ask = Convert.ToDouble(tmp["result"]["XETHXXBT"]["a"][0]);
                krakenInfo.bid = Convert.ToDouble(tmp["result"]["XETHXXBT"]["b"][0]);
                krakenInfo.last = Convert.ToDouble(tmp["result"]["XETHXXBT"]["c"][0]);
                krakenInfo.volume = Convert.ToDouble(tmp["result"]["XETHXXBT"]["c"][1]);

                Console.WriteLine(string.Format("KRAKEN BTCETH: Ask:{0} | Bid:{1} | Last:{2} | VolumeToday:{3} | Timestamp:{4}",
                        krakenInfo.ask.ToString(), krakenInfo.bid.ToString(), krakenInfo.last.ToString(), krakenInfo.volume.ToString(), DateTime.Now.ToUniversalTime()));

                MySQLData.MarketData.InsertQuoteData(krakenInfo.market, krakenInfo.coinpair, krakenInfo.ask, krakenInfo.bid, krakenInfo.last, krakenInfo.volume, DateTime.Now.ToUniversalTime());

            }

            catch (Exception ex)
            {
               
            }
        }

    }


}
