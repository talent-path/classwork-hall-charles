using System;
using JikanAPI.Models;
using JikanAPI.Repos;
using JikanAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JikanAPI.Controllers
{
    [ApiController]
    [Route("/api/watch")]
    [Authorize(Roles = "Admin")]
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
            return Ok();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetWatchById(int id)
        {
           return Ok(_service.GetWatchById(id));
        }

        [HttpGet("name/{name}")]
        [AllowAnonymous]
        public IActionResult GetWatchByName(string name)
        {
            return Ok(_service.GetWatchByName(name));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllWatches()
        {
            return Ok(_service.GetAllWatches());
        }

        [HttpGet("type/{type}")]
        [AllowAnonymous]
        public IActionResult GetWatchesByType(string type)
        {
            return Ok(_service.GetWatchesByType(type));
        }

        [HttpGet("price/{max}")]
        [AllowAnonymous]
        public IActionResult GetWatchesByPrice(decimal max)
        {
            return Ok(_service.GetWatchesByPrice(max));
        }

        [HttpPut]
        public IActionResult EditWatch(Watch watch)
        {
           _service.EditWatch(watch);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWatch(int id)
        {
            _service.DeleteWatch(id);
            return Ok();
        }

        [HttpGet("order/{id}")]
        [AllowAnonymous]
        public IActionResult GetWatchesByOrderId(int id)
        {
            return Ok(_service.GetWatchesByOrderId(id));
        }

        [HttpGet("order/quantity/{id}")]
        [AllowAnonymous]
        public IActionResult GetWatchQuantityByOrderId(int id)
        {
            return Ok(_service.GetWatchQuantityByOrderId(id));
        }

        [HttpGet("order/watch/quantity/{id}")]
        [AllowAnonymous]
        public IActionResult GetWatchQuantityPair(int id)
        {
            return Ok(_service.GetWatchQuantityPair(id));
        }
    }
}
