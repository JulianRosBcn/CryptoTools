using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace CryptoAlerts
{
    static class Program
    {
        public static string mySQLServerIP = "192.168.56.50";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]



        static void Main(string[] args)
        {
            if (args.Length > 0) { mySQLServerIP = args[0]; }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AlarmsForm());
        }
    }
}
