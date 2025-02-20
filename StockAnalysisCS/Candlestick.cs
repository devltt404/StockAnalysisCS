using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace StockAnalysisCS
{
    internal class Candlestick
    {
        // Property to store the date of the candlestick
        public DateTime date { get; set; }
        // Property to store the opening price of the stock on the day
        public decimal open { get; set; }
        // Property to store the closing price of the stock on the day
        public decimal close { get; set; }
        // Property to store the highest price of the stock on the day
        public decimal high { get; set; }
        // Property to store the lowest price of the stock on the day
        public decimal low { get; set; }
        // Property to store the number of shares traded on the day
        public ulong volume { get; set; }

        /// <summary>
        /// Constructor to create a Candlestick object from a row of stock data values
        /// </summary>
        /// <param name="rowOfData">
        /// A string representing a row of stock data in the format:
        /// "Date,Open,High,Low,Close,Volume"
        /// Example: "2024-08-15",9.9,10.1,9.9,10.1,32307255
        /// </param>
        public Candlestick(string rowOfData)
        {
            // Define the separators used to split the row of data
            char[] separators = new char[] { ',', '"' };

            // Split the row of data into an array of string tokens using the separators and removing empty tokens
            string[] tokens = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Check if the number of tokens is not equal to 6
            if (tokens.Length != 6)
            {
                // Throw an exception indicating that the data format is invalid
                throw new ArgumentException("Invalid data format.");
            }

            // Parse the date property
            date = DateTime.ParseExact(tokens[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            // Parse the open price property
            open = Math.Round(decimal.Parse(tokens[1]), 2);
            // Parse the high price property
            high = Math.Round(decimal.Parse(tokens[2]), 2);
            // Parse the low price property
            low = Math.Round(decimal.Parse(tokens[3]), 2);
            // Parse the close price property
            close = Math.Round(decimal.Parse(tokens[4]), 2);
            // Parse the volume property
            volume = ulong.Parse(tokens[5]);
        }
    }
}
