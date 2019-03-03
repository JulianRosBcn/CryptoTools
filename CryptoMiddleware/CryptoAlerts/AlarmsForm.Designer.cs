namespace CryptoAlerts
{
    partial class AlarmsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.KrakenSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KrakenSet = new CryptoAlerts.Datasets.KrakenSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumOfRecords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optOrders = new System.Windows.Forms.RadioButton();
            this.optAlarms = new System.Windows.Forms.RadioButton();
            this.optIndicators = new System.Windows.Forms.RadioButton();
            this.optQuotes = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optBinance = new System.Windows.Forms.RadioButton();
            this.optKraken = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.optBTCETH = new System.Windows.Forms.RadioButton();
            this.optBTCLTC = new System.Windows.Forms.RadioButton();
            this.optBTCUSD = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KrakenSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KrakenSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MaximumAutoSize = 99F;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderWidth = 2;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 94F;
            chartArea1.Position.Y = 3F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(-1, 12);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.IsVisibleInLegend = false;
            series1.Name = "BTC USD Quote";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(948, 214);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExport.Location = new System.Drawing.Point(326, 599);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(116, 42);
            this.cmdExport.TabIndex = 1;
            this.cmdExport.Text = "EXPORT";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(458, 599);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(128, 42);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "EXIT";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.KrakenSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 423);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(926, 170);
            this.dataGridView1.TabIndex = 3;
            // 
            // KrakenSetBindingSource
            // 
            this.KrakenSetBindingSource.DataSource = this.KrakenSet;
            this.KrakenSetBindingSource.Position = 0;
            // 
            // KrakenSet
            // 
            this.KrakenSet.DataSetName = "KrakenSet";
            this.KrakenSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumOfRecords);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.optOrders);
            this.groupBox1.Controls.Add(this.optAlarms);
            this.groupBox1.Controls.Add(this.optIndicators);
            this.groupBox1.Controls.Add(this.optQuotes);
            this.groupBox1.Location = new System.Drawing.Point(452, 372);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 45);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Data";
            // 
            // txtNumOfRecords
            // 
            this.txtNumOfRecords.Location = new System.Drawing.Point(417, 16);
            this.txtNumOfRecords.Name = "txtNumOfRecords";
            this.txtNumOfRecords.Size = new System.Drawing.Size(61, 20);
            this.txtNumOfRecords.TabIndex = 5;
            this.txtNumOfRecords.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of records";
            // 
            // optOrders
            // 
            this.optOrders.AutoSize = true;
            this.optOrders.Location = new System.Drawing.Point(245, 19);
            this.optOrders.Name = "optOrders";
            this.optOrders.Size = new System.Drawing.Size(56, 17);
            this.optOrders.TabIndex = 3;
            this.optOrders.Text = "Orders";
            this.optOrders.UseVisualStyleBackColor = true;
            this.optOrders.CheckedChanged += new System.EventHandler(this.optOrders_CheckedChanged);
            // 
            // optAlarms
            // 
            this.optAlarms.AutoSize = true;
            this.optAlarms.Location = new System.Drawing.Point(173, 19);
            this.optAlarms.Name = "optAlarms";
            this.optAlarms.Size = new System.Drawing.Size(56, 17);
            this.optAlarms.TabIndex = 2;
            this.optAlarms.Text = "Alarms";
            this.optAlarms.UseVisualStyleBackColor = true;
            this.optAlarms.CheckedChanged += new System.EventHandler(this.optAlarms_CheckedChanged);
            // 
            // optIndicators
            // 
            this.optIndicators.AutoSize = true;
            this.optIndicators.Location = new System.Drawing.Point(84, 19);
            this.optIndicators.Name = "optIndicators";
            this.optIndicators.Size = new System.Drawing.Size(71, 17);
            this.optIndicators.TabIndex = 1;
            this.optIndicators.Text = "Indicators";
            this.optIndicators.UseVisualStyleBackColor = true;
            this.optIndicators.CheckedChanged += new System.EventHandler(this.optIndicators_CheckedChanged);
            // 
            // optQuotes
            // 
            this.optQuotes.AutoSize = true;
            this.optQuotes.Location = new System.Drawing.Point(6, 19);
            this.optQuotes.Name = "optQuotes";
            this.optQuotes.Size = new System.Drawing.Size(59, 17);
            this.optQuotes.TabIndex = 0;
            this.optQuotes.Text = "Quotes";
            this.optQuotes.UseVisualStyleBackColor = true;
            this.optQuotes.CheckedChanged += new System.EventHandler(this.optQuotes_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 94F;
            chartArea2.Position.Width = 94F;
            chartArea2.Position.X = 4F;
            chartArea2.Position.Y = 3F;
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(-1, 233);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.IsVisibleInLegend = false;
            series2.LabelBackColor = System.Drawing.Color.White;
            series2.LabelBorderColor = System.Drawing.Color.White;
            series2.MarkerColor = System.Drawing.Color.White;
            series2.Name = "volume";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(915, 133);
            this.chart2.TabIndex = 5;
            this.chart2.Text = "chart2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optBinance);
            this.groupBox2.Controls.Add(this.optKraken);
            this.groupBox2.Location = new System.Drawing.Point(12, 372);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 45);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Exchange";
            // 
            // optBinance
            // 
            this.optBinance.AutoSize = true;
            this.optBinance.Location = new System.Drawing.Point(80, 19);
            this.optBinance.Name = "optBinance";
            this.optBinance.Size = new System.Drawing.Size(64, 17);
            this.optBinance.TabIndex = 1;
            this.optBinance.Text = "Binance";
            this.optBinance.UseVisualStyleBackColor = true;
            this.optBinance.CheckedChanged += new System.EventHandler(this.optBinance_CheckedChanged);
            // 
            // optKraken
            // 
            this.optKraken.AutoSize = true;
            this.optKraken.Location = new System.Drawing.Point(6, 19);
            this.optKraken.Name = "optKraken";
            this.optKraken.Size = new System.Drawing.Size(59, 17);
            this.optKraken.TabIndex = 0;
            this.optKraken.Text = "Kraken";
            this.optKraken.UseVisualStyleBackColor = true;
            this.optKraken.CheckedChanged += new System.EventHandler(this.optKraken_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.optBTCETH);
            this.groupBox3.Controls.Add(this.optBTCLTC);
            this.groupBox3.Controls.Add(this.optBTCUSD);
            this.groupBox3.Location = new System.Drawing.Point(189, 372);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 45);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Coin Pair";
            // 
            // optBTCETH
            // 
            this.optBTCETH.AutoSize = true;
            this.optBTCETH.Location = new System.Drawing.Point(169, 19);
            this.optBTCETH.Name = "optBTCETH";
            this.optBTCETH.Size = new System.Drawing.Size(68, 17);
            this.optBTCETH.TabIndex = 2;
            this.optBTCETH.Text = "BTCETH";
            this.optBTCETH.UseVisualStyleBackColor = true;
            this.optBTCETH.CheckedChanged += new System.EventHandler(this.optBTCETH_CheckedChanged);
            // 
            // optBTCLTC
            // 
            this.optBTCLTC.AutoSize = true;
            this.optBTCLTC.Location = new System.Drawing.Point(90, 19);
            this.optBTCLTC.Name = "optBTCLTC";
            this.optBTCLTC.Size = new System.Drawing.Size(66, 17);
            this.optBTCLTC.TabIndex = 1;
            this.optBTCLTC.Text = "BTCLTC";
            this.optBTCLTC.UseVisualStyleBackColor = true;
            this.optBTCLTC.CheckedChanged += new System.EventHandler(this.optBTCLTC_CheckedChanged);
            // 
            // optBTCUSD
            // 
            this.optBTCUSD.AutoSize = true;
            this.optBTCUSD.Location = new System.Drawing.Point(6, 19);
            this.optBTCUSD.Name = "optBTCUSD";
            this.optBTCUSD.Size = new System.Drawing.Size(69, 17);
            this.optBTCUSD.TabIndex = 0;
            this.optBTCUSD.Text = "BTCUSD";
            this.optBTCUSD.UseVisualStyleBackColor = true;
            this.optBTCUSD.CheckedChanged += new System.EventHandler(this.optBTCUSD_CheckedChanged);
            // 
            // AlarmsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(950, 648);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.chart1);
            this.MaximizeBox = false;
            this.Name = "AlarmsForm";
            this.Text = "Alarms for CryptoTools";
            this.Load += new System.EventHandler(this.AlarmsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KrakenSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KrakenSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource KrakenSetBindingSource;
        private Datasets.KrakenSet KrakenSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optAlarms;
        private System.Windows.Forms.RadioButton optIndicators;
        private System.Windows.Forms.RadioButton optQuotes;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.RadioButton optOrders;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox txtNumOfRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optBinance;
        private System.Windows.Forms.RadioButton optKraken;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton optBTCETH;
        private System.Windows.Forms.RadioButton optBTCLTC;
        private System.Windows.Forms.RadioButton optBTCUSD;
    }
}

