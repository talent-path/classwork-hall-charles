using EFBlog.Models;
using EFBlog.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog.Controllers
{
    [ApiController]
    public class BlogController : Controller
    {
        BlogDbContext _context;

        public BlogController(BlogDbContext context)
        {
            //should instantiate a service object instead
            //this is NOT final form 
            _context = context;
        }

        [HttpPost("/User")]
        public IActionResult AddUser(BlogUser toAdd)
        {
            _context.Users.Add(toAdd);
            _context.SaveChanges();
            return this.Accepted(toAdd.BlogUserId);
        }

        [HttpGet("/User/{id}")]
        public IActionResult GetUser(int id)
        {
            BlogUser user = _context.Users.Find(id);
            return this.Accepted(user);
        }

        [HttpGet("/User")]
        public IActionResult GetAllUsers()
        {
            return this.Accepted(_context.Users.ToList());
        }

        [HttpPut("/User")]
        public IActionResult EditUser(BlogUser toEdit)
        {
            //BlogUser user = _context.Users.Find(toEdit.BlogUserId);
            //_context.Entry(user).CurrentValues.SetValues(toEdit);

            _context.Attach(toEdit);
            _context.Entry(toEdit).State = EntityState.Modified;
            _context.SaveChanges();
            return this.Accepted();
        }

        [HttpDelete("/User/{id}")]
        public IActionResult DeleteUser(int id)
        {
            //BlogUser toDelete = _context.Users.Find(id);
            //This way is better because it doesn't query the db
            //But be careful if the id doesn't exist
            BlogUser toDelete = new BlogUser
            {
                BlogUserId = id
            };
            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return this.Accepted();
        }

    }
}
