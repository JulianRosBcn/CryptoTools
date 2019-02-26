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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.krakenDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.krakenDataSet = new CryptoAlerts.Datasets.krakenDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optAlarms = new System.Windows.Forms.RadioButton();
            this.optIndicators = new System.Windows.Forms.RadioButton();
            this.optQuotes = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krakenDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krakenDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.BorderWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(13, 12);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "BTC EUR Quote";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(743, 188);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExport.Location = new System.Drawing.Point(641, 213);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(116, 97);
            this.cmdExport.TabIndex = 1;
            this.cmdExport.Text = "EXPORT";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(641, 345);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(116, 97);
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
            this.dataGridView1.Location = new System.Drawing.Point(13, 266);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(607, 176);
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
            this.groupBox1.Controls.Add(this.optAlarms);
            this.groupBox1.Controls.Add(this.optIndicators);
            this.groupBox1.Controls.Add(this.optQuotes);
            this.groupBox1.Location = new System.Drawing.Point(13, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 53);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select DB (showing only last 100 records)";
            // 
            // optAlarms
            // 
            this.optAlarms.AutoSize = true;
            this.optAlarms.Location = new System.Drawing.Point(500, 21);
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
            this.optIndicators.Location = new System.Drawing.Point(237, 21);
            this.optIndicators.Name = "optIndicators";
            this.optIndicators.Size = new System.Drawing.Size(103, 17);
            this.optIndicators.TabIndex = 1;
            this.optIndicators.Text = "Indicators (SMA)";
            this.optIndicators.UseVisualStyleBackColor = true;
            this.optIndicators.CheckedChanged += new System.EventHandler(this.optIndicators_CheckedChanged);
            // 
            // optQuotes
            // 
            this.optQuotes.AutoSize = true;
            this.optQuotes.Location = new System.Drawing.Point(33, 21);
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
            // AlarmsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 456);
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
    }
}

