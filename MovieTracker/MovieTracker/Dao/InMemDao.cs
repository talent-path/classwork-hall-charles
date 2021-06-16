using System;
using System.Collections.Generic;
using MovieTracker.Models;
namespace MovieTracker.Dao
{
    public class InMemDao
    {
        static List<Movie> _AllMovies = new List<Movie>
            {
                new Movie{ Id = 1, Name = "The Dark Knight Rises", Director = "Christopher Nolan", Year = 2012 },
                new Movie{ Id = 2, Name = "Love and Monsters", Director = "Michael Matthews", Year = 2020},
                new Movie{ Id = 3, Name = "300", Director = "Zack Snyder", Year = 2007},
                new Movie{ Id = 4, Name = "Django Unchained", Director = "Quentin Tarantino", Year = 2012}
            };

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            for (int i = 0; i < _AllMovies.Count; i++)
            {
                Movie movie = _AllMovies[i];
                movies.Add(new Movie(movie));
            }
            return movies;
        }

        public int AddMovie(Movie toAdd)
        {
            int max = 0;
            for (int i = 0; i < _AllMovies.Count; i++)
            {
                Movie movie = _AllMovies[i];
                max = Math.Max(max, movie.Id);
            }
            toAdd.Id = max + 1;
            _AllMovies.Add(toAdd);
            return max;
        }

        public Movie GetMovieById(int id)
        {
            for (int i = 0; i < _AllMovies.Count; i++)
            {
                Movie movie = _AllMovies[i];
                if (movie.Id == id) return new Movie(movie);
            }
            return null;
        }

        public void DeleteMovie(int id)
        {
            for (int i = 0; i < _AllMovies.Count; i++)
            {
                Movie movie = _AllMovies[i];
                if (movie.Id == id) _AllMovies.RemoveAt(i);
            }
        }

        public void EditMovie(Movie toEdit)
        {
            for (int i = 0; i < _AllMovies.Count; i++)
            {
                Movie movie = _AllMovies[i];
                if (movie.Id == toEdit.Id)
                {
                    _AllMovies[i] = new Movie(toEdit);
                }
            }
        }

    }
}