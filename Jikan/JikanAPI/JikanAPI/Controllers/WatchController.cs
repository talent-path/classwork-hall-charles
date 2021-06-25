using System;
using JikanAPI.Models;
using JikanAPI.Repos;
using JikanAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace JikanAPI.Controllers
{
    [ApiController]
    [Route("/api/watch")]
    public class WatchController : Controller
    {
        JikanService _service;
        public WatchController(JikanDbContext context)
        {
            _service = new JikanService(context);
        }

        [HttpPost]
        public IActionResult AddWatch(Watch watch)
        {
            _service.AddWatch(watch);
            return this.Accepted();
        }

        [HttpGet("{id}")]
        public IActionResult GetWatchById(int id)
        {
           return this.Accepted(_service.GetWatchById(id));
        }

        [HttpGet("name/{name}")]
        public IActionResult GetWatchByName(string name)
        {
            return this.Accepted(_service.GetWatchByName(name));
        }

        [HttpGet]
        public IActionResult GetAllWatches()
        {
            return this.Accepted(_service.GetAllWatches());
        }

        [HttpGet("type/{type}")]
        public IActionResult GetWatchesByType(string type)
        {
            return this.Accepted(_service.GetWatchesByType(type));
        }

        [HttpGet("{min}/{max}")]
        public IActionResult GetWatchesByPrice(decimal min, decimal max)
        {
            return this.Accepted(_service.GetWatchesByPrice(min, max));
        }

        [HttpPut]
        public IActionResult EditWatch(Watch watch)
        {
           _service.EditWatch(watch);
            return this.Accepted();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWatch(int id)
        {
            _service.DeleteWatch(id);
            return this.Accepted();
        }

    }
}
