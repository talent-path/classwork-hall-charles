using System;
using JikanAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace JikanAPI.Controllers
{
    public class JikanController : Controller
    {
        JikanService _service = new JikanService();

        public IActionResult GetAllWatches()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetWatchesByType()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetWatchesById()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetWatchesByName()
        {
            throw new NotImplementedException();
        }

        public IActionResult EditWatch()
        {
            throw new NotImplementedException();
        }

        public IActionResult PurchaseWatch()
        {
            throw new NotImplementedException();
        }

    }
}
