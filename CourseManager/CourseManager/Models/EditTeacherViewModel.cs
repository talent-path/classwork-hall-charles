using System;
using System.Collections.Generic;

namespace CourseManager.Models
{
    public class EditTeacherViewModel
    {
        public Teacher ToEdit { get; set; }
        public List<Student> AllStudents { get; set; }
        public List<Teacher> AllTeachers { get; set; }
        public int[] SelectedCourseIds { get; set; }
    }
}
