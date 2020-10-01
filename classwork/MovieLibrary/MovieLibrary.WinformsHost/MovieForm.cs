using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieLibrary.WinformsHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        //Method - function inside a class
        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }

        //Event handler - handles an event
        //  This method is handling the button's Click event
        //     void identifier ( object sender, EventArgs e )
        private void OnSave ( object sender, EventArgs e )
        {
            // I want the button that was clicked
            //Type casting
            // WRONG: var button = (Button)sender;  // C-style cast - crashes if wrong
            //var str = (string)10;
            // CORRECT: var button = sender as Button;  // as operator - always safe returns typed version or null
            var button = sender as Button;
            if (button == null)
                return;

            var movie = new Movie();
            movie.Name = _txtName.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _comboRating.SelectedText;
            movie.IsClassic = _chkClassic.Checked;

            movie.RunLength = ReadAsInt32(_txtRunLength);  //this.ReadAsInt32
            movie.ReleaseYear = ReadAsInt32(_txtReleaseYear);

            //Using a constant
            //  1. Type name, not instance
            var nameLength = Movie.MaximumNameLength; //50
            //var nameLength1 = 50;

            var descriptionLength = movie.MaximumDescriptionLength;

            //Won't compile
            //movie.Age = 10;

            //TODO: Fix validation
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                //Show error message - use for standard messages
                MessageBox.Show(this, error, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            };

            //TODO: Return movie
            Close();
        }

        private int ReadAsInt32 ( Control control )
        {
            var text = control.Text;

            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }
    }
}
