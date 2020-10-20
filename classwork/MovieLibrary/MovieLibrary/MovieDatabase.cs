using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    /// <summary>Provides the base implementation of a database of movies.</summary>
    public class MovieDatabase
    {
        //Default constructor to seed database
        public MovieDatabase ()
        {
            //Not needed here - clears all items from list
            //_movies.Clear();

            //Collection initializer syntax
            var items = new [] { //new Movie[] {
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
            foreach (var item in items)
                Add(item, out var error);

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
        }

        public Movie Add ( Movie movie, out string error )
        {
            //TODO: Movie is valid
            // Movie name is unique
            error = "";

            //Clone so argument can be modified without impacting our array
            var item = CloneMovie(movie);

            //Set a unique ID
            item.Id = _id++;

            //Add movie to array
            //_movies[index] = item;
            _movies.Add(item);

            //Set ID on original object and return
            movie.Id = item.Id;
            return movie;

            #region Array code 
            //Find first empty spot in array
            // for ( EI; EC; EU ) S;
            //     EI ::= initializer expression (runs once before loop executes)
            //     EC ::= conditional expression => boolean (executes before loop statement is run, aborts if condition is false
            //     EU ::= update expression (runs at end of current iteration)
            // Length -> int (# of rows in the array)
            //for (var index = 0; index < _movies.Length; ++index) //Array
            //for (var index = 0; index < _movies.Count; ++index)  //List
            //{
            //    // Array element access ::=  V[int]
            //    //if (_movies[index] == null)
            //    {
            //        //Clone so argument can be modified without impacting our array
            //        var item = CloneMovie(movie);

            //        //Set a unique ID
            //        item.Id = _id++;

            //        //Add movie to array
            //        //_movies[index] = item;
            //        _movies.Add(item);

            //        //Set ID on original object and return
            //        movie.Id = item.Id;
            //        return movie;
            //    };
            //};

            //error = "No more room";
            //return null;
            #endregion
        }

        public void Delete ( int id )
        {
            //TODO: Validate Id

            var movie = GetById(id);
            if (movie != null)
            {
                //Must use the same instance that is stored in the list so ref equality works
                _movies.Remove(movie);
            };

            #region For Arrays
            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //    // Array element access ::=  V[int]
            //    //if (_movies[index] != null && _movies[index].Id == id)
            //    if (_movies[index]?.Id == id)  // null conditional ?. if instance != null access the member
            //    {
            //        _movies[index] = null;
            //        return;
            //    };
            //};
            #endregion
        }

        public Movie[] GetAll ()
        {
            //DONT DO THIS
            //  1. Expose underlying movie items
            //  2. Callers add/remove movies 
            //return _movies;

            var items = new Movie[_movies.Count];
            var index = 0;
            foreach (var movie in _movies)
                items[index++] = CloneMovie(movie);

            return items;

            #region Arrays
            //Determine how many movies we're storing
            //For each one create a cloned copy
            //return _movies;
            #endregion
        }

        public Movie Get ( int id )
        {
            var movie = GetById(id);

            //Clone movie if we found it
            return (movie != null) ? CloneMovie(movie) : null;
        }

        private Movie GetById ( int id )
        {
            // foreach (var id in array) S
            //for (var index = 0; index < _movies.Length; ++index)
            foreach (var movie in _movies)
            {
                //movie == _movies[index]
                // Restrictions:
                //   1. movie is readonly   // movie = new Movie();
                //   2. _movies cannot change, immutable 
                if (movie?.Id == id)  // null conditional ?. if instance != null access the member                
                    return movie;
            };

            return null;
        }

        public string Update ( int id, Movie movie )
        {
            //TODO: Validate Id
            // Movie exists
            var existing = GetById(id);
            if (existing == null)
                return "Movie not found";

            // updated movie is valid
            // updated movie name is unique
            CopyMovie(existing, movie);

            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //    if (_movies[index]?.Id == id)  // null conditional ?. if instance != null access the member
            //    {
            //        //Clone it so we separate our value from argument
            //        var item = CloneMovie(movie);

            //        item.Id = id;
            //        _movies[index] = item;
            //        return "";
            //    };
            //};

            return "";
        }

        private Movie CloneMovie ( Movie movie )
        {
            var item = new Movie();
            item.Id = movie.Id;

            CopyMovie(item, movie);

            return item;
        }

        private void CopyMovie ( Movie target, Movie source )
        {
            target.Name = source.Name;
            target.Rating = source.Rating;
            target.ReleaseYear = source.ReleaseYear;
            target.RunLength = source.RunLength;
            target.IsClassic = source.IsClassic;
            target.Description = source.Description;
        }

        //Only store cloned copies of movies here!!
        //private Movie[] _movies = new Movie[100];  //0..99
        private List<Movie> _movies = new List<Movie>();  //Generic list of Movies, use for fields
        //private Collection<Movie> _temp;                  //Public read-writable lists
        private int _id = 1;

        // Non-generic
        //    ArrayList - list of objects
        // Generic Types
        //    List<T> where T is any type

    }
}
