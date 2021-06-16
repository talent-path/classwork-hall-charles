using System;
using System.Collections.Generic;
using MovieTracker.Dao;
using MovieTracker.Models;

namespace MovieTracker.Service
{
    public class MovieService
    {
        public MovieService()
        {
        }

        InMemDao _dao = new InMemDao();

        public List<Movie> GetAllMovies()
        {
            return _dao.GetAllMovies();
        }

        public int AddMovie(Movie toAdd)
        {
            return _dao.AddMovie(toAdd);
        }

        public Movie GetMovieById(int id)
        {
            return _dao.GetMovieById(id);
        }

        public void DeleteMovie(int id)
        {
            _dao.DeleteMovie(id);
        }

        public void EditMovie(Movie toEdit)
        {
            _dao.EditMovie(toEdit);
        }
    }
}
