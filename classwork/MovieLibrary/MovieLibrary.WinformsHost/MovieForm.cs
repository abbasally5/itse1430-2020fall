using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieLibrary.WinformsHost
{
    // class-declaration ::= [access] [modifiers] class identifier [ : T ]
    // C# supports only a single base type
    public partial class MovieForm : Form
    {
        //Access:
        // Public - accessible in derived type
        // Protected - accessible in owning type and derived types
        // Private - only owning type

        //Members : properties, methods
        //  Virtual - Base type provides the base implementation but a derived type my override it
        //  Abstract - Base type defines it but does not implement, derived types must override it

        // Syntax
        // ctor-declaration ::= [access] T () { S* }
        //Can call base constructor if needed, base default constructor called if not specified
        public MovieForm ()// : base()
        {
            //DO NOT CALL virtual members inside of constructors
            InitializeComponent();
        }

        public MovieForm ( Movie movie ) : this(movie, null)
        {
            //Constructor chaining eliminates need for this dup initialization
            //Movie = movie;
        }

        //Constructor chaining - calling one constructor from another
        public MovieForm ( Movie movie, string title ) : this()
        {
            //Constructor chaining eliminates need for this dup initialization
            //InitializeComponent();

            Movie = movie;
            Text = title ?? "Add Movie";
        }

        //Properties can be virtual if needed but generally does not make sense
        public virtual Movie Movie { get; set; }

        //public virtual void OnLoad ( EventArgs e ) { }
        //Override indicates to compiler that you are overriding a virtual method
        protected override void OnLoad ( EventArgs e )
        {
            //Call the base member            
            //this.OnLoad(e);
            base.OnLoad(e);

            if (Movie != null)
            {
                _txtName.Text = Movie.Name;
                _txtDescription.Text = Movie.Description;
                _comboRating.SelectedText = Movie.Rating;
                _chkClassic.Checked = Movie.IsClassic;
                _txtRunLength.Text = Movie.RunLength.ToString();
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
            };

            // Go ahead and show validation errors
            ValidateChildren();
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
            //Force validation of all controls
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            };

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

            // Return movie
            Movie = movie;
            Close();
        }

        private int ReadAsInt32 ( Control control )
        {
            var text = control.Text;

            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }

        private void label1_Click ( object sender, EventArgs e )
        {

        }

        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            //Name is required
            if (String.IsNullOrEmpty(control.Text))
            {
                //Set error using ErrorProvider
                _errors.SetError(control, "Name is required");
                e.Cancel = true;  //Not validate
            } else
            {
                //Clear error from provider
                _errors.SetError(control, "");
            };
        }

        private void OnValidateRunLength ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = ReadAsInt32(control);

            //Run length >= 0
            if (value < 0)
            {
                //Set error using ErrorProvider
                _errors.SetError(control, "Run length must be >= 0");
                e.Cancel = true;  //Not validate
            } else
            {
                //Clear error from provider
                _errors.SetError(control, "");
            };
        }

        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = ReadAsInt32(control);

            //Release Year >= 1900
            if (value < 1900)
            {
                //Set error using ErrorProvider
                _errors.SetError(control, "Release Year must be >= 1900");
                e.Cancel = true;  //Not validate
            } else
            {
                //Clear error from provider
                _errors.SetError(control, "");
            };
        }
    }
}
