using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisCS
{
    // 
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

            // Get the date string from the first token
            string dateString = tokens[0];
            // Parse the date string into a DateTime object and assign it to the date property
            date = DateTime.Parse(dateString);

            // Declare a temporary variable to store the parsed decimal value
            decimal temp;

            // Try to parse the second token as a decimal
            bool success = decimal.TryParse(tokens[1], out temp);
            // If parsing was successful, assign the value to the open price property
            if (success) open = temp;

            // Try to parse the third token as a decimal
            success = decimal.TryParse(tokens[2], out temp);
            // If parsing was successful, assign the value to the high price property
            if (success) high = temp;

            // Try to parse the fourth token as a decimal
            success = decimal.TryParse(tokens[3], out temp);
            // If parsing was successful, assign the value to the low price property
            if (success) low = temp;

            // Try to parse the fifth token as a decimal
            success = decimal.TryParse(tokens[4], out temp);
            // If parsing was successful, assign the value to the close price property
            if (success) close = temp;

            // Declare a temporary variable to store the parsed ulong value
            ulong parsedVolume;

            // Try to parse the sixth token as a ulong
            success = ulong.TryParse(tokens[5], out parsedVolume);
            // If parsing was successful, assign the value to the volume property
            if (success) volume = parsedVolume;
        }
    }
}
