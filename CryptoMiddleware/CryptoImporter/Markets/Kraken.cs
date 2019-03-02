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

            try
            {

                // GETTING QUOTES
                string webresponse = client.DownloadString("https://api.kraken.com/0/public/Ticker?pair=XBTEUR");
                
                JObject tmp = JObject.Parse(webresponse);

                krakenInfo.ask = Convert.ToDouble(tmp["result"]["XXBTZEUR"]["a"][0]);
                krakenInfo.bid = Convert.ToDouble(tmp["result"]["XXBTZEUR"]["b"][0]);
                krakenInfo.last = Convert.ToDouble(tmp["result"]["XXBTZEUR"]["c"][0]);
                krakenInfo.volume = Convert.ToDouble(tmp["result"]["XXBTZEUR"]["c"][1]);

                Console.WriteLine(string.Format("KRAKEN: Ask:{0} | Bid:{1} | Last:{2} | VolumeToday:{3} | Timestamp:{4}",
                        krakenInfo.ask, krakenInfo.bid, krakenInfo.last, krakenInfo.volume, DateTime.Now));

                MySQLData.MarketData.InsertQuoteData("kraken",krakenInfo.ask, krakenInfo.bid, krakenInfo.last, krakenInfo.volume, DateTime.Now);

            }

            catch (Exception ex)
            {
               
            }
        }

    }


}
