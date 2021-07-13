using System;
using JikanAPI.Models;
using JikanAPI.Repos;
using JikanAPI.Service;
using Microsoft.AspNetCore.Cors;
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
            return Accepted();
        }

        [HttpGet("{id}")]
        public IActionResult GetWatchById(int id)
        {
           return Accepted(_service.GetWatchById(id));
        }

        [HttpGet("name/{name}")]
        public IActionResult GetWatchByName(string name)
        {
            return Accepted(_service.GetWatchByName(name));
        }

        [HttpGet]
        public IActionResult GetAllWatches()
        {
            return Accepted(_service.GetAllWatches());
        }

        [HttpGet("type/{type}")]
        public IActionResult GetWatchesByType(string type)
        {
            return Accepted(_service.GetWatchesByType(type));
        }

        [HttpGet("price/{max}")]
        public IActionResult GetWatchesByPrice(decimal max)
        {
            return Accepted(_service.GetWatchesByPrice(max));
        }

        [HttpPut]
        public IActionResult EditWatch(Watch watch)
        {
           _service.EditWatch(watch);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWatch(int id)
        {
            _service.DeleteWatch(id);
            return Accepted();
        }

        [HttpGet("order/{id}")]
        public IActionResult GetWatchesByOrderId(int id)
        {
            return Accepted(_service.GetWatchesByOrderId(id));
        }

        [HttpGet("order/quantity/{id}")]
        public IActionResult GetWatchQuantityByOrderId(int id)
        {
            return Accepted(_service.GetWatchQuantityByOrderId(id));
        }

        [HttpGet("order/watch/quantity/{id}")]
        public IActionResult GetWatchQuantityPair(int id)
        {
            return Accepted(_service.GetWatchQuantityPair(id));
        }
    }
}
