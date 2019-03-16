/* Vasudev Vijayaraman & Jesse Houk
 * This class has all the methods regarding the DNA Analyzer and how it is operated
 * It has a default and parameterized constructor, methods that are overriden and also its own
 * unique method DNA inherits from ScanAnalyzer. To make the game more interesting, this class
 * also implements greying out cells to keep the aesthetic of the game */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanAnalyzers
{
    class DNAAnalyzer : ScanAnalyzer // inheritance
    {
        // an array of the cells that will not be acceptable to guess
        public Location[] deadCells;

        // Defualt constructor that calls the base class constructor 
        public DNAAnalyzer() : base()
        {
            MakeDeadCells();
        }

        /* Parameterized Constructor that takes in the size, sampleLocations and form and it calls the base class constructor
            that holds the basic grid size of rows and columns, sample locations, defualt image and the form */

        public DNAAnalyzer(Location size, Location[] sampleLocations, FindSampleGame form) : base(size.Row, size.Column, sampleLocations, "GridSquare.jpg", form)
        {
            MakeDeadCells();
            EvidenceImage = "DNA.jpg"; // Default image

        }

        /* This method overrides the abstract method and prints a message when evidence is found 
           It takes in no parameters and returns nothing */
        public override string DiscoverMessage()
        {
            return "You have found DNA evidence to add to the Evidence Collection";
        }

        // This method used for constructing a new instance of the class and greys
        // the number of rows * columns divided by 4. It takes in no parameters and returns nothing.
        // It is protected so derived class can use it 
        protected void MakeDeadCells()
        {
            deadCells = new Location[(Rows * Columns) / 4]; // 1/4th greyout cells
            InsertsWithNoRepeats((Rows * Columns) / 4);
            KillCells(deadCells);
        }



        //This method is used to make an array of Locations that are the disable cells
        // It takes in inserts as parameters and returns nothing. 

        protected void InsertsWithNoRepeats(int inserts)
        {
            deadCells = new Location[inserts];
            bool repeat; // create a bool

            // Random cells being greyed out
            deadCells[0] = new Location(ScanAnalyzer.rand.Next(0, Rows),
                ScanAnalyzer.rand.Next(0, Columns));

            // prevent any other samples from being the same Location as sample 1
            for (int i = 0; i < inserts; i++)
            {
                do
                {
                    repeat = false; // sets flag to false 

                    deadCells[i] = new Location(ScanAnalyzer.rand.Next(0, Rows),
                        ScanAnalyzer.rand.Next(0, Columns));
                    // do not make a cell dead twice
                    for (int j = 0; j < i && !repeat; j++)
                    {
                        // check previous sample j locations against sample i
                        if (deadCells[i].Row == deadCells[j].Row && deadCells[i].Column == deadCells[j].Column)
                        {
                            repeat = true; // sets flag to true 
                        }
                    }
                    // do not make a dead cell where a secret is
                    for (int j = 0; j < samples.Length; j++)
                    {
                        // If greyed out cells and secret location are the same 
                        if (deadCells[i].Row == samples[j].Row && deadCells[i].Column == samples[j].Column)
                        {
                            repeat = true; // sets the flag to rtue 
                        }
                    }

                } while (repeat);

            }
        }

        // This method prints the greyed out image to the dead cells . It takes in an array of cells
        // as parameters and returns nothing.

        public void KillCells(Location[] cells)
        {
            for (int i = 0; i < cells.Length; i++) // cells length 
            {
                pictureGrid[cells[i].Row][cells[i].Column].ChangeImage("DeadCell.jpg"); // Changes the image to greyed out
            }
        }

        /* This method checks to see if the grid is greyed out or not. It takes in rows and columns
         * as parameters and returns nothing */

        public bool CheckGreyedOut(int r, int c)
        {
            for (int i = 0; i < deadCells.Length; i++)
            {
                if (r == deadCells[i].Row && c == deadCells[i].Column) // If rows and columns are same 
                {
                    return true; // sets flag to true 
                }
            }
            return false; // else return false

        }
    }
}