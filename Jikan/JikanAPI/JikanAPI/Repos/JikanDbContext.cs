using JikanAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Repos
{
    public class JikanDbContext : DbContext
    {
        public DbSet<Watch> Watches { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public JikanDbContext(DbContextOptions<JikanDbContext> options) : base(options)
        { }
    }
}
