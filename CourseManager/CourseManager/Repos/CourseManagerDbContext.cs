using CourseManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Repos
{
    public class CourseManagerDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public CourseManagerDbContext(DbContextOptions<CourseManagerDbContext> options)
            : base(options)
        {}
    }
}
