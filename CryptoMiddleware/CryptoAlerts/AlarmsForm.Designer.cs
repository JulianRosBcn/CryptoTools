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
            this.krakenDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.krakenDataSet = new CryptoAlerts.Datasets.krakenDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optOrders = new System.Windows.Forms.RadioButton();
            this.optAlarms = new System.Windows.Forms.RadioButton();
            this.optIndicators = new System.Windows.Forms.RadioButton();
            this.optQuotes = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krakenDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krakenDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.BorderWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(13, 12);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.IsVisibleInLegend = false;
            series1.Name = "BTC EUR Quote";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(870, 214);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExport.Location = new System.Drawing.Point(464, 599);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(116, 42);
            this.cmdExport.TabIndex = 1;
            this.cmdExport.Text = "EXPORT";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(342, 599);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(116, 42);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "EXIT";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.krakenDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(14, 423);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(870, 170);
            this.dataGridView1.TabIndex = 3;
            // 
            // krakenDataSetBindingSource
            // 
            this.krakenDataSetBindingSource.DataSource = this.krakenDataSet;
            this.krakenDataSetBindingSource.Position = 0;
            // 
            // krakenDataSet
            // 
            this.krakenDataSet.DataSetName = "krakenDataSet";
            this.krakenDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optOrders);
            this.groupBox1.Controls.Add(this.optAlarms);
            this.groupBox1.Controls.Add(this.optIndicators);
            this.groupBox1.Controls.Add(this.optQuotes);
            this.groupBox1.Location = new System.Drawing.Point(14, 372);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 45);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select DB (showing only last 100 records)";
            // 
            // optOrders
            // 
            this.optOrders.AutoSize = true;
            this.optOrders.Location = new System.Drawing.Point(604, 19);
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
            this.optAlarms.Location = new System.Drawing.Point(423, 19);
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
            this.optIndicators.Location = new System.Drawing.Point(241, 19);
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
            this.optQuotes.Location = new System.Drawing.Point(59, 19);
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
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(13, 233);
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
            this.chart2.Size = new System.Drawing.Size(871, 133);
            this.chart2.TabIndex = 5;
            this.chart2.Text = "chart2";
            // 
            // AlarmsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 648);
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
            ((System.ComponentModel.ISupportInitialize)(this.krakenDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krakenDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource krakenDataSetBindingSource;
        private Datasets.krakenDataSet krakenDataSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optAlarms;
        private System.Windows.Forms.RadioButton optIndicators;
        private System.Windows.Forms.RadioButton optQuotes;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.RadioButton optOrders;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

