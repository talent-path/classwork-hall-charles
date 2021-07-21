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
            try
            {
                _service.AddWatch(watch);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetWatchById(int id)
        {
            try
            {
                return Ok(_service.GetWatchById(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("name/{name}")]
        public IActionResult GetWatchByName(string name)
        {
            try
            {
                return Ok(_service.GetWatchByName(name));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllWatches()
        {
            try
            {
                return Ok(_service.GetAllWatches());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("type/{type}")]
        public IActionResult GetWatchesByType(string type)
        {
            try
            {
                return Ok(_service.GetWatchesByType(type));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("price/{max}")]
        public IActionResult GetWatchesByPrice(decimal max)
        {
            try
            {
                return Ok(_service.GetWatchesByPrice(max));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public IActionResult EditWatch(Watch watch)
        {
            try
            {
                if (watch == null)
                    return BadRequest("Watch is null.");

                _service.EditWatch(watch);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWatch(int id)
        {
            try
            {
                _service.DeleteWatch(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("order/{id}")]
        public IActionResult GetWatchesByOrderId(int id)
        {
            try
            {
                return Ok(_service.GetWatchesByOrderId(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("order/quantity/{id}")]
        public IActionResult GetWatchQuantityByOrderId(int id)
        {
            try
            {
                return Ok(_service.GetWatchQuantityByOrderId(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("order/watch/quantity/{id}")]
        public IActionResult GetWatchQuantityPair(int id)
        {
            try
            {
                return Ok(_service.GetWatchQuantityPair(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
