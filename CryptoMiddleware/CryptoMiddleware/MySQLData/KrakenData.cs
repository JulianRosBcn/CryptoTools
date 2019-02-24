using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace CryptoMiddleware
{
    
    public class KrakenData
    {

         public static string mysqlconnectionstring = "server=192.168.56.50;user=root;database=kraken;port=3306;password=root;";


            public static void InsertQuoteData(double ask, double bid, double last, double volume, double volumeavgprice, double numoftrades, DateTime timestamp)
            {

                using (MySqlConnection mysqlcon = new MySqlConnection(mysqlconnectionstring))
            {
                    mysqlcon.Open();
                    MySqlCommand mysqlcmd = new MySqlCommand("InsertQuoteInfo", mysqlcon);
                    mysqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    mysqlcmd.Parameters.AddWithValue("_ask", ask);
                    mysqlcmd.Parameters.AddWithValue("_bid", bid);
                    mysqlcmd.Parameters.AddWithValue("_last", last);
                    mysqlcmd.Parameters.AddWithValue("_volume", volume);
                    mysqlcmd.Parameters.AddWithValue("_volumeavgprice", volumeavgprice);
                    mysqlcmd.Parameters.AddWithValue("_numoftrades", numoftrades);
                    mysqlcmd.Parameters.AddWithValue("_timestamp", timestamp);
                    mysqlcmd.ExecuteNonQuery();
                }

            }

            public static void RemoveQuoteData()
            {

                using (MySqlConnection mysqlcon = new MySqlConnection(mysqlconnectionstring))
                {
                    mysqlcon.Open();
                    MySqlCommand mysqlcmd = new MySqlCommand("DeleteQuotesTableData", mysqlcon);
                    mysqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    mysqlcmd.ExecuteNonQuery();
                }

            }

    }
}
