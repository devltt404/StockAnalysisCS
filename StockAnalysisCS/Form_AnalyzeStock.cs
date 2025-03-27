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
        // Declare a list to store the extreme values (peaks and valleys) in the candlestick data.
        // Extremes are stored as tuples with the date, price, and a boolean value indicating if it is a peak.
        private List<(DateTime date, decimal price, bool isPeak)> extremes = null;
        // Declare a list to store the up waves
        private List<Wave> upWaves = null;
        // Declare a list to store the down waves
        private List<Wave> downWaves = null;

        public Form_AnalyzeStock()
        {
            // Initialize the form components
            InitializeComponent();
            // Initialize the candlesticks list
            candlesticks = new List<Candlestick>();
            // Initialize the filtered candlesticks list
            filteredCandlesticks = new List<Candlestick>();
            // Initialize the extremes list
            extremes = new List<(DateTime date, decimal price, bool isPeak)>();
            // Initialize the up waves list
            upWaves = new List<Wave>();
            // Initialize the down waves list
            downWaves = new List<Wave>();
        }

        /// <summary>
        /// Constructor to create a new instance of the Form_AnalyzeStock class
        /// with specified ticker file name, start date, and end date
        /// </summary>
        /// <param name="tickerFileName">The ticker filename</param>
        /// <param name="start">The start date for candlesticks filtering</param>
        /// <param name="end">The end date for candlesticks filtering</param>
        public Form_AnalyzeStock(string tickerFileName, DateTime start, DateTime end)
        {
            // Initialize the form components
            InitializeComponent();
            // Initialize the candlesticks list
            candlesticks = new List<Candlestick>();
            // Initialize the filtered candlesticks list
            filteredCandlesticks = new List<Candlestick>();
            // Initialize the extremes list
            extremes = new List<(DateTime date, decimal price, bool isPeak)>();
            // Initialize the up waves list
            upWaves = new List<Wave>();
            // Initialize the down waves list
            downWaves = new List<Wave>();

            // Set the start date picker value to the specified start date
            dateTimePicker_startDate.Value = start;
            // Set the end date picker value to the specified end date
            dateTimePicker_endDate.Value = end;

            // Read the candlestick data from the selected file
            readCandlesticksFromFile(tickerFileName);
            // Display the stock data based on the user-selected date range
            displayStockData();
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
            // Get the number of files selected in the OpenFileDialog
            int numFiles = openFileDialog_loadTicker.FileNames.Count();
            // Get the start date selected by the user
            DateTime startDate = dateTimePicker_startDate.Value;
            // Get the end date selected by the user
            DateTime endDate = dateTimePicker_endDate.Value;

            // Loop through the selected files
            for (int i = 0; i < numFiles; i++)
            {
                // Get the file name
                string fileName = openFileDialog_loadTicker.FileNames[i];
                // Get the name of ticker from the current file name
                string tickerName = Path.GetFileNameWithoutExtension(fileName);
                // Declare a form to display and analyze stock data
                Form_AnalyzeStock analyzeStockForm;

                // Check if the current file is the first file selected
                if (i == 0)
                {
                    // Use the current form to display and analyze stock data of the first file
                    analyzeStockForm = this;
                    // Read the candlestick data from the selected file
                    readCandlesticksFromFile(fileName);
                    // Display the stock data based on the user-selected date range
                    displayStockData();
                } else
                {
                    analyzeStockForm = new Form_AnalyzeStock(fileName, startDate, endDate);
                }

                // Set the title of the form to the ticker name
                analyzeStockForm.Text = tickerName;
                // Show the form
                analyzeStockForm.Show();
            }
        }

        /// <summary>
        /// Function to read candlestick data from the selected file and store it in a list
        /// </summary>
        /// <param name="fileName">The filename of selected file</param>
        private void readCandlesticksFromFile(string fileName)
        {
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
            // Check if there are at least two candlesticks in the list 
            // and the first candlestick date is greater than the second candlestick date
            if (candlesticks.Count >=2 && candlesticks[0].date > candlesticks[1].date)
            {
                // Reverse the order of the candlesticks
                candlesticks.Reverse();
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
        /// Calls functions to filter candlesticks, reset, and update the chart.
        /// </summary>
        private void displayStockData()
        {
            // Filter the candlesticks based on the user-selected date range
            filterCandlesticks();

            // Clear existing OHLC data in the chart 
            chart_stockData.Series["Series_OHLC"].Points.Clear();
            // Clear existing Volume data in the chart 
            chart_stockData.Series["Series_Volume"].Points.Clear();

            // Check if there are candlesticks within the date range to display
            if (filteredCandlesticks.Count > 0)
            {
                // Normalize the y-axis of the chart to fit the candlesticks data
                normalizeChart();
                // Display the candlestick data in the chart
                displayChart();
                // Detect peaks and valleys in the candlestick data
                detectPeakAndValley();
                // Detect waves in the candlestick data
                detectWaves();
            }
        }

        /// <summary>
        /// Function to add an arrow annotation for a peak or valley in the chart
        /// </summary>
        /// <param name="i">The index of the candlestick in the filtered candlesticks list that is peak or valley</param>
        /// <param name="isPeak">The boolean value indicating if the candlestick is a peak or valley</param>
        private void addPeakValleyAnnotation(int i, Boolean isPeak)
        {
            // Get the data point at the specified index in the OHLC series
            DataPoint dataPoint = chart_stockData.Series["Series_OHLC"].Points[i];
            // Create a new ArrowAnnotation instance
            ArrowAnnotation arrow = new ArrowAnnotation();
            // Set the annotation's X axis to the chart's X axis
            arrow.AxisX = chart_stockData.ChartAreas["ChartArea_OHLC"].AxisX;
            // Set the annotation's Y axis to the chart's Y axis
            arrow.AxisY = chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY;
            // Set the annotation's arrow color to red for peak and green for valley
            arrow.BackColor = isPeak ? Color.Red : Color.Green;
            // Set the annotation's arrow width to 0 (vertical)
            arrow.Width = 0;
            // Set the annotation's arrow height to -10 (down) for peak and 10 (up) for valley
            arrow.Height = isPeak ? -10 : 10;
            // Anchor the arrow to the specified DataPoint
            arrow.SetAnchor(dataPoint);

            // If the candlestick is a valley
            if (!isPeak)
            {
                // Adjust the arrow Y position to the low price of the candlestick
                arrow.Y = (double)filteredCandlesticks[i].low;
            }
            // Add the arrow annotation to the chart
            chart_stockData.Annotations.Add(arrow);
        }

        private void detectPeakAndValley()
        {
            // Get the peak/valley margin value set by the user
            int margin = trackBar_peakValleyMargin.Value;
            // Clear existing annotations in the chart
            chart_stockData.Annotations.Clear();
            // Clear existing extremes list
            extremes.Clear();

            // Loop through the filtered candlesticks list with a margin
            for (int i = margin; i < filteredCandlesticks.Count - margin; i++)
            {
                // Declare a variable to store the current candlestick
                Candlestick currentCandlestick = filteredCandlesticks[i];
                // Declare a variable to check if the current candlestick is a peak
                bool isPeak = true;
                // Declare a variable to check if the current candlestick is a valley
                bool isValley = true;

                // Check the previous and next candlesticks within the margin
                for (int j = 1; j <= margin; j++)
                {
                    // Declare a variable to store the previous candlestick
                    Candlestick prevCandlestick = filteredCandlesticks[i - j];
                    // Declare a variable to store the next candlestick
                    Candlestick nextCandlestick = filteredCandlesticks[i + j];

                    // If the current candlestick high is less than or equal to the previous or next candlestick high
                    if (currentCandlestick.high <= prevCandlestick.high || currentCandlestick.high <= nextCandlestick.high)
                    {
                        // The current candlestick is not a peak
                        isPeak = false;
                    }

                    // If the current candlestick low is greater than or equal to the previous or next candlestick low
                    if (currentCandlestick.low >= prevCandlestick.low || currentCandlestick.low >= nextCandlestick.low)
                    {
                        // The current candlestick is not a valley
                        isValley = false;
                    }
                }

                // If the current candlestick is a peak
                if (isPeak)
                {
                    // Add the peak to the extremes list
                    extremes.Add((currentCandlestick.date, currentCandlestick.high, true));
                    // Add an arrow annotation to the chart indicating a peak
                    addPeakValleyAnnotation(i, true);
                }
                // If the current candlestick is a valley
                else if (isValley)
                {
                    // Add the valley to the extremes list
                    extremes.Add((currentCandlestick.date, currentCandlestick.low, false));
                    // Add an arrow annotation to the chart indicating a valley
                    addPeakValleyAnnotation(i, false);
                }
            }
        }

        /// <summary>
        /// Function to handle the event when the user changes the value of trackBar_peakValleyMargin
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void trackBar_peakValleyMargin_ValueChanged(object sender, EventArgs e)
        {
            // Set the label_peakValleyMargin text to display the current value of the margin
            // set by the user in the trackBar_peakValleyMargin
            label_peakValleyMargin.Text = "Peak/Valley Margin: " + trackBar_peakValleyMargin.Value;
        }

        /// <summary>
        /// Function to handle the click event of the button_refresh
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void button_refresh_Click(object sender, EventArgs e)
        {
            // Display stock data based on the user-selected date range
            displayStockData();
            // Clear the selected wave in the comboBox_downWave
            comboBox_downWave.Text = "";
            // Clear the selected wave in the comboBox_upWave
            comboBox_upWave.Text = "";
        }


        /// <summary>
        /// Function to detect waves in the candlestick data
        /// </summary>
        private void detectWaves()
        {
            // Clear existing waves in the upWaves list
            upWaves.Clear();
            // Clear existing waves in the downWaves list
            downWaves.Clear();
            // Clear existing items in the comboBox_downWave
            comboBox_downWave.Items.Clear();
            // Clear existing items in the comboBox_upWave
            comboBox_upWave.Items.Clear();
            // Loop through the extremes list to find waves
            for (int i = 0; i < extremes.Count - 1; i++)
            {
                // Loop through the extremes list starting from the next index
                for (int j = i + 1; j < extremes.Count; j++)
                {
                    // Get the previous extreme value
                    var prevExtreme = extremes[i];
                    // Get the next extreme value
                    var nextExtreme = extremes[j];
                    // Create a new Wave object with the start and end dates and prices
                    Wave tempWave = new Wave { startDate = prevExtreme.date, startPrice = prevExtreme.price, endDate = nextExtreme.date, endPrice = nextExtreme.price };
                    // Create a label for the wave
                    var waveLabel = tempWave.startDate.ToString("MM/dd/yyyy") + " - " + tempWave.endDate.ToString("MM/dd/yyyy");
                    // Check if the wave is a down wave
                    if (prevExtreme.isPeak && !nextExtreme.isPeak && prevExtreme.price > nextExtreme.price)
                    {
                        // Add the wave to the downWaves list
                        downWaves.Add(tempWave);
                        // Add the wave label to the comboBox_downWave
                        comboBox_downWave.Items.Add(waveLabel);
                    }
                    // Check if the wave is an up wave
                    else if (!prevExtreme.isPeak && nextExtreme.isPeak && prevExtreme.price < nextExtreme.price)
                    {
                        // Add the wave to the upWaves list
                        upWaves.Add(tempWave);
                        // Add the wave label to the comboBox_upWave
                        comboBox_upWave.Items.Add(waveLabel);
                    }
                }
            }
        }

        /// <summary>
        /// Function to handle the event when the user selects an up wave from the comboBox_upWave
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void comboBox_upWave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_upWave.SelectedIndex >= 0 && comboBox_upWave.SelectedIndex < upWaves.Count)
            {
                // Get the selected up wave
                Wave selectedWave = upWaves[comboBox_upWave.SelectedIndex];

                // Draw the up wave
                addWaveAnnotation(selectedWave, true);
            }
        }

        /// <summary>
        /// Function to handle the event when the user selects an down wave from the comboBox_downWave
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void comboBox_downWave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_downWave.SelectedIndex >= 0 && comboBox_downWave.SelectedIndex < downWaves.Count)
            {
                // Get the selected down wave
                Wave selectedWave = downWaves[comboBox_downWave.SelectedIndex];

                // Draw the down wave
                addWaveAnnotation(selectedWave, false);
            }
        }

        /// <summary>
        /// Function to add wave annotation to the chart
        /// </summary>
        /// <param name="wave">The selected wave object</param>
        /// <param name="isUp">Boolean value indicating if the wave is an up wave</param>
        private void addWaveAnnotation(Wave wave, bool isUp)
        {
            // Clear existing wave annotations in the chart
            foreach (var annotation in chart_stockData.Annotations.ToList())
            {
                // Check if wave is up
                if (isUp)
                {
                    /// Check if the annotation is an up wave rectangle or line
                    if (annotation.Name == "Up_Wave_Rectangle" || annotation.Name == "Up_Wave_Line")
                    {
                        // Remove the annotation from the chart
                        chart_stockData.Annotations.Remove(annotation);
                    }
                }
                // Check if wave is down
                else
                {
                    /// Check if the annotation is a down wave rectangle or line
                    if (annotation.Name == "Down_Wave_Rectangle" || annotation.Name == "Down_Wave_Line")
                    {
                        // Remove the annotation from the chart
                        chart_stockData.Annotations.Remove(annotation);
                    }
                }
            }
            
            // Find the start point of the wave
            DataPoint startPoint = chart_stockData.Series["Series_OHLC"].Points
                .FirstOrDefault(p => p.XValue == wave.startDate.ToOADate());
            // Find the end point of the wave
            DataPoint endPoint = chart_stockData.Series["Series_OHLC"].Points
                .FirstOrDefault(p => p.XValue == wave.endDate.ToOADate());

            // If the start or end point is not found, exit the function
            if (startPoint == null || endPoint == null) return;

            // Set the color of up wave to green and down wave to red
            var color = isUp ? Color.Green : Color.Red;

            // Create rectangle annotation for the wave
            RectangleAnnotation rect = new RectangleAnnotation();
            // Set the name of the rectangle annotation
            rect.Name = isUp ? "Up_Wave_Rectangle" : "Down_Wave_Rectangle";
            // Set the X axis of the rectangle annotation to the chart's X axis
            rect.AxisX = chart_stockData.ChartAreas["ChartArea_OHLC"].AxisX;
            // Set the Y axis of the rectangle annotation to the chart's Y axis
            rect.AxisY = chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY;
            // Set the color of the rectangle annotation
            rect.LineColor = color;
            // Set the width of the rectangle annotation
            rect.LineWidth = 2;
            // Set the background color of the rectangle annotation
            rect.BackColor = Color.FromArgb(35, color);
            // Set the anchor of the rectangle annotation to the start and end points
            rect.SetAnchor(startPoint, endPoint);
            // Set the anchor alignment of the rectangle annotation to top left
            rect.AnchorAlignment = ContentAlignment.TopLeft;
            // Enable annotation to overlap with other annotations
            rect.SmartLabelStyle.Enabled = false;

            // Create diagonal line annotation
            LineAnnotation line = new LineAnnotation();
            // Set line name
            line.Name = isUp ? "Up_Wave_Line" : "Down_Wave_Line";
            // Set line X axis to chart X axis
            line.AxisX = chart_stockData.ChartAreas["ChartArea_OHLC"].AxisX;
            // Set line Y axis to chart Y axis
            line.AxisY = chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY;
            // Set line color
            line.LineColor = color;
            // Set line width
            line.LineWidth = 2;
            // Enable annotation to overlap with other annotations
            line.SmartLabelStyle.Enabled = false;

            // Set the anchor of the line annotation to the start and end points
            line.SetAnchor(startPoint, endPoint);

            // Add rectangle annotation to the chart
            chart_stockData.Annotations.Add(rect);
            // Add line annotation to the chart
            chart_stockData.Annotations.Add(line);

            // Refresh the chart
            chart_stockData.Invalidate();
        }
    }
}
