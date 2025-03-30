using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisCS
{
    // Class to store the extreme data (peak or valley)
    internal class Extreme
    {
        // Property to store the date of the extreme
        public DateTime date { get; set; }
        // Property to store the price of the extreme
        public decimal price { get; set; }
        // Property to store the type of the extreme (peak or valley)
        public bool isPeak { get; set; }
        // Property to store the index of the extreme in the list of data points
        public int index { get; set; }

        /// <summary>
        /// Constructor to create an Extreme object
        /// </summary>
        /// <param name="date">The date of the extreme</param>
        /// <param name="price">The price of the extreme</param>
        /// <param name="isPeak">Boolean value to check if extreme is peak or valley</param>
        /// <param name="index">The index of the extreme in the list of data points</param>
        public Extreme(DateTime date, decimal price, bool isPeak, int index)
        {
            // Assign the date property
            this.date = date;
            // Assign the price property
            this.price = price;
            // Assign the isPeak property
            this.isPeak = isPeak;
            // Assign the index property
            this.index = index;
        }
    }
}
