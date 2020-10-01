using System;    //DO NOT DELETE
using System.Windows.Forms;

//Hierarchical namesapces
//namespace MovieLibrary
//{
//    namespace WinformsHost
//    {
//    }
//}
//namespace Company.Product.<area>
//namespace Microsoft.Office.Word
//namespace Microsoft.Office.Excel

namespace MovieLibrary.WinformsHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();

            // Type = Movie
            // Variable = movie
            // Value = instance (or an object)
            Movie movie;
            movie = new Movie();   //Create an instance ::=  new T()

            //label2.Text = "A label";            

            //var movie2 = new Movie();  //New instance

            //member access operator ::=   E . M
            movie.Name = "Jaws";
            movie.Description = "Shark movie";
            
            //var str = movie.description;           

            //Hooks up an event handler to an event
            // Event += method
            // Event -= method
            toolStripMenuItem5.Click += OnMovieAdd;
            toolStripMenuItem7.Click += OnMovieDelete;
        }

        //Event - a notification to interested parties that something has happened

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var form = new MovieForm();

            // ShowDialog - modal ::= user must interact with child form, cannot access parent
            // Show - modeless ::= multiple window open and accessible at same time
            var result = form.ShowDialog(this);  //Blocks until form is dismissed
            if (result == DialogResult.Cancel)
                return;

            //After form is gone
            //TODO: Save movie
            MessageBox.Show("Save successful");
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //TODO: Verify movie exists

            //DialogResult
            switch (MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No: return;
            };

            //TODO: Delete movie
        }
    }
}

//namespace OtherNamespace
//{
//    public class MainForm
//    {
//    }
//}
