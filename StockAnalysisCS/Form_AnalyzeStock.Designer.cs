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
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_loadTicker = new System.Windows.Forms.Button();
            this.openFileDialog_loadTicker = new System.Windows.Forms.OpenFileDialog();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.chart_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView_stockData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockData)).BeginInit();
            this.SuspendLayout();
            // 
            // button_loadTicker
            // 
            this.button_loadTicker.Location = new System.Drawing.Point(78, 43);
            this.button_loadTicker.Name = "button_loadTicker";
            this.button_loadTicker.Size = new System.Drawing.Size(202, 69);
            this.button_loadTicker.TabIndex = 0;
            this.button_loadTicker.Text = "Load Ticker";
            this.button_loadTicker.UseVisualStyleBackColor = true;
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
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(423, 43);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(272, 26);
            this.dateTimePicker_startDate.TabIndex = 1;
            this.dateTimePicker_startDate.ValueChanged += new System.EventHandler(this.dateTimePicker_startDate_ValueChanged);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(423, 103);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(272, 26);
            this.dateTimePicker_endDate.TabIndex = 2;
            this.dateTimePicker_endDate.ValueChanged += new System.EventHandler(this.dateTimePicker_endDate_ValueChanged);
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Location = new System.Drawing.Point(308, 43);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(83, 20);
            this.label_startDate.TabIndex = 3;
            this.label_startDate.Text = "Start Date";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(312, 94);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(77, 20);
            this.label_endDate.TabIndex = 4;
            this.label_endDate.Text = "End Date";
            // 
            // chart_stockData
            // 
            chartArea3.Name = "ChartArea_OHLC";
            chartArea4.Name = "ChartArea_Volume";
            this.chart_stockData.ChartAreas.Add(chartArea3);
            this.chart_stockData.ChartAreas.Add(chartArea4);
            legend2.Name = "Legend1";
            this.chart_stockData.Legends.Add(legend2);
            this.chart_stockData.Location = new System.Drawing.Point(78, 244);
            this.chart_stockData.Name = "chart_stockData";
            series3.ChartArea = "ChartArea_OHLC";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Legend = "Legend1";
            series3.Name = "Series_OHLC";
            series3.YValuesPerPoint = 4;
            series4.ChartArea = "ChartArea_Volume";
            series4.Legend = "Legend1";
            series4.Name = "Series_Volume";
            this.chart_stockData.Series.Add(series3);
            this.chart_stockData.Series.Add(series4);
            this.chart_stockData.Size = new System.Drawing.Size(1051, 417);
            this.chart_stockData.TabIndex = 5;
            this.chart_stockData.Text = "chart_stockData";
            // 
            // dataGridView_stockData
            // 
            this.dataGridView_stockData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_stockData.Location = new System.Drawing.Point(781, 43);
            this.dataGridView_stockData.Name = "dataGridView_stockData";
            this.dataGridView_stockData.RowHeadersWidth = 62;
            this.dataGridView_stockData.RowTemplate.Height = 28;
            this.dataGridView_stockData.Size = new System.Drawing.Size(240, 150);
            this.dataGridView_stockData.TabIndex = 6;
            // 
            // Form_AnalyzeStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.dataGridView_stockData);
            this.Controls.Add(this.chart_stockData);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.button_loadTicker);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_AnalyzeStock";
            this.Text = "Form_AnalyzeStock";
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
    }
}

