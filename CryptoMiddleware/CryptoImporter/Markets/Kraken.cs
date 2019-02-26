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

namespace CryptoImporter
{
    

    public class KrakenFunctions
    {

        public static void client_DownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Console.WriteLine(e.Result);
        }

        public static void GetKrakenMarketData()
        {

            WebClient client = new WebClient();
            KrakenQuote krakenInfo = new KrakenQuote();

            try
            {

                // GETTING QUOTES
                string webresponse = client.DownloadString("https://api.kraken.com/0/public/Ticker?pair=XBTEUR");

                JObject tmp = JObject.Parse(webresponse);

                krakenInfo.ask = Convert.ToDouble(tmp["result"]["XXBTZEUR"]["a"][0]);
                krakenInfo.bid = Convert.ToDouble(tmp["result"]["XXBTZEUR"]["b"][0]);
                krakenInfo.last = Convert.ToDouble(tmp["result"]["XXBTZEUR"]["c"][0]);
                krakenInfo.volumetoday = Convert.ToDouble(tmp["result"]["XXBTZEUR"]["v"][0]);
                krakenInfo.volumeavgprice = Convert.ToDouble(tmp["result"]["XXBTZEUR"]["p"][0]);
                krakenInfo.numoftrades = Convert.ToDouble(tmp["result"]["XXBTZEUR"]["t"][0]);

                Console.WriteLine(string.Format("Ask:{0} | Bid:{1} | Last:{2} | Volume:{3} | VolumeAVGPrice:{4} | NumOfTrades:{5} | Timestamp:{6}",
                        krakenInfo.ask, krakenInfo.bid, krakenInfo.last, krakenInfo.volumetoday, krakenInfo.volumeavgprice, krakenInfo.numoftrades, DateTime.Now));

                KrakenData.InsertQuoteData(krakenInfo.ask, krakenInfo.bid, krakenInfo.last, krakenInfo.volumetoday, krakenInfo.volumeavgprice, krakenInfo.numoftrades, DateTime.Now);

            }

            catch (Exception ex)
            {
               
            }
        }

    }


    public class KrakenQuote
    {
        //API Returning always 24h accumulated values for volume,volumeavgprice and numoftrades
        public double ask { get; set; }
        public double bid { get; set; }
        public double last { get; set; }
        public double volumetoday { get; set; }
        public double volumeavgprice { get; set; }
        public double numoftrades { get; set; }
        public DateTime timestamp { get; set; }
    }


}
