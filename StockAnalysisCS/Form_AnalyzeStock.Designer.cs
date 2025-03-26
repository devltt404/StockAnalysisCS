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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_loadTicker = new System.Windows.Forms.Button();
            this.openFileDialog_loadTicker = new System.Windows.Forms.OpenFileDialog();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.chart_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trackBar_peakValleyMargin = new System.Windows.Forms.TrackBar();
            this.label_peakValleyMargin = new System.Windows.Forms.Label();
            this.button_refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_peakValleyMargin)).BeginInit();
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
            this.openFileDialog_loadTicker.Filter = "All Files|*.csv|Monthly|*-Month.csv|Daily|*-Day.csv|Weekly|*-Week.csv";
            this.openFileDialog_loadTicker.InitialDirectory = "D:\\@DEVLTT404\\USF\\@@@Spring2025\\COP4365\\StockAnalysisCS\\Stock Data";
            this.openFileDialog_loadTicker.Multiselect = true;
            this.openFileDialog_loadTicker.ShowReadOnly = true;
            this.openFileDialog_loadTicker.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_loadTicker_FileOk);
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(97, 75);
            this.dateTimePicker_startDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(183, 20);
            this.dateTimePicker_startDate.TabIndex = 1;
            this.dateTimePicker_startDate.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_startDate.ValueChanged += new System.EventHandler(this.dateTimePicker_startDate_ValueChanged);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(97, 108);
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
            this.label_startDate.Location = new System.Drawing.Point(32, 77);
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
            this.label_endDate.Location = new System.Drawing.Point(32, 109);
            this.label_endDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(58, 15);
            this.label_endDate.TabIndex = 4;
            this.label_endDate.Text = "End Date";
            // 
            // chart_stockData
            // 
            chartArea3.Name = "ChartArea_OHLC";
            chartArea4.AlignWithChartArea = "ChartArea_OHLC";
            chartArea4.Name = "ChartArea_Volume";
            this.chart_stockData.ChartAreas.Add(chartArea3);
            this.chart_stockData.ChartAreas.Add(chartArea4);
            this.chart_stockData.Location = new System.Drawing.Point(35, 196);
            this.chart_stockData.Margin = new System.Windows.Forms.Padding(2);
            this.chart_stockData.Name = "chart_stockData";
            series3.ChartArea = "ChartArea_OHLC";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.CustomProperties = "PriceDownColor=Red, PriceUpColor=Green";
            series3.Name = "Series_OHLC";
            series3.XValueMember = "Date";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series3.YValueMembers = "High,Low,Open,Close";
            series3.YValuesPerPoint = 4;
            series4.ChartArea = "ChartArea_Volume";
            series4.Name = "Series_Volume";
            series4.XValueMember = "Date";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series4.YValueMembers = "Volume";
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            this.chart_stockData.Series.Add(series3);
            this.chart_stockData.Series.Add(series4);
            this.chart_stockData.Size = new System.Drawing.Size(1017, 271);
            this.chart_stockData.TabIndex = 5;
            this.chart_stockData.Text = "chart_stockData";
            // 
            // trackBar_peakValleyMargin
            // 
            this.trackBar_peakValleyMargin.Location = new System.Drawing.Point(405, 90);
            this.trackBar_peakValleyMargin.Maximum = 4;
            this.trackBar_peakValleyMargin.Minimum = 1;
            this.trackBar_peakValleyMargin.Name = "trackBar_peakValleyMargin";
            this.trackBar_peakValleyMargin.Size = new System.Drawing.Size(141, 45);
            this.trackBar_peakValleyMargin.TabIndex = 6;
            this.trackBar_peakValleyMargin.Value = 1;
            this.trackBar_peakValleyMargin.ValueChanged += new System.EventHandler(this.trackBar_peakValleyMargin_ValueChanged);
            // 
            // label_peakValleyMargin
            // 
            this.label_peakValleyMargin.AutoSize = true;
            this.label_peakValleyMargin.Location = new System.Drawing.Point(411, 66);
            this.label_peakValleyMargin.Name = "label_peakValleyMargin";
            this.label_peakValleyMargin.Size = new System.Drawing.Size(112, 13);
            this.label_peakValleyMargin.TabIndex = 7;
            this.label_peakValleyMargin.Text = "Peak/Valley Margin: 1";
            // 
            // button_refresh
            // 
            this.button_refresh.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button_refresh.Location = new System.Drawing.Point(405, 14);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(93, 39);
            this.button_refresh.TabIndex = 8;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = false;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // Form_AnalyzeStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 496);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.label_peakValleyMargin);
            this.Controls.Add(this.trackBar_peakValleyMargin);
            this.Controls.Add(this.chart_stockData);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.button_loadTicker);
            this.Name = "Form_AnalyzeStock";
            this.Text = "Analyze Stock";
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_peakValleyMargin)).EndInit();
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
        private System.Windows.Forms.TrackBar trackBar_peakValleyMargin;
        private System.Windows.Forms.Label label_peakValleyMargin;
        private System.Windows.Forms.Button button_refresh;
    }
}

