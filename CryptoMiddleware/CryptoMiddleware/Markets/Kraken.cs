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



namespace CryptoMiddleware
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

                Console.WriteLine(string.Format("Ask:{0}    | Bid:{1}    | Last:{2}    | Timestamp:{3}  ", krakenInfo.ask, krakenInfo.bid, krakenInfo.last, DateTime.Now));

                KrakenData.InsertQuoteData(krakenInfo.ask, krakenInfo.bid, krakenInfo.last, DateTime.Now);


            }

            catch (Exception ex)
            {
               
            }
        }

    }


    public class KrakenQuote
    {
        public double ask { get; set; }
        public double bid { get; set; }
        public double last { get; set; }
        public DateTime timestamp { get; set; }
    }


}
