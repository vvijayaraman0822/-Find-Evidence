/* Vasudev Vijayaraman & Jesse Houk
 * This class has all the methods regarding the Fingerprint Analyzer and how it is operated
 * It has a default and parameterized constructor and some methods that are overriden. FingerPrint Analyzer
 * inherits from ScanAnalyzer */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanAnalyzers
{

    class FingerprintAnalyzer : ScanAnalyzer // Inheritance
    {

        // Default constructor, calls the default constructor of the base class too
        public FingerprintAnalyzer() : base()
        {

        }

        /* Parameterized Constructor that takes in Location size which holds the Rows and Columns,
           sample location that holds the secret location and it calls the base class constructor
           that holds the basic grid size of rows and columns, sample locations and also the image. 
           it also calls the abse class consructor that contains the size of row, column, sample location,
           name of the default image and the form iself
        */

        public FingerprintAnalyzer(Location size, Location[] sampleLocations, FindSampleGame form) : base(size.Row, size.Column, sampleLocations, "GridSquare.jpg", form)
        {
            EvidenceImage = "fingerprint.jpg";
        }

        /* This method overrides the abstract method and prints a message when evidence is found 
            It takes in no parameters and returns nothing */

        public override string DiscoverMessage()
        {
            return "FingerPrint has been found. Good job!";
        }


    }
}
