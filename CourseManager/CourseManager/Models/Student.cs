using System;
using System.Collections.Generic;

namespace CourseManager.Models
{
    public class Student
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        public Student() { }

        public Student(Student that)
        {
            this.Id = that.Id;
            this.Name = that.Name;
            this.Courses = that.Courses;
        }
    }
}
