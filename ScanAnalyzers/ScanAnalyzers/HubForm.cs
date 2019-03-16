/* Vasudev Vijayaraman & Jesse Houk
 * This form is where the user chooses what type of Analyzer they want to play. They have 4
 * options to choose from. It also has instructions on how to play the game. It contains information of
 * all the evidence colelcted so far */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanAnalyzers
{
    public partial class HubForm : Form
    {
        public static ScanAnalyzer[] Scan; // Contains the type of ScanAnalyzer
        public static Location[][] SecretLocations; // Array containing seret locations
        public string AnalyzerChecked; // Contains which Analyzer is checked
        public FindSampleGame sampleGame; // The form where the actual game is played
        public HubForm()
        {
            InitializeComponent();

            SecretLocations = new Location[4][]; // Contains 4 types of ScanAnalyers
            Scan = new ScanAnalyzer[4];
            for (int i = 0; i < 4; i++) // iterate through the 4 types of ScanAnalyzer
            {
                SecretLocations[i] = new Location[2]; // Every ScanAnalyzer has two locations each
                for (int j = 0; j < 2; j++) // // iterate through the 2 secret location
                {
                    Location secret = NewRandomLocation(SecretLocations[i], i);
                    SecretLocations[i][j] = new Location(secret.Row, secret.Column); // Sets the secret location
                }

            }
        }
        /* This method switches from one form to another depending on where we are at the game.
         * It takes in no parameters and returns nothing */

        private void SwitchForm()
        {
            FindSampleGame sample = new FindSampleGame(); // Creates a new sample game form 
            sample.Show();  //shows the sample game form
            this.Hide(); // Hides the current form 
        }

        /* This method Enters the game on a click and guessing game begins.
        * It takes in object sender and EventArgs e as parameters and returns nothing */

        private void enterButton_Click(object sender, EventArgs e)
        {
            bool shouldLoad = false; // Set the load to false 
            int i = 0; // set i
            sampleGame = new FindSampleGame();

            /* Th following logic checks to see what type of anaylyzer is chosen through the use
             * of radio button and cases are created accordingly */

            AnalyzerChecked = "";
            if (fingerprintRadioButton.Checked)
            {
                AnalyzerChecked = "fingerprint";
            }
            else if (dnaAnalyzerRadioButton.Checked)
            {
                AnalyzerChecked = "dna";
            }
            else if (bloodAnalyzerRadioButton.Checked)
            {
                AnalyzerChecked = "blood";
            }
            else if (fiberAnalyzerRadioButton.Checked)
            {
                AnalyzerChecked = "fiber";
            }
            switch (AnalyzerChecked)
            {
                case "fingerprint":
                    {

                        if (!(Scan[i] is null) && Scan[i].IsComplete) // If both the locations are guessed correctly
                        {
                            AlreadyPlayed(); // Calls the already played method that prints a message 

                        }
                        else
                        {
                            Scan[i] = new FingerprintAnalyzer(ReadDataForm.GridSizes[i], SecretLocations[i], sampleGame);
                            shouldLoad = true; // else sets the shouldLoad to true
                        }
                        break;
                    }
                case "fiber":
                    {
                        i = 1; // Keep incrementing i
                        if (!(Scan[i] is null) && Scan[i].IsComplete) // If both the locations are guessed correctly
                        {
                            AlreadyPlayed(); // Calls the already played method that prints a message

                        }
                        else
                        {
                            Scan[i] = new FiberAnalyzer(ReadDataForm.GridSizes[i], SecretLocations[i], sampleGame);
                            shouldLoad = true; // else sets the shouldLoad to true
                        }
                        break;
                    }
                case "dna":
                    {
                        i = 2;
                        if (!(Scan[i] is null) && Scan[i].IsComplete) // If both the locations are guessed correctly
                        {
                            AlreadyPlayed(); // Calls the already played method that prints a message

                        }
                        else
                        {
                            Scan[i] = new DNAAnalyzer(ReadDataForm.GridSizes[i], SecretLocations[i], sampleGame);
                            shouldLoad = true; // else sets the shouldLoad to true
                        }
                        break;
                    }
                case "blood":
                    {
                        i = 3;
                        if (!(Scan[i] is null) && Scan[i].IsComplete) // If both the locations are guessed correctly
                        {
                            AlreadyPlayed(); // Calls the already played method that prints a message

                        }
                        else
                        {
                            Scan[i] = new BloodAnalyzer(ReadDataForm.GridSizes[i], SecretLocations[i], sampleGame);
                            shouldLoad = true; // else sets the shouldLoad to true
                        }
                        break;
                    }

            }
            if (shouldLoad) // If shouldLoad is true 
            {
                sampleGame.analyzer = Scan[i];
                sampleGame.MakePictures(); // Make pictures 
                sampleGame.hub = this; // current form
                sampleGame.Show(); // show the sample game form 
                this.Hide(); // hide the current form 

            }
        }

        /* This method creates a new random location everytime. It takes in the analyzer and the location
         * as parameters and returns a new lcoation */
        private Location NewRandomLocation(Location[] points, int analyzer)
        {
            bool repeat; // declare a fool
            Location sample;
            do
            {
                repeat = false;
                sample = new Location(ScanAnalyzer.rand.Next(0, ReadDataForm.GridSizes[analyzer].Row),
                    ScanAnalyzer.rand.Next(0, ReadDataForm.GridSizes[analyzer].Column)); // Sets a new location of rows and columns
                for (int j = 0; j < 2; j++) // 2 lcoations present 
                {
                    // check previous sample j locations against sample i
                    if (!(points[j] is null) &&
                        points[j].Found && sample.Row == points[j].Row &&
                        sample.Column == points[j].Column)
                    {
                        repeat = true;
                    }
                }

            } while (repeat); // repeat while while loop terminates

            return sample; // returns the sample
        }
        /* This methid prints a message when the user collects both the random location and tries to play the same
         * type of ScanAnalyzer. This protects the integrity of the game so the user can try all 4 types of ScanAnalyzers
         * It takes in no parameters and returns nothing */

        public void AlreadyPlayed()
        {
            MessageBox.Show("You Have already completed this type of Scan Analyzer" +
                ". Please try a new type of Scan Analyzer", "Try Another Game",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // MessageBox
        }

        /* This method prints the type and number of samples collected. It takes in object sender and EventArgs e as
         * parameters and returns nothing */

        private void EvidenceCollectionButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The following are the samples you have collected:" + Environment.NewLine +
                "Fingerprint Samples - " + EvidenceCollection.FingerSamples + Environment.NewLine +
                "Fiber Samples - " + EvidenceCollection.FiberSamples + Environment.NewLine +
                "DNA Samples - " + EvidenceCollection.DNASamples + Environment.NewLine +
                "Blood Samples - " + EvidenceCollection.BloodSamples + Environment.NewLine,
                "Evidence Collection", MessageBoxButtons.OK);
        }
    }
}
