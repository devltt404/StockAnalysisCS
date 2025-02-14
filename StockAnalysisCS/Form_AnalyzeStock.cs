using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAnalysisCS
{
    public partial class Form_AnalyzeStock : Form
    {
        public Form_AnalyzeStock()
        {
            InitializeComponent();
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

        }
    }
}
