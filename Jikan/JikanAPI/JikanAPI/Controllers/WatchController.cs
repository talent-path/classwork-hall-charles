using System;
using JikanAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace JikanAPI.Controllers
{
    public class WatchController : Controller
    {
        JikanService _service = new JikanService();

        [HttpGet]
        public IActionResult GetWatchById(int id)
        {
           return (IActionResult)_service.GetWatchById(id);
        }

        [HttpGet]
        public IActionResult GetWatchByName(string name)
        {
            return (IActionResult)_service.GetWatchByName(name);
        }

        [HttpGet]
        public IActionResult GetAllWatches()
        {
            return (IActionResult)_service.GetAllWatches();
        }

        [HttpGet]
        public IActionResult GetWatchesByType(string type)
        {
            return (IActionResult)_service.GetWatchesByType(type);
        }

        [HttpGet]
        public IActionResult GetWatchesByPrice(decimal min, decimal max)
        {
            return (IActionResult)_service.GetWatchesByPrice(min, max);
        }

        public IActionResult EditWatch()
        {
            throw new NotImplementedException();
        }

    }
}
