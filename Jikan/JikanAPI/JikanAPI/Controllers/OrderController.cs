using JikanAPI.Models;
using JikanAPI.Repos;
using JikanAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            return Accepted(order);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            return Accepted(_service.GetOrderById(id));
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllOrders()
        {
            if (this.User.Claims.Any(c => c.Type == ClaimTypes.Role.ToString() && c.Value == "Admin"))
            {
                return Ok(_service.GetAllOrders());
            }
            else
            {
                int curUserId = int.Parse(this.User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
                return Ok(_service.GetOrdersByUserId(curUserId));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _service.DeleteOrder(id);
            return Accepted();
        }

    }
}
