using System;
using System.Linq;
using CourseManager.Models;
using System.Collections.Generic;

namespace CourseManager.Repos
{
    public class InMemCourseRepo
    {
        static List<Course> _allCourses = new List<Course>
        {
            new Course {
                Id = 1,
                Name = "C#",
                ClassTeacher = new Teacher{ Id = 1, Name = "David" },
                ClassStudents = new List<Student>
                {
                    new Student {Id = 1, Name = "A"},
                    new Student {Id = 2, Name = "B"},
                    new Student {Id = 3, Name = "C"},
                }
            },
            new Course
            {
                Id = 2,
                Name = "Java",
                ClassTeacher = new Teacher{ Id = 2, Name = "Bob" },
                ClassStudents = new List<Student>
                {
                    new Student {Id = 2, Name = "B"},
                    new Student {Id = 3, Name = "C"},
                    new Student {Id = 4, Name = "D"},

                }

            },
            new Course
            {
                Id = 3,
                Name = "Python",
                ClassTeacher = new Teacher{ Id = 3, Name = "Alice"},
                ClassStudents = new List<Student>
                {
                    new Student {Id = 3, Name = "C"},
                    new Student {Id = 4, Name = "D"},
                    new Student {Id = 5, Name = "E"},
                    new Student {Id = 6, Name = "F"},
                    new Student {Id = 7, Name = "G"},

                }
            }
        };

        internal void Edit(Course toEdit)
        {
            _allCourses = _allCourses.Select(
                c => c.Id == toEdit.Id ?
                    new Course(toEdit) :
                    c
                    ).ToList();
        }

        public Course GetById(int id)
        {
            return _allCourses.SingleOrDefault(c => c.Id == id);
        }

        public List<Course> GetAll()
        {
            return _allCourses.Select(c => new Course(c)).ToList();
        }

        public void Delete(int id)
        {
            _allCourses = _allCourses.Where(c => c.Id != id).ToList();
        }
    }
}
