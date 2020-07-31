using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Entities.Models;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Services
{
    public class MoviesService
    {
        private ApplicationDbContext _context;

        public MoviesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
        }

        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public void SaveMovie(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = GetMovie(movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);
        }
    }
}
