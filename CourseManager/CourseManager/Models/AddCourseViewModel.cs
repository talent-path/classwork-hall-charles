using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Models
{
    public class AddCourseViewModel
    {
        public Course ToAdd { get; set; }
        public List<Teacher> AllTeachers { get; set; }
    }
}
