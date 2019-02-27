using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
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

        public static string query;
        public static string querychart = "SELECT * FROM `quotes` ORDER BY timestamp DESC LIMIT 100"; // used only for chart refresh, static value


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
            //pending implementation
        }

        private void DataGridLoad()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["KrakenConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
            }

        }

        private void AlarmsForm_Load(object sender, EventArgs e)
        {
            optQuotes.Checked = true;

            timer.Interval = 5000;
            timer.Start();
        }

        private void optIndicators_CheckedChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM `indicators` ORDER BY timestamp DESC LIMIT 100;";
            DataGridLoad();
        }

        private void optAlarms_CheckedChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM `alarms` ORDER BY timestamp DESC LIMIT 100;";
            DataGridLoad();
        }

        private void optQuotes_CheckedChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM `quotes` ORDER BY timestamp DESC LIMIT 100";
            DataGridLoad();
            UpdateCharts();
        }

        private void optOrders_CheckedChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM `orders` ORDER BY timestamp DESC LIMIT 100";
            DataGridLoad();
        }

        private void UpdateCharts()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["KrakenConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(querychart, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    //chart1
                    this.chart1.DataSource = dt;
                    this.chart1.Series[0].XValueMember = "timestamp";
                    this.chart1.Series[0].YValueMembers = "last";
                    this.chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.} €";
                    this.chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
                    this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                    this.chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                    this.chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

                    //chart2
                    this.chart2.DataSource = dt;
                    this.chart2.Series[0].XValueMember = "timestamp";
                    this.chart2.Series[0].YValueMembers = "volume";
                    this.chart2.ChartAreas[0].AxisY.LabelStyle.Format = "0.000 BTC";
                    this.chart2.ChartAreas[0].AxisY.IsStartedFromZero = true;
                    this.chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
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

    }
}
