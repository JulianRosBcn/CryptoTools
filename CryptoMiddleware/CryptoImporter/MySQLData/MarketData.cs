using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace CryptoImporter.MySQLData
{
    
    public class MarketData
    {

        public static string MarketsConnectionString =  ConfigurationManager.ConnectionStrings["MarketsConnectionString"].ConnectionString;
        public static string AnalyticsConnectionString = ConfigurationManager.ConnectionStrings["AnalyticsConnectionString"].ConnectionString;
        public static string OrderBookConnectionString = ConfigurationManager.ConnectionStrings["OrderBookConnectionString"].ConnectionString;


        public static void InsertQuoteData(string market, double ask, double bid, double last, double volume, DateTime timestamp)
        {

            using (MySqlConnection mysqlcon = new MySqlConnection(MarketsConnectionString))
            {
                mysqlcon.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("InsertQuoteInfo", mysqlcon);
                mysqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_market", market);
                mysqlcmd.Parameters.AddWithValue("_ask", ask);
                mysqlcmd.Parameters.AddWithValue("_bid", bid);
                mysqlcmd.Parameters.AddWithValue("_last", last);
                mysqlcmd.Parameters.AddWithValue("_volume", volume);
                mysqlcmd.Parameters.AddWithValue("_timestamp", timestamp);
                mysqlcmd.ExecuteNonQuery();
            }
               
        }
        
        public static void RemoveQuoteData(string market)
        {

            using (MySqlConnection mysqlcon = new MySqlConnection(MarketsConnectionString))
            {
                mysqlcon.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("DeleteQuotesTableData", mysqlcon);
                mysqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_market", market);
                mysqlcmd.ExecuteNonQuery();
            }

        }

        public static void RemoveAnalyticsData(string market)
        {

            using (MySqlConnection mysqlcon = new MySqlConnection(AnalyticsConnectionString))
            {
                mysqlcon.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("DeleteAnalyticsTableData", mysqlcon);
                mysqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_market", market);
                mysqlcmd.ExecuteNonQuery();
            }

        }

        public static void RemoveOrdersData()
        {

            using (MySqlConnection mysqlcon = new MySqlConnection(OrderBookConnectionString))
            {
                mysqlcon.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("DeleteOrdersTableData", mysqlcon);
                mysqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                mysqlcmd.ExecuteNonQuery();
            }

        }

    }
}
