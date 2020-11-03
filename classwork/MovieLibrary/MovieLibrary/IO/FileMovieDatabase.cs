/*
 * ITSE 1430
 * Class work
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace MovieLibrary.IO
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using a file.</summary>
    public class FileMovieDatabase : MovieDatabase 
    {
        public FileMovieDatabase ( string filename )
        {
            _filename = filename;
        }

        private readonly string _filename;

        /// <inheritdoc />
        protected override Movie AddCore ( Movie movie )
        {
            //Find highest ID
            var movies = GetAllCore();

            //HACK: To list
            var items = new List<Movie>(movies);

            var lastId = 0;
            foreach (var item in items)
            {
                if (item.Id > lastId)
                    lastId = item.Id;
            };

            //Set a unique ID
            movie.Id = ++lastId;
            items.Add(movie);

            SaveMovies(items);
            return movie;
        }

        //public void Delete ( int id )
        protected override void DeleteCore ( int id )
        {
            var movie = FindById(id);
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

        //public IEnumerable<Movie> GetAll ()
        protected override IEnumerable<Movie> GetAllCore ()
        {
            if (File.Exists(_filename))
            {
                // Read file buffered as an array
                var lines = File.ReadAllLines(_filename);

                foreach (var line in lines)
                {
                    var movie = LoadMovie(line);
                    if (movie != null)
                        yield return movie;
                };                
            };
        }

        //public Movie Get ( int id )
        protected override Movie GetByIdCore ( int id )
        {
            var movie = FindById(id);

            //Clone movie if we found it
            return (movie != null) ? CloneMovie(movie) : null;
        }

        /// <inheritdoc />
        protected override Movie GetByName ( string name )
        {
            var movies = GetAllCore();
            foreach (var movie in movies)
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
            };

            return null;
        }

        //public string Update ( int id, Movie movie )
        protected override void UpdateCore ( int id, Movie movie )
        {
            var existing = FindById(id);

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

        private Movie FindById ( int id )
        {
            //TODO: Make efficient
            var movies = GetAllCore();
            foreach (var movie in movies)
            {
                if (movie?.Id == id)
                    return movie;
            };

            return null;
        }

        private Movie LoadMovie ( string line )
        {
            //NOTE: No commas in string values

            //Id, "Name", "Description", "Rating", RunLength, ReleaseYear, IsClassic

            string[] tokens = line.Split(',');
            if (tokens.Length != 7)
                return null;

            var movie = new Movie() {
                Id = Int32.Parse(tokens[0]),
                Name = RemoveQuotes(tokens[1]),
                Description = RemoveQuotes(tokens[2]),
                Rating = RemoveQuotes(tokens[3]),
                RunLength = Int32.Parse(tokens[4]),
                ReleaseYear = Int32.Parse(tokens[5]),
                IsClassic = Int32.Parse(tokens[6]) != 0,
            };

            return movie;
        }

        private string RemoveQuotes ( string value )
        {
            return value.Trim('"');
        }

        private List<Movie> _movies = new List<Movie>();  //Generic list of Movies, use for fields
        private int _id = 1;

        // File class - used to manage files
        //    Copy
        //    Move
        ///   Exists
        ///   Open for reading and writing
    }
}
