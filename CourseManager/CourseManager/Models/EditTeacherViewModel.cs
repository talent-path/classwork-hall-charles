using System;
using System.Collections.Generic;

namespace CourseManager.Models
{
    public class EditTeacherViewModel
    {
        public Teacher ToEdit { get; set; }
        public List<Course> AllCourses { get; set; }
        public int[] SelectedCourseIds { get; set; }
    }
}
