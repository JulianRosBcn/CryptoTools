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
using MySql.Data.MySqlClient;

namespace CryptoAlerts
{
    public partial class AlarmsForm : Form
    {

        public static string selectetDB;
        public static string query;


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

        private void DataLoad()
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
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
            }

        }

        private void AlarmsForm_Load(object sender, EventArgs e)
        {
            optQuotes.Checked = true;
        }

        private void optIndicators_CheckedChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM `indicators` ORDER BY timestamp DESC LIMIT 100;";
            DataLoad();
        }

        private void optAlarms_CheckedChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM `alarms` ORDER BY timestamp DESC LIMIT 100;";
            DataLoad();
        }

        private void optQuotes_CheckedChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM `quotes` ORDER BY timestamp DESC LIMIT 100";
            DataLoad();
        }
    }
}
