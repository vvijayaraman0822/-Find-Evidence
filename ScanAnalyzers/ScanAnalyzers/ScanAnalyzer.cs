/* Vasudev Vijayaraman & Jesse Houk
 * C# Programming - 10/22/2018
 * Dr. Catherine Stringfellow
 * This program is a guessing game using GUI components me that allows a player to solve 
 * puzzles by searching for clues to solve a murder mystery. There are 4 types of Analyzers to choose from
 * namely DNA, Fiber, Blood and FingerPrint. The data gets read in from an input file that sets the size of the 
 * picture grid. The user gets to choose the type of analyzer he/she wishes to play and the goal is to guess correctly
 * two secret loctions hidden. Hints will be provided accordingly to assist the user  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ScanAnalyzers
{
    public abstract class ScanAnalyzer
    {

        public Location[][] pictureGrid; // 2d Array of picture Boxes
        protected Location[] samples; // Array to hold any samples of an analyzer
        public static Random rand = new Random(Guid.NewGuid().GetHashCode()); // Instance to create random numbers
        private int rows;// Number of rows for grid
        private int columns; // Number of columns for the grid 
        protected string EvidenceImage; // Holds the name of the evidence image such as DNA/Fiber
        public bool IsComplete; // returns a  true or false

        /* This property accesses Rows since it is a private data member */
        public int Rows
        {
            get
            {
                return rows; // returns rows 
            }
            set
            {
                if (value >= 0) // makes sure rows are not 0
                {
                    rows = value;
                }
            }
        }
        /* This property accesses Columns since it is a private data member */
        public int Columns
        {
            get
            {
                return columns; // returns column
            }
            set
            {
                if (value >= 0) // makes sure columns are not 0
                {
                    columns = value;
                }
            }
        }

        // Default constructor
        public ScanAnalyzer()
        {

            SetGrid(0, 0); // Calls the Set Grid method that initializes the grid to 0 x 0
        }

        /* parameterized constructed taking in rows, columns, locations of the previously generated secret
         evidence locations, and the name of the evidence image, ending in a .png preferably and form as parameters.
         Takes in rows, columns, sample locations, image name and form as parameters */

        public ScanAnalyzer(int a, int b, Location[] sampleLocations, string nameOfImage, FindSampleGame form)
        {
            IsComplete = false; // sets the Iscomplete bool to false
            SetGrid(a, b); // set the size of the grid

            samples = sampleLocations; // Sample Locations
            MakeGrid(form); // Calling the make grid method
            form.analyzer = this; // Sets the current form 
        }


        /*This function is to reset grid everytime after the game is completed.
         It takes in no parameter and also returns nothing*/

        public void ResetGrid()
        {
            for (int r = 0; r < rows; r++) // To access the rows
            {

                for (int c = 0; c < columns; c++) // To access the column
                {
                    if (pictureGrid[r][c].ImageName != EvidenceImage) // AS long as the evidence not found, sets the grid to he basic one
                    {
                        pictureGrid[r][c].ChangeImage("GridSquare.jpg"); // Changes the image to the basic square
                    }

                }
            }

        }

        /* This method checks if row value and column value are greater than 0.
         * It takes rowValue and columnValue as parameters and returns void */

        public void SetGrid(int rowValue, int columnValue)
        {
            rows = (rowValue > 0) ? rowValue : 0;
            columns = (columnValue > 0) ? columnValue : 0;
        }

        /* This method checks if the user's guess is right or wrong, if it
         * is wrong, it is handled differently depending on how the derived class implements the
         * IncorrectGuess method. It takes in:
         * a - rows,
         * b - columns,
         * guess - how many clues have been found so far,
         * info - any additional information associated with the guess, such as
         *          a direction for the next hint
         * Returns:
         * bool - whether the user made a correct guess or not 
         */

        public bool EvaluateGuess(int a, int b, int guess, string info)
        {
            if (this is BloodAnalyzer || this is DNAAnalyzer) // If blood Analyzer or DNA Analyzer, do the grey out box
            {
                if (((DNAAnalyzer)this).CheckGreyedOut(a, b)) // Calls the CheckGreyedout method that actually greys out certain boxes
                {
                    MessageBox.Show("You have guessed a greyed out box. Guess again"); // If the user guesses a greyed out box 
                    return false; // set flag to false 
                }
            }
            // sample the user is trying to find
            Location userSample = new Location(samples[guess].Row, samples[guess].Column); // Initializing user the sample Array

            if (userSample.Row == a && userSample.Column == b) // checks to see if the user the found correct row and column sample
            {
                pictureGrid[a][b].ChangeImage(EvidenceImage); // If user gets the right guess, print the evidence image 
                samples[guess].Found = true; // Sets the flag to true once user finds a clue 
                ResetGrid(); // Resets the grid 

                // If DNA or Blood ANalyzer, kill cells decides how many boxes to grey out
                if (this is DNAAnalyzer || this is BloodAnalyzer)
                {
                    ((DNAAnalyzer)this).KillCells(((DNAAnalyzer)this).deadCells); // Kill Cells and Dead Cells method 
                }
                return true; // returns true
            }
            else
            {
                IncorrectGuess(a, b, userSample, info); // If user does not get the right guess, then call the incorrect guess method

                return false; // sets the flag to false 
            }

        }

        /* This method calculates where the grid shuld be printed on the form 
         * It takes in rows and columns as parameters and prints the new location to print the grid 
         * at */

        public Location CalculatePosition(int r, int c)
        {
            int x = 225 + (20 * c);
            int y = 225 + (20 * r);
            return new Location(x, y); // returns new location
        }


        /* This method handles the case when the user enters a wrong guess. 
         * It takes in a, b, userSample, info as parameters and retruns nothing */

        public void IncorrectGuess(int a, int b, Location userSample, string info)
        {

            if (userSample.Row == a) // If user's row is same as secret location row 
                checkColumn(a, b, userSample.Column); // To check if it is the right column

            else
            {
                if (userSample.Column == b) // If user's row is same as secret location column
                    checkRow(a, b, userSample.Row); // To check if it is the right row 
                else
                {
                    if (info == "cross") // checks for which direction type to give, up-down, left-right
                        checkColumn(a, b, userSample.Column); // To check if it is the right column
                    else
                        checkRow(a, b, userSample.Row); // Else check the row 
                }
            }
        }

        /* This method checks to see if the user guessed the right row.
         * It takes in rows, columns and UserSample as parameters and returns nothing */

        public void checkRow(int rows, int columns, int userSample)
        {
            if (rows > userSample) // if  user guess rows greater than the secret lcoation row
                pictureGrid[rows][columns].ChangeImage("Up_Arrow.png"); // Prints the Up Arrow image 
            else
            {
                if (rows < userSample) // if  user guess rows lesser than the secret lcoation row
                    pictureGrid[rows][columns].ChangeImage("Down_Arrow.png"); // Prints the down Arrow image 
            }
        }

        /* This method checks to see if the user guessed the right column.
        * It takes in rows, columns and UserSample as parameters and returns nothing */

        public void checkColumn(int rows, int columns, int userSample)
        {
            if (columns > userSample) // if it is to the left side of the column
                pictureGrid[rows][columns].ChangeImage("Left_Arrow.jpg"); // goes to that grid and prints left arrow image

            else
            {
                if (columns < userSample) // if it is right hand side of the column
                    pictureGrid[rows][columns].ChangeImage("Right_Arrow.jpg"); // goes to that grid and prints the right arrow image 
            }
        }

        /* This method executes when the user gets the right guess. It prints a success message along with 
         * setting the Found Object flag to true. It takes in rows and columns as parameters and returns nothing */


        public void FoundObject(int row, int column)
        {
            pictureGrid[row][column].Found = true; // Sets the found to be true
            MessageBox.Show(DiscoverMessage(), FOUND_DISCOVERY, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Message
        }

        public abstract string DiscoverMessage(); // Abstract method to be overriden in derived class that prints a message

        /* This method prints a message saying the evidence has been found */

        public static string FOUND_DISCOVERY
        {
            get
            {
                return "FOUND EVIDENCE"; // Returns a message
            }
        }

        /**
         * Determines if user Guess is == to Clue coordinates
         * 
         * @param: guess
         * @return: bool
         **/
        public bool IsMatch(int guess)
        {
            Location userSample = new Location(samples[guess].Row, samples[guess].Column); // Sets a new lcoation after user guess is right
            return (rows == userSample.Row && columns == userSample.Column) ? true : false; // returns condition accordingly
        }

        /* This method hides the grid. It takes in no parameters and returns nothing */

        public void HideGrid()
        {
            foreach (Location[] pbArr in pictureGrid) // For each loop to access the picture grid 
            {
                foreach (Location pb in pbArr)
                {
                    pb.picture.Visible = false; // Sets the visibility to False 
                }
            }
        }

        /* This method makes the actual grid that is displayed on the form. It takes in the FindSampleGame form as 
         * parameters and returns nothing */

        public void MakeGrid(FindSampleGame form)
        {
            pictureGrid = new Location[Rows][];
            for (int i = 0; i < Rows; i++) // Access rows
            {
                pictureGrid[i] = new Location[Columns]; // Sets a new lcoation on the picture grid row 
            }
            for (int i = 0; i < Rows; i++) // Rows 
            {
                for (int j = 0; j < Columns; j++) // Columns 
                {
                    Location pos = CalculatePosition(i, j); // Creates a new position on the grid 
                    pictureGrid[i][j] = new Location(pos.Row, pos.Column);
                    pictureGrid[i][j].picture = new PictureBox();

                    form.Controls.Add(pictureGrid[i][j].picture); // Adds the picture to the controls on the form 
                }
            }
        }
    }

}










