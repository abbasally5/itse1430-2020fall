using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    public static class SeedMovieDatabase
    {
        //Make static because it does not reference any instance data 
        //nor does it really need to be created
        //Converting to an extension method
        //  1. Must be in a static class (public or internal)
        //  2. Must accept as a first parameter the type to extend
        //  3. First parameter must be preceded by keyword `this`
        //  4. (Optional) Change first parameter to `source`
        public static void Seed ( this IMovieDatabase source )   //database.Seed()
        {
            //Extension methods - DO NOT check for null

            //Not needed here - clears all items from list
            //_movies.Clear();

            //Collection initializer syntax
            var items = new[] { //new Movie[] {
                new Movie() {
                    Name = "Jaws",
                    ReleaseYear = 1977,
                    RunLength = 190,
                    Description = "Shark movie",
                    IsClassic = true,
                    Rating = "PG",  // Can have a comma at end
                },
                new Movie() {
                    Name = "Jaws 2",
                    ReleaseYear = 1979,
                    RunLength = 195,
                    Description = "Shark movie",
                    IsClassic = true,
                    Rating = "PG-13",
                },
                new Movie() {
                    Name = "Dune",
                    ReleaseYear = 1985,
                    RunLength = 220,
                    Description = "Based on book",
                    IsClassic = true,
                    Rating = "PG",
                }
            };

            //TODO: Fix error handling
            foreach (var item in items)
                source.Add(item);

            #region Unused code
            //Seed database
            // Object initializer - only usable on new operator
            //   Limitations:
            //      1. Can only set properties with setters
            //      2. Can set properties that are themselves new'ed up but cannot set child properties
            //                    Position = new Position() { Name = "Boss" };  //Allowed
            //                    Position.Title = "Boss";  //Not allowed
            //      3. Properties cannot rely on other properties
            //               Description = "blah",
            //               FullDescription = Description
            //var movie = new Movie();
            //movie.Name = "Jaws";
            //movie.ReleaseYear = 1977;
            //movie.RunLength = 190;
            //movie.Description = "Shark movie";
            //movie.IsClassic = true;
            //movie.Rating = "PG";
            //var movie = new Movie() {
            //    Name = "Jaws",
            //    ReleaseYear = 1977,
            //    RunLength = 190,
            //    Description = "Shark movie",
            //    IsClassic = true,
            //    Rating = "PG",  // Can have a comma at end
            //};
            //Add(movie, out var error);

            //movie = new Movie() {
            //    Name = "Jaws 2",
            //    ReleaseYear = 1979,
            //    RunLength = 195,
            //    Description = "Shark movie",
            //    IsClassic = true,
            //    Rating = "PG-13",
            //};
            //Add(movie, out error);

            //movie = new Movie() {
            //    Name = "Dune",
            //    ReleaseYear = 1985,
            //    RunLength = 220,
            //    Description = "Based on book",
            //    IsClassic = true,
            //    Rating = "PG",
            //};
            //Add(movie, out error);
            #endregion
        }
    }
}
