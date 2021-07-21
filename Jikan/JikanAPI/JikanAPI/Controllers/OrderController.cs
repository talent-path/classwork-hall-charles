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
            try
            {
                _service.AddOrder(order);
                return Ok(order);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                return Ok(_service.GetOrderById(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllOrders()
        {
            try
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
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                _service.DeleteOrder(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
