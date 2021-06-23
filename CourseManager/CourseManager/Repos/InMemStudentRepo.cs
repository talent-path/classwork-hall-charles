using System;
using System.Linq;
using System.Collections.Generic;
using CourseManager.Models;

namespace CourseManager.Repos
{
    public class InMemStudentRepo : IStudentRepo
    {
        public static List<Student> _allStudents = new List<Student>
        {
            new Student {
                Id = 1,
                Name = "A",
                Courses = new List<Course>
                {
                    new Course { Id = 1, Name = "C#" }
                }

            },
            new Student {
                Id = 2,
                Name = "B",
                Courses = new List<Course>
                {
                    new Course { Id = 1, Name = "C#" },
                    new Course { Id = 2, Name = "Java"}
                }
            },
            new Student {
                Id = 3,
                Name = "C",
                Courses = new List<Course>
                {
                    new Course { Id = 1, Name = "C#" },
                    new Course { Id = 2, Name = "Java"},
                    new Course { Id = 3, Name = "Python"}
                }
            },
            new Student {
                Id = 4,
                Name = "D",
                Courses = new List<Course>
                {
                    new Course { Id = 3, Name = "Python"}
                }
            },
            new Student {
                Id = 5,
                Name = "E",
                Courses = new List<Course>
                {
                    new Course { Id = 3, Name = "Python"}
                }
            },
            new Student {
                Id = 6,
                Name = "F",
                Courses = new List<Course>
                {
                    new Course { Id = 3, Name = "Python"}
                }
            },
            new Student {
                Id = 7,
                Name = "G",
                Courses = new List<Course>
                {
                    new Course { Id = 3, Name = "Python"}
                }
            },
        };


        public InMemStudentRepo()
        {
        }

        public List<Student> GetAll()
        {
            return _allStudents.Select(s => new Student(s)).ToList();
        }

        public Student GetById(int id)
        {
            return _allStudents.SingleOrDefault(s => s.Id == id);
        }

        public void Delete(int id)
        {
            _allStudents = _allStudents.Where(s => s.Id != id).ToList();
        }

        public int Add(string name)
        {
            throw new NotImplementedException();
        }
    }
}
