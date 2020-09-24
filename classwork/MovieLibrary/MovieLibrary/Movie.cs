/*
 * ITSE 1430
 * Michael Taylor
 * Classwork
 */
using System;

//StringBuilder, Regular expressions, Encoding
//using System.Text;

namespace MovieLibrary
{
    //Type 
    //  Pascal cased
    //  Noun
    //  Singular unless they represent a collection of things
    // [access] class identifier { }
    
    // doctags

    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// A paragraph of information.
    /// Another set of information.
    /// </remarks>
    public class Movie
    {
        //Data - data to store

        //Fields - where the data is stored
        //string name;
        //Fields work identical to variables
        //Named as nouns, no abbreviations and no generic names
        public string Name = "";

        public string Dscription = "";
        public string Rating;
        public int RunLength;// = 0;
        public bool IsClassic; // = false;

        //Functionality - functions you want to expose
    }

    // Accessibility - the visibility of an identifier to other code, compile time only, determines who can see what at compilation
    //   public - everyone 
    //   private - only the owning type (default for members)
}
