using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster
{
    public class BlockBusterBasicFunctions //was "internal class"
    {
        public static Movie GetMovieById(int id)
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Find(id);
            }
        }

        public static List<Movie> GetAllMovies()
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies.ToList();
            }
        }

        public static List<Movie> GetAllMoviesFull()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                var movies = db.Movies
                    .Include(movies => movies.Director)
                    .Include(movies => movies.Genre)
                    .ToList();

                return movies;
            }
        }

        public static List<Movie> GetAllCheckedOutMovies()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Join(db.Transactions,
                    m => m.MovieId,
                    t => t.Movie.MovieId,
                    (m, t) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,
                        CheckedIn = t.CheckedIn
                    }).Where(w => w.CheckedIn == "N")
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId
                    }).ToList();
            }
        }

        public static List<Movie> GetAllMoviesByGenreDescription(string genreDescr)
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Where(m => m.Genre.GenreDescr == genreDescr).ToList();
            }
        }

        public static List<Movie> GetAllMoviesByDirectorLastName(string lastName)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Where(m => m.Director.LastName == lastName).ToList();
            }
        }

        public static Movie GetMovieByTitle(string title)
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies.FirstOrDefault(m => m.Title == title);
            }
        }
    }
}
