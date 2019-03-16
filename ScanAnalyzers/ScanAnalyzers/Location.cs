/* Vasudev Vijayaraman & Jesse Houk
 * This class gets the rows and columns where the location or secret location lies and also
 * creates image and changes image accordingly */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ScanAnalyzers
{
    // Location contains a row and column
    public class Location
    {
        // private data member specifying the row where the Location lies
        private int row;
        // private data member specifying the column where the Location lies
        private int column;
        //
        private bool isFound; // isFound flag to be set 
        public PictureBox picture; // picture
        public string ImageName; // string containing the imageName 

        // public property that accesses and sets row
        public int Row
        {
            get
            {
                return row; // returns the row 
            }
            set
            {
                row = value; // sets the row value 
            }
        }
        // public property that accesses and sets column
        public int Column
        {
            get
            {
                return column; // returns the column 
            }
            set
            {
                column = value; // sets the column value 
            }
        }
        /* This proerty access the isFound bool that is private */
        public bool Found
        {
            get
            {
                return isFound;  // Returns the iSFound bool
            }

            set
            {
                isFound = value; // Sets isFound to its value 
            }
        }

        /* Default Constructor that sets the defualt isFound flag to false, creates a new instance of PictureBox and'
         * Changes image to the defualt image */

        public Location()
        {

            isFound = false; // Sets default value of isFound
            picture = new PictureBox();
            ChangeImage("GridSquare.jpg"); // Sets the default image 
        }

        // parameterized constructor that only has row and columns set
        public Location(int r, int c)
        {

            row = r; // Sets thr row 
            column = c; // Sets the Column
            isFound = false; // Sets the isFound  bool
            picture = new PictureBox();
            ChangeImage("GridSquare.jpg"); // Sets the default image
        }

        // This method initializes a new Location which inherits from PictureBox on the pictureGrid
        // making the image name easily accessable. It takes in rows and columns as parameters and 
        // returns nothing  

        public void CreateImage(int r, int c)
        {
            Location pos = new Location(r, c); // Creates a new location
            picture.Location = new Point(pos.Row, pos.Column); // Sets the location
            picture.BorderStyle = BorderStyle.FixedSingle; // Sets the border style
            picture.BackColor = Color.Aqua; // Sets the background color
            picture.Size = new Size(20, 20); // Sets the picture size
            picture.SizeMode = PictureBoxSizeMode.StretchImage; // // Sets the picture mode 
            picture.Anchor = AnchorStyles.Left; // // Sets the anchor of the picture 
            picture.Visible = true; // // Sets its visibiliy 

        }

        // ChangeImage is used to take a picture box from the grid and change the
        // image. It takes in image as parameters and returns nothing 

        public void ChangeImage(string image)
        {
            picture.Image = Image.FromFile(image); // Get the picture from file 
            picture.Load(Directory.GetCurrentDirectory() + "\\" + image); // Load the picture 
            ImageName = image; // Set the image to the image name 
        }
    }
}