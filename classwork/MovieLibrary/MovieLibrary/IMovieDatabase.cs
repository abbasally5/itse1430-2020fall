using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    // Interface
    //    interface-declaration ::= [access] interface identifier { interface-member* }
    //    interface-member ::= property | method | event 
    //       1. No access modifiers (always public)
    //       2. No implementation of anything
    //    Cannot instantiate an interface

    // Common interfaces
    //   IEnumerable<T>, IEnumerator<T>
    //   IList<T>, IReadOnlyList<T>
    //   IComparer<T> - relational comparison
    //   ICloneable - clone objects, but doesn't actually work
    //   IValidatableObject - validates objects
    /// <summary>Provides an interface for storing and retrieving movies.</summary>
    public interface IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <param name="error">The error message, if any.</param>
        /// <returns>The new movie.</returns>
        /// error: Movie is invaild
        /// error: Movie already exists
        Movie Add ( Movie movie, out string error );

        /// <summary>Deletes a movie from the database.</summary>
        /// <param name="id">The movie to delete.</param>
        /// error: Id is less than zero.
        void Delete ( int id );

        /// <summary>Gets a movie from the database.</summary>
        /// <param name="id">The movie to retrieve.</param>
        /// error: Id is less than zero.
        Movie Get ( int id );

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies.</returns>
        IEnumerable<Movie> GetAll ();

        /// <summary>Updates an existing movie in the database.</summary>
        /// <param name="id">The movie to update.</param>
        /// <param name="movie">The movie details.</param>
        /// error: Id is less than zero.
        /// error: Movie does not exist.
        /// error: Movie is not valid.
        /// error: Movie name already exists.
        string Update ( int id, Movie movie );
    }
}