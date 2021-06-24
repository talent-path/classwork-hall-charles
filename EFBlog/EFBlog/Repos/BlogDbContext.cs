using EFBlog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog.Repos
{
    public class BlogDbContext : DbContext
    {
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<BlogUser> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }
    }
}
