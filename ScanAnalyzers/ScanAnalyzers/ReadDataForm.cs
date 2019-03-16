/* Vasudev Vijayaraman & Jesse Houk
 * This the form where the name of the data file is read in. The name of the file is "data_1.txt".
 * Once it reads in the file, it switches the form where you can choose what analyzers to play from */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ScanAnalyzers
{
    public partial class ReadDataForm : Form
    {
        public static string fileName; // contains the filename 
        public static HubForm hub; // Static hub

        private static Location[] gridSizes;
        public ReadDataForm()
        {
            InitializeComponent();
        }

        /* This method starts the actual game after reading in the data file.
         * It takes in object sender and EventArgs e as parameters and returns nothing */

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            fileName = FileNameTextBox.Text; // Stores the file name in a variable 
            ReadFile(); // Reads in the file name from the textbox

            SwitchForm(); // Switches form 
        }

        /* This property returns the gridSizes which is static so can be used just with class name */

        public static Location[] GridSizes
        {
            get
            {
                return gridSizes;
            }
            set
            {

            }
        }
        /* This method is where the data file is read. Our data file contains 4 lines. 
         * Each line has a grid size that is respective of one of the type of ScanAnalyzers.
         * It takes in no parameters and returns nothing */

        private void ReadFile()
        {
            //create reference to stream
            StreamReader textIn;
            //open stream to file 
            textIn = new StreamReader(new FileStream(Directory.GetCurrentDirectory() + "\\" + fileName, FileMode.Open,
                       FileAccess.Read));
            gridSizes = new Location[4];

            // get rows and columns from data file
            for (int i = 0; i < 4; i++)
            {
                string[] fItem = textIn.ReadLine().Split(' '); // Split the string on a space and store it in fItem
                gridSizes[i] = new Location(Int32.Parse(fItem[0]), Int32.Parse(fItem[1])); // Contains the rows and columns of grid size
            }
            textIn.Close(); // Closes the text file after reading the data 
        }

        /* This method switches from one form to another depending on where we are at the game.
         * It takes in no parameters and returns nothing */

        private void SwitchForm()
        {
            hub = new HubForm(); // creates a new instance of hubform 
            hub.Show(); // Show the hub form 
            this.Hide(); // Hides the current form 
        }
    }
}
