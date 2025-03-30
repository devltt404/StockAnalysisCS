using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisCS
{
    // Class to store the stock wave data
    internal class Wave
    {
        // Property to store the start date of the wave
        public DateTime startDate { get; set; }
        // Property to store the end date of the wave
        public DateTime endDate { get; set; }
        // Property to store the start price of the wave
        public decimal startPrice { get; set; }
        // Property to store the end price of the wave
        public decimal endPrice { get; set; }
        // Property to store the index of the start of the wave in the list of data points
        public int startIndex { get; set; }
        // Property to store the index of the end of the wave in the list of data points
        public int endIndex { get; set; }

        /// <summary>
        /// Constructor to initialize the wave object
        /// </summary>
        /// <param name="startDate">Wave's start date</param>
        /// <param name="endDate">Wave's end date</param>
        /// <param name="startPrice">Wave's start price</param>
        /// <param name="endPrice">Wave's end price</param>
        /// <param name="startIndex">Wave's start index</param>
        /// <param name="endIndex">Wave's end index</param>
        public Wave(DateTime startDate, DateTime endDate, decimal startPrice, decimal endPrice, int startIndex, int endIndex)
        {
            // Assign the start date property
            this.startDate = startDate;
            // Assign the end date property
            this.endDate = endDate;
            // Assign the start price property
            this.startPrice = startPrice;
            // Assign the end price property
            this.endPrice = endPrice;
            // Assign the start index property
            this.startIndex = startIndex;
            // Assign the end index property
            this.endIndex = endIndex;
        }
    }
}
