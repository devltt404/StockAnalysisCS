using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StockAnalysisCS
{
    public partial class Form_AnalyzeStock : Form
    {
        // Declare a list to store Candlestick objects
        private List<Candlestick> candlesticks = null;
        // Declare a binding list to store filtered candlestick objects
        private BindingList<Candlestick> filteredCandlesticks = null;

        public Form_AnalyzeStock()
        {
            InitializeComponent();
            // Initialize the candlesticks list
            candlesticks = new List<Candlestick>();
        }

        /// <summary>
        /// Function to handle the click event of the button_loadTicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_loadTicker_Click(object sender, EventArgs e)
        {
            // Display the OpenFileDialog to allow the user to select a ticker file
            openFileDialog_loadTicker.ShowDialog();
        }

        /// <summary>
        /// Function to handle the event after user selects a ticker file in the OpenFileDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog_loadTicker_FileOk(object sender, CancelEventArgs e)
        {
            // Set the form Text to the selected file name
            Text = openFileDialog_loadTicker.FileName;
            readCandlesticksFromFile();
            filterCandlesticks();
            normalizeChart();
            displayChart();
            displayDataGridView();
        }

        /// <summary>
        /// Function to read candlestick data from the selected file and store it in a list
        /// </summary>
        private void readCandlesticksFromFile()
        {
            // Get the file name selected in the OpenFileDialog
            string fileName = openFileDialog_loadTicker.FileName;

            // Declare the expected header row (first line) of the CSV file
            const string expectedHeader = "\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

            // Open the file to read its contents
            using (StreamReader sr = new StreamReader(fileName))
            {
                // Read the first line of the file
                string line = sr.ReadLine();

                // Check if the first line matches the expected header
                if (line != expectedHeader)
                {
                    // Show an error message if the header is invalid
                    MessageBox.Show("Invalid file format.");
                    // Exit function
                    return;
                }

                // Clear the existing elements in the candlesticks list
                candlesticks.Clear();

                // Read the file util reaching the end
                while (!sr.EndOfStream)
                {
                    // Read a line from the file
                    line = sr.ReadLine();
                    // Create a new Candlestick object from the line
                    Candlestick candlestick = new Candlestick(line);
                    // Add the Candlestick object to the list
                    candlesticks.Add(candlestick);
                }
            }
        }

        /// <summary>
        /// Function to filter the candlestick data based on user-selected date range
        /// </summary>
        private void filterCandlesticks()
        {
            // Get the user-selected start date
            DateTime startDate = dateTimePicker_startDate.Value;
            // Get the user-selected end date
            DateTime endDate = dateTimePicker_endDate.Value;

            // Use LINQ to filter candlesticks within the date range
            // and assign the result to the filteredCandlesticks list
            filteredCandlesticks = new BindingList<Candlestick>(candlesticks.Where(c => c.date >= startDate && c.date <= endDate).ToList());
        }

        /// <summary>
        /// Function to normalize the y-axis of the chart 
        /// to fit the candlesticks data for better visualization
        /// </summary>
        private void normalizeChart()
        {
            // Check if there are no candlesticks within the date range to display
            if (filteredCandlesticks == null || filteredCandlesticks.Count == 0)
            {
                // Exit function
                return;
            }
            // Find the minimum low price in the filtered candlesticks
            decimal minLow = filteredCandlesticks.Min(c => c.low);
            // Find the maximum high price in the filtered candlesticks
            decimal maxHigh = filteredCandlesticks.Max(c => c.high);

            // Calculate the 2% margin
            decimal margin = (maxHigh - minLow) * 0.02m;

            // Set the minimum value of the y-axis for the OHLC chart area
            // to the minimum low price minus the margin
            chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY.Minimum = (double)(minLow - margin);
            // Set the maximum value of the y-axis for the OHLC chart area
            // to the maximum high price plus the margin
            chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY.Maximum = (double)(maxHigh + margin);
        }

        /// <summary>
        /// Function to display the OHLCV stock data in the chart
        /// </summary>
        private void displayChart()
        {
            // Clear existing data in the chart
            chart_stockData.Series["Series_OHLC"].Points.Clear();
            chart_stockData.Series["Series_Volume"].Points.Clear();

            // Loop through each candlestick in the filtered list
            foreach (var candle in filteredCandlesticks)
            {
                // Add a data point to the "Series_OHLC" series (X: date, Y: open, high, low, close)
                int pointIdx = chart_stockData.Series["Series_OHLC"].Points.AddXY(candle.date, candle.open, candle.high, candle.low, candle.close);

                // Set the color for the candlestick
                // Green for up candlestick (close >= open), Red for down candlestick (close < open)
                chart_stockData.Series["Series_OHLC"].Points[pointIdx].Color = (candle.close >= candle.open) ? Color.Green : Color.Red;

                // Add a data point to the "Series_Volume" series (X: date, Y: volume)
                chart_stockData.Series["Series_Volume"].Points.AddXY(candle.date, candle.volume);
            }
        }

        /// <summary>
        /// Function to display the stock data (OHLCV) in a DataGridView
        /// </summary>
        private void displayDataGridView()
        {
            dataGridView_stockData.DataSource = filteredCandlesticks;
        }

        /// <summary>
        /// Function to handle the event when the user selects a date in the start date picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_startDate_ValueChanged(object sender, EventArgs e)
        {
            // Filter the candlesticks based on the new specified date range
            filterCandlesticks();
        }

        /// <summary>
        /// Function to handle the event when the user selects a date in the end date picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_endDate_ValueChanged(object sender, EventArgs e)
        {
            // Filter the candlesticks based on the new specified date range
            filterCandlesticks();
        }
    }
}
