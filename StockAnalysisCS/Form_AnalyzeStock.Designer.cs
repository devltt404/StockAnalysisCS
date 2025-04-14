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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.comboBox_upWave = new System.Windows.Forms.ComboBox();
            this.label_upWave = new System.Windows.Forms.Label();
            this.label_downWave = new System.Windows.Forms.Label();
            this.comboBox_downWave = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_peakValleyMargin)).BeginInit();
            this.SuspendLayout();
            // 
            // button_loadTicker
            // 
            this.button_loadTicker.BackColor = System.Drawing.Color.MediumBlue;
            this.button_loadTicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_loadTicker.ForeColor = System.Drawing.Color.White;
            this.button_loadTicker.Location = new System.Drawing.Point(51, 22);
            this.button_loadTicker.Name = "button_loadTicker";
            this.button_loadTicker.Size = new System.Drawing.Size(202, 69);
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
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(146, 106);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(272, 26);
            this.dateTimePicker_startDate.TabIndex = 1;
            this.dateTimePicker_startDate.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(146, 157);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(272, 26);
            this.dateTimePicker_endDate.TabIndex = 2;
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_startDate.ForeColor = System.Drawing.Color.Black;
            this.label_startDate.Location = new System.Drawing.Point(48, 109);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(91, 22);
            this.label_startDate.TabIndex = 3;
            this.label_startDate.Text = "Start Date";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_endDate.ForeColor = System.Drawing.Color.Black;
            this.label_endDate.Location = new System.Drawing.Point(48, 159);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(85, 22);
            this.label_endDate.TabIndex = 4;
            this.label_endDate.Text = "End Date";
            // 
            // chart_stockData
            // 
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_stockData.ChartAreas.Add(chartArea1);
            this.chart_stockData.ChartAreas.Add(chartArea2);
            this.chart_stockData.Location = new System.Drawing.Point(51, 210);
            this.chart_stockData.Name = "chart_stockData";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Green";
            series1.IsXValueIndexed = true;
            series1.Name = "Series_OHLC";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "High,Low,Open,Close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_Volume";
            series2.IsXValueIndexed = true;
            series2.Name = "Series_Volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "Volume";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            this.chart_stockData.Series.Add(series1);
            this.chart_stockData.Series.Add(series2);
            this.chart_stockData.Size = new System.Drawing.Size(1526, 748);
            this.chart_stockData.TabIndex = 5;
            this.chart_stockData.Text = "chart_stockData";
            this.chart_stockData.Paint += new System.Windows.Forms.PaintEventHandler(this.chart_stockData_Paint);
            this.chart_stockData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_stockData_MouseDown);
            this.chart_stockData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_stockData_MouseMove);
            this.chart_stockData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart_stockData_MouseUp);
            // 
            // trackBar_peakValleyMargin
            // 
            this.trackBar_peakValleyMargin.Location = new System.Drawing.Point(608, 138);
            this.trackBar_peakValleyMargin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_peakValleyMargin.Maximum = 4;
            this.trackBar_peakValleyMargin.Minimum = 1;
            this.trackBar_peakValleyMargin.Name = "trackBar_peakValleyMargin";
            this.trackBar_peakValleyMargin.Size = new System.Drawing.Size(212, 69);
            this.trackBar_peakValleyMargin.TabIndex = 6;
            this.trackBar_peakValleyMargin.Value = 4;
            this.trackBar_peakValleyMargin.ValueChanged += new System.EventHandler(this.trackBar_peakValleyMargin_ValueChanged);
            // 
            // label_peakValleyMargin
            // 
            this.label_peakValleyMargin.AutoSize = true;
            this.label_peakValleyMargin.Location = new System.Drawing.Point(616, 102);
            this.label_peakValleyMargin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_peakValleyMargin.Name = "label_peakValleyMargin";
            this.label_peakValleyMargin.Size = new System.Drawing.Size(160, 20);
            this.label_peakValleyMargin.TabIndex = 7;
            this.label_peakValleyMargin.Text = "Peak/Valley Margin: 4";
            // 
            // button_refresh
            // 
            this.button_refresh.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button_refresh.Location = new System.Drawing.Point(608, 22);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(140, 60);
            this.button_refresh.TabIndex = 8;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = false;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // comboBox_upWave
            // 
            this.comboBox_upWave.FormattingEnabled = true;
            this.comboBox_upWave.Location = new System.Drawing.Point(874, 54);
            this.comboBox_upWave.Name = "comboBox_upWave";
            this.comboBox_upWave.Size = new System.Drawing.Size(239, 28);
            this.comboBox_upWave.TabIndex = 9;
            this.comboBox_upWave.SelectedIndexChanged += new System.EventHandler(this.comboBox_upWave_SelectedIndexChanged);
            // 
            // label_upWave
            // 
            this.label_upWave.AutoSize = true;
            this.label_upWave.Location = new System.Drawing.Point(870, 22);
            this.label_upWave.Name = "label_upWave";
            this.label_upWave.Size = new System.Drawing.Size(75, 20);
            this.label_upWave.TabIndex = 10;
            this.label_upWave.Text = "UP Wave";
            // 
            // label_downWave
            // 
            this.label_downWave.AutoSize = true;
            this.label_downWave.Location = new System.Drawing.Point(870, 102);
            this.label_downWave.Name = "label_downWave";
            this.label_downWave.Size = new System.Drawing.Size(103, 20);
            this.label_downWave.TabIndex = 11;
            this.label_downWave.Text = "DOWN Wave";
            // 
            // comboBox_downWave
            // 
            this.comboBox_downWave.FormattingEnabled = true;
            this.comboBox_downWave.Location = new System.Drawing.Point(874, 138);
            this.comboBox_downWave.Name = "comboBox_downWave";
            this.comboBox_downWave.Size = new System.Drawing.Size(239, 28);
            this.comboBox_downWave.TabIndex = 12;
            this.comboBox_downWave.SelectedIndexChanged += new System.EventHandler(this.comboBox_downWave_SelectedIndexChanged);
            // 
            // Form_AnalyzeStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1642, 990);
            this.Controls.Add(this.comboBox_downWave);
            this.Controls.Add(this.label_downWave);
            this.Controls.Add(this.label_upWave);
            this.Controls.Add(this.comboBox_upWave);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.label_peakValleyMargin);
            this.Controls.Add(this.trackBar_peakValleyMargin);
            this.Controls.Add(this.chart_stockData);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.button_loadTicker);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_AnalyzeStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
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
        private System.Windows.Forms.ComboBox comboBox_upWave;
        private System.Windows.Forms.Label label_upWave;
        private System.Windows.Forms.Label label_downWave;
        private System.Windows.Forms.ComboBox comboBox_downWave;
    }
}

