using Microsoft.AspNetCore.Mvc;
using MovieTracker.Models;
using MovieTracker.Service;

namespace MovieTracker.Controllers
{
    public class MovieController : Controller
    {
        public MovieController()
        {
        }

        MovieService _service = new MovieService();

        [HttpGet]
        public IActionResult Index()
        {
            return View(_service.GetAllMovies());
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie toAdd)
        {
            _service.AddMovie(toAdd);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MovieView(int? id)
        {
            if(id != null)
            {
                return View(_service.GetMovieById(id.Value));
            }
            return this.BadRequest();
        }

        [HttpPost]
        public IActionResult EditMovie(Movie toEdit)
        {
            _service.EditMovie(toEdit);
            return this.RedirectToAction("Index");
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            _service.DeleteMovie(id);
        }

    }
}
