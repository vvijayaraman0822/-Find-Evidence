/* Vasudev Vijayaraman & Jesse Houk
 * This class keeps track of the type of the analyzer collected and the number collected. 
 * It has static member data and mostly getters and setters */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanAnalyzers
{
    class EvidenceCollection
    {
        /* Private property to access the sample name and their counter */
        static private int fingerSamples;
        static private int fiberSamples;
        static private int dnaSamples;
        static private int bloodSamples;
        static private int sampleNumber;

        /* Public property to get and set the sampleNumber */
        static public int SampleNumber
        {
            get
            {
                return sampleNumber;
            }
            set
            {
                if (value >= 0) // Makes sure value is more than 0
                {
                    sampleNumber = value; // sets the value
                }
            }
        }

        /* Public property to get and set the FingerPrint Sample */
        static public int FingerSamples
        {
            get
            {
                return fingerSamples;
            }
            set
            {
                if (value >= 0) // Makes sure value is more than 0
                {
                    fingerSamples = value; // sets the value

                }
            }
        }
        /* Public property to get and set the Fiber Sample */
        static public int FiberSamples
        {
            get
            {
                return fiberSamples;
            }
            set
            {
                if (value >= 0) // Makes sure value is more than 0
                {
                    fiberSamples = value; // sets the value

                }
            }
        }

        /* Public property to get and set the DNA Sample */
        static public int DNASamples
        {
            get
            {
                return dnaSamples;
            }
            set
            {
                if (value >= 0) // Makes sure value is more than 0
                {
                    dnaSamples = value; // sets the value

                }
            }
        }

        /* Public property to get and set the Blood Sample */
        static public int BloodSamples
        {
            get
            {
                return bloodSamples;
            }
            set
            {
                if (value >= 0) // Makes sure value is more than 0
                {
                    bloodSamples = value; // sets the value

                }
            }
        }

    }
}
