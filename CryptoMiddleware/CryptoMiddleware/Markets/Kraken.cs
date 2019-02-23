using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

                krakenInfo.ask = tmp["result"]["XXBTZEUR"]["a"][0].ToString();
                krakenInfo.bid = tmp["result"]["XXBTZEUR"]["b"][0].ToString();
                krakenInfo.last = tmp["result"]["XXBTZEUR"]["c"][0].ToString();

                Console.WriteLine(string.Format("Ask:{0}    | Bid:{1}    | Last:{2}  ", krakenInfo.ask, krakenInfo.bid, krakenInfo.last));

            }

            catch (Exception ex)
            {
               
            }
        }

    }


    public class KrakenQuote
    {
        public string ask { get; set; }
        public string bid { get; set; }
        public string last { get; set; }
        public string volume { get; set; }
    }


}
