/* Vasudev Vijayaraman & Jesse Houk 
 * This is the form where the guessing game is played. The picture grid is printed on this form,
 * the user can submit a guess and the picture grid changes according to the guess. Prints either a hint
 * image or a evidence image */

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
    public partial class FindSampleGame : Form
    {
        int numberSample = 0; // Setting sample to 0
        string appear = "cross"; // Initializing appear
        public ScanAnalyzer analyzer;
        public HubForm hub; // Hubform
        public FindSampleGame()
        {
            InitializeComponent();
            LogoPictureBox.Image = Image.FromFile("MagniGlass.jpg"); // Loads the Logo of evidence 
            SubGuessButton.Enabled = true; // Guess button disabled after program loads 
            RowsLabel.Text = ""; // Initialize the label containing subscript 
            ColumnsLabel.Text = "";

        }

        /* This method lets you submit a guess. Guess is in the form rows and columns.
         * It takes in object sender and EventArgs e as parameters and returns nothing */

        private void SubGuessButton_Click(object sender, EventArgs e) // Guess Button click
        {

            try // Try block 
            {
                int guessRows = int.Parse(guessTextBoxRows.Text); // guess Rows from the user
                int guessColumn = int.Parse(guessTextBoxColumn.Text); // guess Column from the user

                if (analyzer.EvaluateGuess(guessRows, guessColumn, numberSample, appear) == true)  // If the guess is right
                {
                    analyzer.FoundObject(guessRows, guessColumn); // Calls the method Found Object

                    numberSample++; // increment number sample collected

                    /* This logic is to keep track of the number of each samples collected */

                    if (analyzer is FiberAnalyzer)
                    {
                        EvidenceCollection.FiberSamples++;
                    }
                    else if (analyzer is FingerprintAnalyzer)
                    {
                        EvidenceCollection.FingerSamples++;
                    }
                    else if (analyzer is BloodAnalyzer)
                    {
                        EvidenceCollection.BloodSamples++;
                    }
                    else if (analyzer is DNAAnalyzer)
                    {
                        EvidenceCollection.DNASamples++;
                    }

                }

                else
                {
                    appear = (appear == "cross" ? "down" : "cross"); // Appear changes accoringly
                }


                if (numberSample == 2) // If both samples have been collected , prints a message box 
                {
                    if (MessageBox.Show("You have guessed it correctly, do you want " +
                        "to try another analyzer?", "Congratulations", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        analyzer.IsComplete = true; // Sets the IsComplete bool to true 
                        numberSample = 0; // Sets it back to 0

                        SwitchForm(); // Switches form 
                    }
                    else // quit game
                        this.Close(); // Closes the game 
                }
            }

            catch (Exception ex) // Catch block 
            {

                if (ex.ToString().Contains("Input string was not in a correct format")) // Exception thrown

                    MessageBox.Show("Please make sure to enter all the fields"); // show the message

                else
                {
                    // if the guess is outside of the grid the user is prompted to enter a new guess
                    if (ex.ToString().Contains("Index was outside the bounds of the array"))
                        MessageBox.Show("You have exited the range. Please guess within the range"); // show the message 

                    else
                        MessageBox.Show(ex.ToString()); // Else show the default message 
                }
            }
        }
        /* This method switches from one form to another. It takes in no parameters and returns nothing */

        private void SwitchForm()
        {
            ReadDataForm.hub.Show(); // Shows the hub form 
            analyzer.HideGrid(); // Hides the grid 
            this.Hide(); // Hide the current form
        }
        /* Thi method makes the picture that needs to be printed at first and also prints the subscript of the 
         * rows and columns that needs to be printed. It takes in no parameters and returns nothing */
        public void MakePictures()
        {

            analyzer.pictureGrid = new Location[analyzer.Rows][];
            for (int i = 0; i < analyzer.Rows; i++) // Rows
            {
                analyzer.pictureGrid[i] = new Location[analyzer.Columns]; // Columns
                for (int j = 0; j < analyzer.Columns; j++)
                {
                    analyzer.pictureGrid[i][j] = new Location(i, j);
                    Location pos = analyzer.CalculatePosition(i, j); // Sets the location
                    analyzer.pictureGrid[i][j].picture.Location = new System.Drawing.Point(pos.Row, pos.Column); // Sets the location on form
                    analyzer.pictureGrid[i][j].picture.SizeMode = PictureBoxSizeMode.StretchImage; // Mode
                    analyzer.pictureGrid[i][j].picture.BorderStyle = BorderStyle.FixedSingle; // Border style
                    analyzer.pictureGrid[i][j].picture.BackColor = Color.Aqua; // BackGround Color
                    analyzer.pictureGrid[i][j].picture.Size = new Size(20, 20); // Size of picture
                    analyzer.pictureGrid[i][j].picture.Anchor = AnchorStyles.Left; // Anchor
                    analyzer.pictureGrid[i][j].picture.Visible = true; // Visibility
                    analyzer.pictureGrid[i][j].picture.Image = Image.FromFile("GridSquare.jpg");
                    analyzer.pictureGrid[i][j].picture.Load(Directory.GetCurrentDirectory() + "\\" + "GridSquare.jpg"); // Location of img
                    analyzer.pictureGrid[i][j].ImageName = "GridSquare.jpg"; // Name of the image 
                    this.Controls.Add(analyzer.pictureGrid[i][j].picture); // Adds it to the controls
                }
            }
            for (int i = 0; i < analyzer.Rows; i++) // Prints the subscript for the rows 
            {
                RowsLabel.Text += i + Environment.NewLine;

            }
            for (int i = 0; i < analyzer.Columns; i++) // Prints the subscript for the column
            {
                ColumnsLabel.Text += i + "  ";
            }

        }
        /* This methid quits the current game and goes back to the form where the user
         * gets to choose what type of analyzer they want to play. It takes in sender and e
         * as parameters and returns nothing */

        private void QuitButton_Click(object sender, EventArgs e)
        {
            MakePictures(); // Calls the method
            hub.Show(); // Shows the hub form
            this.Hide(); // hides the current form 
        }

        /* Thi method is shows what type of analyzer is being played and also shows the text file
         * being read. It takes in sender and e as arguments and returns nothing */

        private void FindSampleGame_Shown(object sender, EventArgs e)
        {
            TitleLabel.Text = ReadDataForm.fileName + "\n"; // Prints the file name in the label

            /* This logic prints what type of analyzer is played and prints it accordingly on the label */

            if (analyzer is FingerprintAnalyzer)
            {
                TitleLabel.Text += "Fingerprint Analyzer";
            }
            else if (analyzer is BloodAnalyzer)
            {
                TitleLabel.Text += "Blood Analyzer";

                // Prints a message saying you cannot click the greyed out cells 
                ((BloodAnalyzer)analyzer).KillCells(((BloodAnalyzer)analyzer).deadCells);
                MessageBox.Show("Just remember you cannot guess the greyed out grid cells", "WARNING",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (analyzer is DNAAnalyzer)
            {
                TitleLabel.Text += "DNA Analyzer";

                // Prints a message saying you cannot click the greyed out cells 
                ((DNAAnalyzer)analyzer).KillCells(((DNAAnalyzer)analyzer).deadCells);
                MessageBox.Show("Just remember you cannot guess the greyed out grid cells", "WARNING",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (analyzer is FiberAnalyzer)
            {
                TitleLabel.Text += "Fiber Analyzer";
            }
        }
    }
}



