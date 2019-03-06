using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace CryptoAlerts
{
    public partial class AlarmsForm : Form
    {
        public static string market;    
        public static string coinpair;
        public static string data;      //used to switch between data options buttons in datagridload and chartupdate process

        public static string query;
        public static string querychart;


        public AlarmsForm()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {

            string connectionString = ((ConfigurationManager.ConnectionStrings["MarketsConnectionString"].ConnectionString).Replace("servername", CryptoAlerts.Program.mySQLServerIP));

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    StringBuilder sb = new StringBuilder();

                    IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                                      Select(column => column.ColumnName);
                    sb.AppendLine(string.Join(",", columnNames));

                    foreach (DataRow row in dt.Rows)
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                        sb.AppendLine(string.Join(",", fields));
                    }
                    string timeformat = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    File.WriteAllText("OrderBook"+ timeformat + ".csv", sb.ToString());
                    MessageBox.Show("OrderBook has been exported to " + AppDomain.CurrentDomain.BaseDirectory + @"OrderBook" + timeformat + ".csv");
                }
            }
        }

        private void DataGridLoad()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["MarketsConnectionString"].ConnectionString;

            if (data == "quotes") { connectionString = ((ConfigurationManager.ConnectionStrings["MarketsConnectionString"].ConnectionString).Replace("servername", CryptoAlerts.Program.mySQLServerIP)); }
            if (data == "indicators") { connectionString = ((ConfigurationManager.ConnectionStrings["AnalyticsConnectionString"].ConnectionString).Replace("servername", CryptoAlerts.Program.mySQLServerIP)); }
            if (data == "alarms") { connectionString = ((ConfigurationManager.ConnectionStrings["AnalyticsConnectionString"].ConnectionString).Replace("servername", CryptoAlerts.Program.mySQLServerIP)); }
            if (data == "signals") { connectionString = ((ConfigurationManager.ConnectionStrings["AnalyticsConnectionString"].ConnectionString).Replace("servername", CryptoAlerts.Program.mySQLServerIP)); }
            if (data == "orders") { connectionString = ((ConfigurationManager.ConnectionStrings["OrderBookConnectionString"].ConnectionString).Replace("servername", CryptoAlerts.Program.mySQLServerIP)); }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    dataGridView1.Columns.Clear(); //required to maintain timestamp as last column in the datatable
                    dt.Columns["timestamp"].SetOrdinal(dt.Columns.Count - 1);
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
            }

        }

        private void AlarmsForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            market = "kraken"; //review by radiobutton initialization does not generate handler
            coinpair = "btcusd"; //review by radiobutton initialization does not generate handler
            optQuotes.Checked = true;
            optKraken.Checked = true;
            optBTCUSD.Checked = true;
            
            timer.Interval = 1000;
            timer.Start();
        }

        private void optIndicators_CheckedChanged(object sender, EventArgs e)
        {
            data = "indicators";
            queryBuilder();
            if (optIndicators.Checked == true) { DataGridLoad(); }
        }

        private void optAlarms_CheckedChanged(object sender, EventArgs e)
        {
            data = "alarms";
            queryBuilder();
            if (optAlarms.Checked == true) { DataGridLoad(); }
        }

        private void optQuotes_CheckedChanged(object sender, EventArgs e)
        {
            data = "quotes";
            queryBuilder();
            if (optQuotes.Checked == true) { DataGridLoad(); }
        }

        private void optOrders_CheckedChanged(object sender, EventArgs e)
        {
            data = "orders";
            queryBuilder();
            if (optOrders.Checked == true) { DataGridLoad(); }
        }

        private void optSignals_CheckedChanged(object sender, EventArgs e)
        {
            data = "signals";
            queryBuilder();
            if (optSignals.Checked == true) { DataGridLoad(); }
        }

        private void queryBuilder()
        {
            if (data == "orders") { query = "SELECT * FROM `orders` WHERE coinpair = '" + coinpair + "' ORDER BY timestamp DESC LIMIT " + txtNumOfRecords.Text; }
            else { query = "SELECT * FROM `" + market + "_" + data + "` WHERE (coinpair = '" + coinpair + "') ORDER BY timestamp DESC LIMIT " + txtNumOfRecords.Text; }
        }

        private void UpdateCharts()
        {
            string connectionString = ((ConfigurationManager.ConnectionStrings["MarketsConnectionString"].ConnectionString).Replace("servername", CryptoAlerts.Program.mySQLServerIP));
            querychart = "SELECT * FROM `" + market + "_quotes`  WHERE coinpair = '" + coinpair + "' ORDER BY timestamp DESC LIMIT ";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(querychart + txtNumOfRecords.Text, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    //chart1
                    this.chart1.DataSource = dt;
                    this.chart1.Series[0].XValueMember = "timestamp";
                    this.chart1.Series[0].YValueMembers = "last";

                    if (coinpair == "btcusd") { this.chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.} $USD$"; }
                    else { this.chart1.ChartAreas[0].AxisY.LabelStyle.Format = "0.00000 BTC"; }

                    this.chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
                    this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                    this.chart1.Series[0].XValueType = ChartValueType.DateTime;
                    this.chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                    this.chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

                    //chart2
                    this.chart2.DataSource = dt;
                    this.chart2.Series[0].XValueMember = "timestamp";
                    this.chart2.Series[0].YValueMembers = "volume";
                    this.chart2.ChartAreas[0].AxisY.LabelStyle.Format = "0.0 BTC";
                    this.chart2.ChartAreas[0].AxisY.IsStartedFromZero = true;
                    this.chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                    this.chart2.Series[0].XValueType = ChartValueType.DateTime;
                    this.chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                    this.chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateCharts();
        }

        private void optBinance_CheckedChanged(object sender, EventArgs e)
        {
            market = "binance";
            queryBuilder();
            if (optBinance.Checked == true) { DataGridLoad(); }
        }

        private void optKraken_CheckedChanged(object sender, EventArgs e)
        {
            market = "kraken";
            queryBuilder();
            if (optKraken.Checked == true) { DataGridLoad(); }
        }

        private void optBTCUSD_CheckedChanged(object sender, EventArgs e)
        {
            coinpair = "btcusd";
            queryBuilder();
            if (optBTCUSD.Checked == true) { DataGridLoad(); }
        }

        private void optBTCLTC_CheckedChanged(object sender, EventArgs e)
        {
            coinpair = "btcltc";
            queryBuilder();
            if (optBTCLTC.Checked == true) { DataGridLoad(); }
        }

        private void optBTCETH_CheckedChanged(object sender, EventArgs e)
        {
            coinpair = "btceth";
            queryBuilder();
            if (optBTCETH.Checked == true) { DataGridLoad(); }
        }

    }
}
