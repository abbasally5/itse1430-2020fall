using System;
using System.Collections.Generic;
using System.Linq;

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

    /// <summary>Provides a base implementation of <see cref="IMovieDatabase"/>.</summary>
    public abstract class MovieDatabase : IMovieDatabase //, IEditableDatabase, IReadableDatabase
    {
        //Not on interface
        //public void Foo () { }

        /// <inheritdoc />
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
            var existing = GetByName(movie.Name);
            if (existing != null)
            {
                error = "Movie must be unique";
                return null;
            };

            error = null;
            return AddCore(movie);
        }
        
        /// <inheritdoc />
        public void Delete ( int id )
        {
            //TODO: Validate Id >= 0

            DeleteCore(id);
        }

        //Use IEnumerable<T> for readonly lists of items
        //public Movie[] GetAll ()

        /// <inheritdoc />
        public IEnumerable<Movie> GetAll ()
        {
            return GetAllCore();
        }

        /// <inheritdoc />
        public Movie Get ( int id )
        {
            //TODO: id >= 0

            return GetByIdCore(id);
        }

        /// <inheritdoc />
        public string Update ( int id, Movie movie )
        {
            //TODO: id >= 0
            //TODO: Movie is not null

            //Movie is valid
            var results = new ObjectValidator().TryValidateFullObject(movie);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                {
                    return result.ErrorMessage;
                };
            };

            // Movie name is unique
            var existing = GetByName(movie.Name);
            if (existing != null && existing.Id != id)
                return "Movie must be unique";

            UpdateCore(id, movie);

            return "";
        }

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The added movie.</returns>
        protected abstract Movie AddCore ( Movie movie );

        protected abstract void DeleteCore ( int id );

        /// <summary>Finds a movie by name.</summary>
        /// <param name="name">The movie to find.</param>
        /// <returns>The movie, if found.</returns>
        /// <remarks>
        /// The default implementation enumerates all the movies looking for a match.
        /// </remarks>
        protected virtual Movie GetByName ( string name )
        {
            foreach (var movie in GetAll())
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
            };

            return null;
        }

        protected abstract IEnumerable<Movie> GetAllCore ();

        protected abstract Movie GetByIdCore ( int id );

        protected abstract void UpdateCore ( int id, Movie movie );
    }
}
