using System;
using System.Collections.Generic;

namespace CourseManager.Models
{
    public class EditCourseViewModel
    {
        public Course ToEdit { get; set; }
        public List<Student> AllStudents {get; set;}
        public List<Teacher> AllTeachers { get; set; }
        public int[] SelectedStudentIds { get; set; }
    }
}
