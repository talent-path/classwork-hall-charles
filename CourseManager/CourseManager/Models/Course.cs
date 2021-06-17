using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseManager.Models
{
    public class Course
    {
        public int? Id { get; set; }
        public Teacher ClassTeacher { get; set; }
        public List<Student> ClassStudents { get; set; }
        public string Name { get; set; }

        public Course() { }

        public Course( Course that)
        {
            this.Id = that.Id;
            this.Name = that.Name;
            this.ClassTeacher = new Teacher(that.ClassTeacher);
            this.ClassStudents
                = that.ClassStudents.Select(s => new Student(s)).ToList();
        }
    }
}
