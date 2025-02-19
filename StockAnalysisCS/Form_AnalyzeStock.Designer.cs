namespace StockAnalysisCS
{
    partial class Form_AnalyzeStock
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_loadTicker = new System.Windows.Forms.Button();
            this.openFileDialog_loadTicker = new System.Windows.Forms.OpenFileDialog();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.chart_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView_stockData = new System.Windows.Forms.DataGridView();
            this.comboBox_symbol = new System.Windows.Forms.ComboBox();
            this.label_symbol = new System.Windows.Forms.Label();
            this.comboBox_period = new System.Windows.Forms.ComboBox();
            this.label_period = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockData)).BeginInit();
            this.SuspendLayout();
            // 
            // button_loadTicker
            // 
            this.button_loadTicker.BackColor = System.Drawing.Color.MediumBlue;
            this.button_loadTicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_loadTicker.ForeColor = System.Drawing.Color.White;
            this.button_loadTicker.Location = new System.Drawing.Point(34, 14);
            this.button_loadTicker.Margin = new System.Windows.Forms.Padding(2);
            this.button_loadTicker.Name = "button_loadTicker";
            this.button_loadTicker.Size = new System.Drawing.Size(135, 45);
            this.button_loadTicker.TabIndex = 0;
            this.button_loadTicker.Text = "Load Ticker";
            this.button_loadTicker.UseVisualStyleBackColor = false;
            this.button_loadTicker.Click += new System.EventHandler(this.button_loadTicker_Click);
            // 
            // openFileDialog_loadTicker
            // 
            this.openFileDialog_loadTicker.DefaultExt = "csv";
            this.openFileDialog_loadTicker.FileName = "AAL-Day";
            this.openFileDialog_loadTicker.Filter = "All Files|*.csv|Month|*-Month.csv|Day|*-Day.csv|Week|*-Week.csv";
            this.openFileDialog_loadTicker.InitialDirectory = "D:\\@DEVLTT404\\USF\\@@@Spring2025\\COP4365\\StockAnalysisCS\\Stock Data";
            this.openFileDialog_loadTicker.ShowReadOnly = true;
            this.openFileDialog_loadTicker.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_loadTicker_FileOk);
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(97, 69);
            this.dateTimePicker_startDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(183, 20);
            this.dateTimePicker_startDate.TabIndex = 1;
            this.dateTimePicker_startDate.ValueChanged += new System.EventHandler(this.dateTimePicker_startDate_ValueChanged);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(97, 102);
            this.dateTimePicker_endDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(183, 20);
            this.dateTimePicker_endDate.TabIndex = 2;
            this.dateTimePicker_endDate.ValueChanged += new System.EventHandler(this.dateTimePicker_endDate_ValueChanged);
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_startDate.ForeColor = System.Drawing.Color.Black;
            this.label_startDate.Location = new System.Drawing.Point(32, 71);
            this.label_startDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(61, 15);
            this.label_startDate.TabIndex = 3;
            this.label_startDate.Text = "Start Date";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_endDate.ForeColor = System.Drawing.Color.Black;
            this.label_endDate.Location = new System.Drawing.Point(32, 103);
            this.label_endDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(58, 15);
            this.label_endDate.TabIndex = 4;
            this.label_endDate.Text = "End Date";
            // 
            // chart_stockData
            // 
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_stockData.ChartAreas.Add(chartArea1);
            this.chart_stockData.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.chart_stockData.Legends.Add(legend1);
            this.chart_stockData.Location = new System.Drawing.Point(35, 196);
            this.chart_stockData.Margin = new System.Windows.Forms.Padding(2);
            this.chart_stockData.Name = "chart_stockData";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Green";
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "High,Low,Open,Close";
            series1.YValuesPerPoint = 4;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            series2.ChartArea = "ChartArea_Volume";
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "Volume";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            this.chart_stockData.Series.Add(series1);
            this.chart_stockData.Series.Add(series2);
            this.chart_stockData.Size = new System.Drawing.Size(1017, 271);
            this.chart_stockData.TabIndex = 5;
            this.chart_stockData.Text = "chart_stockData";
            // 
            // dataGridView_stockData
            // 
            this.dataGridView_stockData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_stockData.Location = new System.Drawing.Point(377, 28);
            this.dataGridView_stockData.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_stockData.Name = "dataGridView_stockData";
            this.dataGridView_stockData.RowHeadersWidth = 62;
            this.dataGridView_stockData.RowTemplate.Height = 28;
            this.dataGridView_stockData.Size = new System.Drawing.Size(675, 150);
            this.dataGridView_stockData.TabIndex = 6;
            // 
            // comboBox_symbol
            // 
            this.comboBox_symbol.FormattingEnabled = true;
            this.comboBox_symbol.Items.AddRange(new object[] {
            "All",
            "AAL",
            "AAPL",
            "ABBV",
            "IBM",
            "INTC",
            "JPM",
            "LUV",
            "MSFT",
            "WST",
            "WTW",
            "WY",
            "WYNN",
            "XEL",
            "XOM",
            "XRAY",
            "XYL",
            "YUM"});
            this.comboBox_symbol.Location = new System.Drawing.Point(97, 133);
            this.comboBox_symbol.Name = "comboBox_symbol";
            this.comboBox_symbol.Size = new System.Drawing.Size(121, 21);
            this.comboBox_symbol.TabIndex = 7;
            // 
            // label_symbol
            // 
            this.label_symbol.AutoSize = true;
            this.label_symbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_symbol.Location = new System.Drawing.Point(32, 133);
            this.label_symbol.Name = "label_symbol";
            this.label_symbol.Size = new System.Drawing.Size(48, 15);
            this.label_symbol.TabIndex = 8;
            this.label_symbol.Text = "Symbol";
            // 
            // comboBox_period
            // 
            this.comboBox_period.FormattingEnabled = true;
            this.comboBox_period.Items.AddRange(new object[] {
            "All",
            "Daily",
            "Weekly",
            "Monthly"});
            this.comboBox_period.Location = new System.Drawing.Point(97, 163);
            this.comboBox_period.Name = "comboBox_period";
            this.comboBox_period.Size = new System.Drawing.Size(121, 21);
            this.comboBox_period.TabIndex = 9;
            // 
            // label_period
            // 
            this.label_period.AutoSize = true;
            this.label_period.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_period.Location = new System.Drawing.Point(31, 163);
            this.label_period.Name = "label_period";
            this.label_period.Size = new System.Drawing.Size(43, 15);
            this.label_period.TabIndex = 10;
            this.label_period.Text = "Period";
            // 
            // Form_AnalyzeStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 496);
            this.Controls.Add(this.label_period);
            this.Controls.Add(this.comboBox_period);
            this.Controls.Add(this.label_symbol);
            this.Controls.Add(this.comboBox_symbol);
            this.Controls.Add(this.dataGridView_stockData);
            this.Controls.Add(this.chart_stockData);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.button_loadTicker);
            this.Name = "Form_AnalyzeStock";
            this.Text = "Analyze Stock";
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_loadTicker;
        private System.Windows.Forms.OpenFileDialog openFileDialog_loadTicker;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stockData;
        private System.Windows.Forms.DataGridView dataGridView_stockData;
        private System.Windows.Forms.ComboBox comboBox_symbol;
        private System.Windows.Forms.Label label_symbol;
        private System.Windows.Forms.ComboBox comboBox_period;
        private System.Windows.Forms.Label label_period;
    }
}

