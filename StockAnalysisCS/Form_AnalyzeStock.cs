using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        // Declare a list to store filtered candlestick objects
        private List<Candlestick> filteredCandlesticks = null;

        public Form_AnalyzeStock()
        {
            // Initialize the form components
            InitializeComponent();
            // Initialize the candlesticks list
            candlesticks = new List<Candlestick>();
            // Initialize the filtered candlesticks list
            filteredCandlesticks = new List<Candlestick>();
        }

        /// <summary>
        /// Function to handle the click event of the button_loadTicker
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void button_loadTicker_Click(object sender, EventArgs e)
        {
            // Display the OpenFileDialog to allow the user to select a ticker file
            openFileDialog_loadTicker.ShowDialog();
        }

        /// <summary>
        /// Function to handle the event after user selects a ticker file in the OpenFileDialog
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void openFileDialog_loadTicker_FileOk(object sender, CancelEventArgs e)
        {
            // Set the title of the form to the name of the selected file
            Text = Path.GetFileNameWithoutExtension(openFileDialog_loadTicker.FileName);

            // Read the candlestick data from the selected file
            readCandlesticksFromFile();
            // Display the stock data based on the user-selected date range
            displayStockData();
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
            filteredCandlesticks = candlesticks.Where(c => c.date >= startDate && c.date <= endDate).ToList();
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
            // Set the data source of the chart to the filtered candlesticks list
            chart_stockData.DataSource = filteredCandlesticks;
            // Bind the data to the chart
            chart_stockData.DataBind();
        }

        /// <summary>
        /// Function to display the stock data (OHLCV) in a DataGridView
        /// </summary>
        private void displayDataGridView()
        {
            // Set the data source of the DataGridView to the filtered candlesticks list
            dataGridView_stockData.DataSource = filteredCandlesticks;
        }

        /// <summary>
        /// Function to handle the event when the user selects a date in the start date picker
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void dateTimePicker_startDate_ValueChanged(object sender, EventArgs e)
        {
            // Display stock data based on the user-selected date range
            displayStockData();
        }

        /// <summary>
        /// Function to handle the event when the user selects a date in the end date picker
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void dateTimePicker_endDate_ValueChanged(object sender, EventArgs e)
        {
            // Display stock data based on the user-selected date range
            displayStockData();
        }

        /// <summary>
        /// Calls functions to filter candlesticks, reset, and update the chart and DataGridView.
        /// </summary>
        private void displayStockData()
        {
            // Filter the candlesticks based on the user-selected date range
            filterCandlesticks();

            // Clear existing OHLC data in the chart 
            chart_stockData.Series["Series_OHLC"].Points.Clear();
            // Clear existing Volume data in the chart 
            chart_stockData.Series["Series_Volume"].Points.Clear();

            // Reset DataGridView data source
            dataGridView_stockData.DataSource = null;

            // Check if there are candlesticks within the date range to display
            if (filteredCandlesticks.Count > 0)
            {
                // Normalize the y-axis of the chart to fit the candlesticks data
                normalizeChart();
                // Display the candlestick data in the chart
                displayChart();
                // Display the candlestick data in the DataGridView
                displayDataGridView();
            }
        }
    }
}
