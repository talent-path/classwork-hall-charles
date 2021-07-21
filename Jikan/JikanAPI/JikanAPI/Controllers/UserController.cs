using JikanAPI.Models.ViewModels.Requests;
using JikanAPI.Repos;
using JikanAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Controllers
{
    [ApiController]
    [Route("/api/user")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        JikanService _service;

        public UserController(JikanDbContext context)
        {
            _service = new JikanService(context);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RegisterUser(RegisterUserViewModel vm)
        {
            try
            {
                _service.RegisterUser(vm);
                return Ok(true);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel vm)
        {
            try
            {
                string token = _service.Login(vm);
                return Ok(new { vm.Username, token });
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_service.GetAllUsers());
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
