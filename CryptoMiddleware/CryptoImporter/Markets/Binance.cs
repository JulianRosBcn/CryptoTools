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
            string webresponse;
            JArray tmp;


            try
            {

                webresponse = client.DownloadString("https://binance.com/api/v1/ticker/24hr");

                tmp = JArray.Parse(webresponse);

                // GETTING QUOTES BTCUSD
                BinanceInfo.market = "binance";
                BinanceInfo.coinpair = "btcusd";
                BinanceInfo.ask = Convert.ToDouble(tmp[11]["askPrice"]);
                BinanceInfo.bid = Convert.ToDouble(tmp[11]["bidPrice"]);
                BinanceInfo.last = Convert.ToDouble(tmp[11]["lastPrice"]);
                BinanceInfo.volume = Convert.ToDouble(tmp[11]["lastQty"]);

                Console.WriteLine(string.Format("BINANCE BTCUSD: Ask:{0} | Bid:{1} | Last:{2} | VolumeToday:{3} | Timestamp:{4}",
                        BinanceInfo.ask, BinanceInfo.bid, BinanceInfo.last, BinanceInfo.volume, DateTime.Now));

                MySQLData.MarketData.InsertQuoteData(BinanceInfo.market, BinanceInfo.coinpair, BinanceInfo.ask, BinanceInfo.bid, BinanceInfo.last, BinanceInfo.volume, DateTime.Now);

                // GETTING QUOTES BTCLTC
                BinanceInfo.market = "binance";
                BinanceInfo.coinpair = "btcltc";
                BinanceInfo.ask = Convert.ToDouble(tmp[1]["askPrice"]);
                BinanceInfo.bid = Convert.ToDouble(tmp[1]["bidPrice"]);
                BinanceInfo.last = Convert.ToDouble(tmp[1]["lastPrice"]);
                BinanceInfo.volume = Convert.ToDouble(tmp[1]["lastQty"]);

                Console.WriteLine(string.Format("BINANCE BTCLTC: Ask:{0} | Bid:{1} | Last:{2} | VolumeToday:{3} | Timestamp:{4}",
                        BinanceInfo.ask, BinanceInfo.bid, BinanceInfo.last, BinanceInfo.volume, DateTime.Now));

                MySQLData.MarketData.InsertQuoteData(BinanceInfo.market, BinanceInfo.coinpair, BinanceInfo.ask, BinanceInfo.bid, BinanceInfo.last, BinanceInfo.volume, DateTime.Now);
                
                // GETTING QUOTES BTCETH
                BinanceInfo.market = "binance";
                BinanceInfo.coinpair = "btceth";
                BinanceInfo.ask = Convert.ToDouble(tmp[0]["askPrice"]);
                BinanceInfo.bid = Convert.ToDouble(tmp[0]["bidPrice"]);
                BinanceInfo.last = Convert.ToDouble(tmp[0]["lastPrice"]);
                BinanceInfo.volume = Convert.ToDouble(tmp[0]["lastQty"]);

                Console.WriteLine(string.Format("BINANCE BTCETH: Ask:{0} | Bid:{1} | Last:{2} | VolumeToday:{3} | Timestamp:{4}",
                        BinanceInfo.ask, BinanceInfo.bid, BinanceInfo.last, BinanceInfo.volume, DateTime.Now));

                MySQLData.MarketData.InsertQuoteData(BinanceInfo.market, BinanceInfo.coinpair, BinanceInfo.ask, BinanceInfo.bid, BinanceInfo.last, BinanceInfo.volume, DateTime.Now);

            }

            catch (Exception ex)
            {

            }
        }

    }



}
