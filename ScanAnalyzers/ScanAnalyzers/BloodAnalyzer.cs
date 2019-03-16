/* Vasudev Vijayaraman & Jesse Houk
 * This class has all the methods regarding the Blood Analyzer and how it is operated
 * It has a default and parameterized constructor, methods that are overriden and also its own
 * unique method. BloodAnalyzer inherits from DNAANalyzer. To make the game more interesting, this class
 * inherits from its base class that implements greying out cells to keep the aesthetic of the game */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanAnalyzers
{
    class BloodAnalyzer : DNAAnalyzer // Inheritance 
    {
        // Default constructor calling the base class constructor
        public BloodAnalyzer() : base()
        {
            MakeDeadCells();
            KillCells(deadCells);
        }

        /* Parameterized Constructor that takes in the size, sampleLocations and form and it calls the base class constructor
           that holds the basic grid size of rows and columns, sample locations, defual image and the form */

        public BloodAnalyzer(Location size, Location[] sampleLocations, FindSampleGame form) : base(size, sampleLocations, form)
        {
            MakeDeadCells();
            KillCells(deadCells);
            EvidenceImage = "blood.jpg"; // Default image 
        }

        /* This method overrides the abstract method and prints a message when evidence is found 
           It takes in no parameters and returns nothing */

        public override string DiscoverMessage()
        {
            return "You have found evidence of blood at the crime screen to add to" +
                " the Evidence Collection";
        }

    }
}
