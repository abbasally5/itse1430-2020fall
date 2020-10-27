using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLibrary
{
    //Interfaces appear on the same line as base types but ARE NOT base types
    //MovieDatabase implements IMovieDatabase
    // A type can implement any # of interfaces
    // All members on an interface must be public and implemented

    //Abstract class required if any member is abstract
    //  1. Cannot be instantiated
    //  2. Must derive from it
    //  3. Must implement all abstract members

    /// <summary>Provides the base implementation of a database of movies.</summary>
    public abstract class MovieDatabase : IMovieDatabase //, IEditableDatabase, IReadableDatabase
    {
        //Default constructor to seed database
        protected MovieDatabase ()
        {
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

        //Not on interface
        public void Foo () { }

        public Movie Add ( Movie movie, out string error )
        {
            //TODO: Movie is not null

            //Movie is valid
            var results = new ObjectValidator().TryValidateFullObject(movie);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                {
                    error = result.ErrorMessage;
                    return null;
                };
            };

            // Movie name is unique
            var existing = FindByName(movie.Name);
            if (existing != null)
            {
                error = "Movie must be unique";
                return null;
            };

            error = null;
            return AddCore(movie);
        }

        protected abstract Movie AddCore ( Movie movie );

        protected virtual Movie FindByName ( string name )
        {
            foreach(var movie in GetAll())
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
            };

            return null;
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

        //Use IEnumerable<T> for readonly lists of items
        //public Movie[] GetAll ()
        public IEnumerable<Movie> GetAll ()
        {
            //DONT DO THIS
            //  1. Expose underlying movie items
            //  2. Callers add/remove movies 
            //return _movies;

            //var items = new Movie[_movies.Count];
            //var index = 0;

            //Foreach equivalent
            // var enumerator = _movies.GetEnumerator();
            // while (enumerator.MoveNext())
            // { 
            //    var movie = enumerator.Current;
            //    S* 
            // }

            //iterator IEnumerable<T>
            //  yield return T
            foreach (var movie in _movies)   // relies on IEnumerator<T>
                //items[index++] = CloneMovie(movie);
                yield return CloneMovie(movie);
                ;

            //return items;

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

        // Non-generic
        //    ArrayList - list of objects
        // Generic Types
        //    List<T> where T is any type
    }
}
