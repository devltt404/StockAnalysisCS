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
    }
}
