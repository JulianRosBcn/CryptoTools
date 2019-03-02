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

        public static string mysqlconnectionstring  =  ConfigurationManager.ConnectionStrings["MarketsConnectionString"].ConnectionString;

        public static void InsertQuoteData(string market, double ask, double bid, double last, double volume, DateTime timestamp)
        {

            using (MySqlConnection mysqlcon = new MySqlConnection(mysqlconnectionstring))
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

            using (MySqlConnection mysqlcon = new MySqlConnection(mysqlconnectionstring))
            {
                mysqlcon.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("DeleteQuotesTableData", mysqlcon);
                mysqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                mysqlcmd.ExecuteNonQuery();
            }

        }

        public static void RemoveIndicatorsData(string market)
        {

            using (MySqlConnection mysqlcon = new MySqlConnection(mysqlconnectionstring))
            {
                mysqlcon.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("DeleteIndicatorsTableData", mysqlcon);
                mysqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                mysqlcmd.ExecuteNonQuery();
            }

        }

        public static void RemoveAlarmsData(string market)
        {

            using (MySqlConnection mysqlcon = new MySqlConnection(mysqlconnectionstring))
            {
                mysqlcon.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("DeleteAlarmsTableData", mysqlcon);
                mysqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                mysqlcmd.ExecuteNonQuery();
            }

        }

        public static void RemoveOrdersData(string market)
        {

            using (MySqlConnection mysqlcon = new MySqlConnection(mysqlconnectionstring))
            {
                mysqlcon.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("DeleteOrdersTableData", mysqlcon);
                mysqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                mysqlcmd.ExecuteNonQuery();
            }

        }

    }
}
