using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Repos
{
    public class EFCourseRepo : ICourseRepo
    {
        CourseManagerDbContext _context;
        public int Add(Course toAdd)
        {
            _context.Courses.Add(toAdd);
            _context.SaveChanges();
            return toAdd.Id.Value;
        }

        public void Delete(int id)
        {
            Course toDelete = new Course
            {
                Id = id
            };
            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
        }

        public List<Course> GetAll()
        {
           return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public List<int> GetCoursesByStudentId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCoursesByTeacherId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
