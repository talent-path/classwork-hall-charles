using JikanAPI.Models;
using JikanAPI.Repos;
using JikanAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Controllers
{
    [ApiController]
    [Route("/api/order")]
    public class OrderController : Controller
    {
        JikanService _service;

        public OrderController(JikanDbContext context)
        {
            _service = new JikanService(context);
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            _service.AddOrder(order);
            return Accepted();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            return Accepted(_service.GetOrderById(id));
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Accepted(_service.GetAllOrders());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _service.DeleteOrder(id);
            return Accepted();
        }
    }
}
