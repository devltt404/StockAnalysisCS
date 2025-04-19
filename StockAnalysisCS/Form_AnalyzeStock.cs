using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        private List<Extreme> extremes = null;
        // Declare a list to store the up waves
        private List<Wave> upWaves = null;
        // Declare a list to store the down waves
        private List<Wave> downWaves = null;

        // Declare a variable to store the index of the starting point of the rubber banding operation
        private int startPointIdx;
        // Declare a variable to store the index of the ending point of the rubber banding operation
        private int endPointIdx;
        // Declare a variable to store the starting point of the rubber banding operation
        private Point startPoint;
        // Declare a variable to store the current point of the mouse in the chart area
        private Point currentPoint;
        // Declare a variable to indicate if the user is currently dragging the mouse in the chart area
        private bool isDragging = false;
        // Declare a variable to indicate if the user has selected a valid wave
        private bool isValidWaveSelected = false;
        // Declare a variable to store the confirmation annotations
        private List<EllipseAnnotation> confirmationAnnotations = null;
        // Declare a variable to check if the selected wave is up
        private bool isSelectUpWave = false;
        // Declare an array of Fibonacci levels
        private double[] fibonnaciLevels = { 0.0, 0.236, 0.382, 0.5, 0.618, 0.764, 1.0 };

        // Declare a variable to store boolean value indicating if the simulation is running
        private bool isSimulating = false;
        // Declare a variable to store the step size for the simulation
        private double stepSize;
        // Declare a variable to store the current step count for the simulation
        private int currentStep = 0;
        // Declare a variable to store the number of steps for the simulation
        private const int numberOfSteps = 30;


        /// <summary>
        /// Function to initialize the form components and data members
        /// </summary>
        private void intializeForm()
        {
            // Initialize the form components
            InitializeComponent();
            // Initialize the candlesticks list
            candlesticks = new List<Candlestick>();
            // Initialize the filtered candlesticks list
            filteredCandlesticks = new List<Candlestick>();
            // Initialize the extremes list
            extremes = new List<Extreme>();
            // Initialize the up waves list
            upWaves = new List<Wave>();
            // Initialize the down waves list
            downWaves = new List<Wave>();
            // Initialize the confirmation annotations list
            confirmationAnnotations = new List<EllipseAnnotation>();
            // Reset the isValidWaveSelected flag to false
            isValidWaveSelected = false;
        }

        public Form_AnalyzeStock()
        {
            // Initialize the form components and data members
            intializeForm();
        }

        /// <summary>
        /// Constructor to create a new instance of the Form_AnalyzeStock class
        /// with specified ticker file name, start date, end date, and peak/valley margin
        /// </summary>
        /// <param name="tickerFileName">The ticker filename</param>
        /// <param name="start">The start date for candlesticks filtering</param>
        /// <param name="end">The end date for candlesticks filtering</param>
        /// <param name="margin">The peak/valley margin value</param>
        public Form_AnalyzeStock(string tickerFileName, DateTime start, DateTime end, int margin)
        {
            // Initialize the form components and data members
            intializeForm();

            // Set the start date picker value to the specified start date
            dateTimePicker_startDate.Value = start;
            // Set the end date picker value to the specified end date
            dateTimePicker_endDate.Value = end;
            // Set the peak/valley margin trackbar value to the specified margin
            trackBar_peakValleyMargin.Value = margin;

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
                    // Set the selected downwave to empty
                    comboBox_downWave.Text = "";
                    // Set the selected upwave to empty
                    comboBox_upWave.Text = "";
                    // Read the candlestick data from the selected file
                    readCandlesticksFromFile(fileName);
                    // Display the stock data based on the user-selected date range
                    displayStockData();
                }
                else
                {
                    // Create a new form to display and analyze stock data of the subsequent files
                    analyzeStockForm = new Form_AnalyzeStock(fileName, startDate, endDate, trackBar_peakValleyMargin.Value);
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
            // Sort the candlesticks list by date
            candlesticks.Sort((a, b) => a.date.CompareTo(b.date));
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
            // Clear existing annotations
            chart_stockData.Annotations.Clear();

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
            // Set the anchor offset y
            arrow.AnchorOffsetY = -0.5;

            // If the candlestick is a valley
            if (!isPeak)
            {
                // Adjust the arrow Y position to the low price of the candlestick
                arrow.Y = (double)filteredCandlesticks[i].low - 0.2;
            }
            // Add the arrow annotation to the chart
            chart_stockData.Annotations.Add(arrow);
        }

        /// <summary>
        /// Function to detect peaks and valleys in the candlestick data
        /// </summary>
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
                    extremes.Add(new Extreme(currentCandlestick.date, currentCandlestick.high, true, i));
                    // Add an arrow annotation to the chart indicating a peak
                    addPeakValleyAnnotation(i, true);
                }
                // If the current candlestick is a valley
                if (isValley)
                {
                    // Add the valley to the extremes list
                    extremes.Add(new Extreme(currentCandlestick.date, currentCandlestick.low, false, i));
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
            // Reset the isValidWaveSelected flag to false
            isValidWaveSelected = false;
            // Clear confirmation annotations
            confirmationAnnotations.Clear();
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
                    Wave tempWave = new Wave(prevExtreme.date, nextExtreme.date, prevExtreme.price, nextExtreme.price, prevExtreme.index, nextExtreme.index);
                    // Create a label for the wave
                    var waveLabel = tempWave.startDate.ToString("MM/dd/yyyy") + " - " + tempWave.endDate.ToString("MM/dd/yyyy");

                    // Check if 2 extremes have same date, then skip to next iteration
                    if (prevExtreme.date == nextExtreme.date) continue;

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
            // Check if the selected index is valid
            if (comboBox_upWave.SelectedIndex >= 0 && comboBox_upWave.SelectedIndex < upWaves.Count)
            {
                // Get the selected up wave
                Wave selectedWave = upWaves[comboBox_upWave.SelectedIndex];
                // Set the isSelectUpWave flag to true
                isSelectUpWave = true;
                // Handle the selected up wave
                handleSelectWave(selectedWave);
            }
        }

        /// <summary>
        /// Function to handle the event when the user selects an down wave from the comboBox_downWave
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void comboBox_downWave_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected index is valid
            if (comboBox_downWave.SelectedIndex >= 0 && comboBox_downWave.SelectedIndex < downWaves.Count)
            {
                // Get the selected down wave
                Wave selectedWave = downWaves[comboBox_downWave.SelectedIndex];
                // Set the isSelectUpWave flag to false
                isSelectUpWave = false;
                // Handle the selected down wave
                handleSelectWave(selectedWave);
            }
        }

        /// <summary>
        /// Function to handle the event when the user selects a wave from the comboBox_downWave
        /// </summary>
        /// <param name="selectedWave">The selected wave</param>
        private void handleSelectWave(Wave selectedWave)
        {
            // Get the x axis of the chart
            var axisX = chart_stockData.ChartAreas["ChartArea_OHLC"].AxisX;
            // Get the y axis of the chart
            var axisY = chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY;

            // Get the start index of the selected wave
            startPointIdx = selectedWave.startIndex;
            // Create a new point for the start point of the wave
            startPoint = new Point();
            // Set the x position of the start point
            startPoint.X = (int)axisX.ValueToPixelPosition(startPointIdx + 1);
            // Set the y position of the start point
            startPoint.Y = (int)axisY.ValueToPixelPosition((double)selectedWave.startPrice);
            // Get the end index of the selected wave
            endPointIdx = selectedWave.endIndex;
            // Create a new point for the end point of the wave
            currentPoint = new Point();
            // Set the x position of the end point
            currentPoint.X = (int)axisX.ValueToPixelPosition(endPointIdx + 1);
            // Set the y position of the end point
            currentPoint.Y = (int)axisY.ValueToPixelPosition((double)selectedWave.endPrice);
            // Set the isValidWaveSelected flag to true
            isValidWaveSelected = true;

            // Set the step size for the simulation
            stepSize = Math.Abs(currentPoint.Y - startPoint.Y) * 0.4 / numberOfSteps;
            // Annotate the confirmations
            annotateConfirmations();
            // Refresh the chart
            chart_stockData.Invalidate();
        }

        /// <summary>
        /// Function to check if the selected wave of the rubber banding operation is valid
        /// </summary>
        /// <returns>Boolean value indicating if the selected wave is valid</returns>
        private bool isValidWave()
        {
            // Get the start candlestick index of the wave
            int startCandlestickIdx = Math.Min(startPointIdx, endPointIdx);
            // Get the end candlestick index of the wave
            int endCandlestickIdx = Math.Max(startPointIdx, endPointIdx);

            // Check if the start and end index of the candlesticks are invalid
            if (startCandlestickIdx < 0 || endCandlestickIdx < 0 || startCandlestickIdx >= filteredCandlesticks.Count
                || endCandlestickIdx >= filteredCandlesticks.Count
                )
            {
                // Return false if the indices are invalid
                return false;
            }
            else
            {
                // Check if the selected wave is an up wave
                if (upWaves.Any(wave => wave.startIndex == startCandlestickIdx && wave.endIndex == endCandlestickIdx))
                {
                    // Set the isSelectUpWave to true
                    isSelectUpWave = true;
                    // Return true
                    return true;
                }

                // Check if the selected wave is a down wave
                if (downWaves.Any(wave => wave.startIndex == startCandlestickIdx && wave.endIndex == endCandlestickIdx))
                {
                    // Set the isSelectUpWave to false
                    isSelectUpWave = false;
                    // Return true
                    return true;
                }

                // Return false if the selected wave is not valid
                return false;
            }
        }



        /// <summary>
        /// Function to handle the mouse down event on the chart
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void chart_stockData_MouseDown(object sender, MouseEventArgs e)
        {
            // Declare a variable to store the hit test result of the mouse event
            HitTestResult hit = chart_stockData.HitTest(e.X, e.Y);

            // Declare a variable to indicate if the mouse is clicked on an extreme candlestick
            bool isHitAnExtreme = extremes.Any(extreme => extreme.index == hit.PointIndex);

            // Reset the end point index of the rubber banding operation
            endPointIdx = -1;
            // Set the index of the start point of the rubber banding operation
            startPointIdx = hit.PointIndex;
            // Reset the boolean value to indicate if a valid wave is selected
            isValidWaveSelected = false;
            // Set the start point of the rubber banding operation
            startPoint = e.Location;
            // Set the isDragging to true
            isDragging = true;
            // Check if the clicked candlestick is not a peak or valley
            if (!isHitAnExtreme)
            {
                // Set the isDragging to false
                isDragging = false;
                // Display an error message if the clicked candlestick is not a peak or valley
                MessageBox.Show("You must select a peak or valley candlestick for the rubber-banding operation.");
            }
        }

        /// <summary>
        /// Function to handle the mouse up event on the chart
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void chart_stockData_MouseUp(object sender, MouseEventArgs e)
        {
            // Set the isDragging to false
            isDragging = false;

            // Check if the selected wave is valid
            if (isValidWaveSelected)
            {
                // Set the step size for the simulation
                stepSize = Math.Abs(currentPoint.Y - startPoint.Y) * 0.4 / numberOfSteps;
            }
        }

        /// <summary>
        /// Function to handle the mouse move event on the chart
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void chart_stockData_MouseMove(object sender, MouseEventArgs e)
        {
            // Declare a variable to store the hit test result of the mouse event
            HitTestResult hit = chart_stockData.HitTest(e.X, e.Y);

            // Check if the mouse is being dragged and mouse is moved in the ohlc chart area
            if (isDragging && hit.ChartArea != null && hit.ChartArea.Name == "ChartArea_OHLC")
            {
                // Set the current point of the mouse in the chart area
                currentPoint = e.Location;
                // Set the end point index of the rubber banding operation
                endPointIdx = hit.PointIndex;
                // Check if the selected wave is valid
                isValidWaveSelected = isValidWave();
                // Annotate the confirmations in the chart
                annotateConfirmations();
                // Invalidate the chart to refresh the display
                chart_stockData.Invalidate();
            }
        }

        /// <summary>
        /// Function to annotate the confirmations in the chart
        /// </summary>
        private void annotateConfirmations()
        {
            // Loop through the confirmation annotations list
            foreach (var annotation in confirmationAnnotations)
            {
                // Remove the existing confirmation annotations from the chart
                chart_stockData.Annotations.Remove(annotation);
            }
            // Clear the confirmation annotations list
            confirmationAnnotations.Clear();
            // Check if the selected rectangle is a valid wave
            if (isValidWaveSelected)
            {
                // Get the x of the rectangle
                int x = startPoint.X;
                // Get the y of the rectangle
                int y = Math.Min(startPoint.Y, currentPoint.Y);
                // Get the height of the rectangle
                int height = Math.Abs(currentPoint.Y - startPoint.Y);

                // Declare a list to store the Fibonacci prices
                List<double> fibonnaciPrices = new List<double>();

                // Loop through the Fibonacci levels
                foreach (var level in fibonnaciLevels)
                {
                    // Calculate the y position of the Fibonacci level
                    double levelY = y + level * height;
                    // Add the Fibonacci level price to the list
                    fibonnaciPrices.Add(chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY.PixelPositionToValue(levelY));
                }

                // Calculate the margin for the confirmations
                var margin = Math.Abs(chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY.PixelPositionToValue(currentPoint.Y) - chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY.PixelPositionToValue(startPoint.Y)) * 0.015;

                // Loop through the candlesticks in the selected wave
                for (int i = startPointIdx; i <= endPointIdx; i++)
                {
                    // Get the candlestick at the current index
                    var candlestick = filteredCandlesticks[i];
                    // Declare a list to store the OHLC values
                    List<decimal> ohlc = new List<decimal> { candlestick.open, candlestick.high, candlestick.low, candlestick.close };

                    // Loop through the OHLC values
                    foreach (double price in ohlc)
                    {
                        // Loop through the Fibonacci prices
                        foreach (var fibonacciPrice in fibonnaciPrices)
                        {
                            // Check if the price is within the margin of the Fibonacci price
                            if (price >= fibonacciPrice - margin && price <= fibonacciPrice + margin)
                            {
                                // Create a new EllipseAnnotation for the confirmation
                                EllipseAnnotation confirmationAnnotation = new EllipseAnnotation
                                {
                                    // Set the axisX
                                    AxisX = chart_stockData.ChartAreas["ChartArea_OHLC"].AxisX,
                                    // Set the axisY
                                    AxisY = chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY,
                                    // Set the anchor data point
                                    AnchorDataPoint = chart_stockData.Series["Series_OHLC"].Points[i],
                                    // Set the Y position
                                    Y = (double)price,
                                    // Set the width
                                    Width = 0.6,
                                    // Set the height
                                    Height = 1.2,
                                    // Set the background color
                                    BackColor = Color.Yellow,
                                    // Set the anchor alignment
                                    AnchorAlignment = ContentAlignment.MiddleCenter,
                                };
                                // Add the confirmation annotation to the list
                                confirmationAnnotations.Add(confirmationAnnotation);
                                // Add the confirmation annotation to the chart
                                chart_stockData.Annotations.Add(confirmationAnnotation);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Function to handle the paint event of the chart
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void chart_stockData_Paint(object sender, PaintEventArgs e)
        {
            // Check if the user is dragging the mouse or a valid wave is selected
            if (isDragging || isValidWaveSelected)
            {
                // Get the graphics object from the event
                Graphics g = e.Graphics;

                // Get the x of the rectangle
                int x = startPoint.X;
                // Get the y of the rectangle
                int y = Math.Min(startPoint.Y, currentPoint.Y);
                // Get the width of the rectangle
                int width = Math.Abs(currentPoint.X - startPoint.X);
                // Get the height of the rectangle
                int height = Math.Abs(currentPoint.Y - startPoint.Y);

                // Declare pen to draw the rectangle
                using (var pen = new Pen(Color.Red, 2))
                {
                    // Draw the enclosing rectangle
                    g.DrawRectangle(pen, x, y, width, height);
                }
                // Declare pen to draw the diagonal line
                using (var pen = new Pen(Color.Red, 2))
                {
                    // Check if mouse is moving up
                    if (currentPoint.Y < startPoint.Y)
                    {
                        // Draw the diagonal line
                        g.DrawLine(pen, x, startPoint.Y, x + width, startPoint.Y - height);
                    }
                    // Check if mouse is moving down
                    else
                    {
                        // Draw the diagonal line
                        g.DrawLine(pen, x, y, x + width, y + height);
                    }
                }
                // Declare brush color based on selected wave
                var brushColor = (!isValidWaveSelected) ? Color.Yellow : (isSelectUpWave ? Color.Green : Color.Red);
                // Declare brush to fill the rectangle
                using (var fillBrush = new SolidBrush(Color.FromArgb(35, brushColor)))
                {
                    // Fill the rectangle on the chart
                    g.FillRectangle(fillBrush, x, y, width, height);
                }

                // Check if the selected rectangle is a valid wave
                if (isValidWaveSelected)
                {
                    // Check if the selected wave is a down wave
                    bool isDownWave = filteredCandlesticks[startPointIdx].high > filteredCandlesticks[endPointIdx].high;
                    // Declare a list to store the Fibonacci prices
                    List<double> fibonnaciPrices = new List<double>();

                    // Loop through the Fibonacci levels
                    foreach (var level in fibonnaciLevels)
                    {
                        // Calculate the y position of the Fibonacci level
                        int levelY = y + (int)(level * height);

                        // Declare a pen to draw the Fibonacci level line
                        using (var levelPen = new Pen(Color.Blue, 2))
                        {
                            // Draw the Fibonacci level line
                            g.DrawLine(levelPen, x, levelY, x + width, levelY);
                        }

                        // Declare a font to draw the Fibonacci level text
                        using (var levelFont = new Font("Arial", 10, FontStyle.Bold))
                        {
                            // Add the Fibonacci level price to the list
                            fibonnaciPrices.Add(chart_stockData.ChartAreas["ChartArea_OHLC"].AxisY.PixelPositionToValue(levelY));
                            // Format the Fibonacci level label
                            string label = $"{((isDownWave ? (1 - level) : level) * 100):0.0}% ({fibonnaciPrices.Last():0.000})";
                            // Draw the Fibonacci level text
                            g.DrawString(label, levelFont, Brushes.Black, x + width + 5, levelY - 10);
                        }
                    }
                }
            }
            // Set the label_confirmationsCount text to display the number of confirmations
            label_confirmationsCount.Text = $"Number of confirmations: {confirmationAnnotations.Count}";
        }

        /// <summary>
        /// Function to handle the click event of the button_simulate
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void button_simulate_Click(object sender, EventArgs e)
        {
            // Check if the simulation is not running
            if (!isSimulating)
            {
                // Set the isSimulating to true
                isSimulating = true;
                // Set the button_simulate text to "Stop"
                button_simulate.Text = "Stop";
                // Move the current point down
                currentPoint.Y += (int)(stepSize * (numberOfSteps / 2));
                // Disable the button_plus
                button_plus.Enabled = false;
                // Disable the button_minus
                button_minus.Enabled = false;
                // Annotate the confirmations in the chart
                annotateConfirmations();
                // Invalidate the chart to refresh the display
                chart_stockData.Invalidate();
            }
            // Check if the simulation is running
            else
            {
                // Stop the simulation
                stopSimulation();
            }
        }

        /// <summary>
        /// Function to handle the click event of the button_plus
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void button_plus_Click(object sender, EventArgs e)
        {
            // Check if valid wave is selected
            if (isValidWaveSelected)
            {
                // Move the current point up
                currentPoint.Y = Math.Max((int)(currentPoint.Y - stepSize), 0);
                // Annotate the confirmations in the chart
                annotateConfirmations();
                // Invalidate the chart to refresh the display
                chart_stockData.Invalidate();
            }
        }

        /// <summary>
        /// Function to handle the click event of the button_minus
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void button_minus_Click(object sender, EventArgs e)
        {
            // Check if valid wave is selected
            if (isValidWaveSelected)
            {
                // Move the current point down
                currentPoint.Y = (int)(currentPoint.Y + stepSize);

                // Annotate the confirmations in the chart
                annotateConfirmations();
                // Invalidate the chart to refresh the display
                chart_stockData.Invalidate();
            }
        }

        /// <summary>
        /// Function to handle the tick event of the timer_simulate
        /// </summary>
        /// <param name="sender">The control that triggered the event</param>
        /// <param name="e">Event data</param>
        private void timer_simulate_Tick(object sender, EventArgs e)
        {
            // Check if the simulation is running
            if (isSimulating)
            {
                // Check if the current step is less than the number of steps
                if (currentStep < numberOfSteps)
                {
                    // Move the current point up
                    currentPoint.Y = Math.Max((int)(currentPoint.Y - stepSize), 0);
                    // Check if the current point Y is 0
                    if (currentPoint.Y == 0)
                    {
                        // Stop the simulation
                        stopSimulation();
                    }
                    // Increment the current step
                    currentStep++;
                    // Annotate the confirmations in the chart
                    annotateConfirmations();
                    // Invalidate the chart to refresh the display
                    chart_stockData.Invalidate();
                }
                // Else if the current step is greater than or equal to the number of steps
                else
                {
                    // Stop the simulation
                    stopSimulation();
                }
            }
        }

        /// <summary>
        /// Function to stop the simulation
        /// </summary>
        private void stopSimulation()
        {
            // Stop the simulation
            isSimulating = false;
            // Set the button_simulate text to "Start"
            button_simulate.Text = "Start";
            // Enable the button_plus
            button_plus.Enabled = true;
            // Enable the button_minus
            button_minus.Enabled = true;
            // Reset the current step
            currentStep = 0;
        }
    }
}
