using CourseManager.Models;
using System.Collections.Generic;

namespace CourseManager.Repos
{
    public interface ICourseRepo
    {
        void Delete(int id);
        List<Course> GetAll();
        Course GetById(int id);
        List<Course> GetCoursesByTeacherId(int id);
        List<int> GetCoursesByStudentId(int id);

        int Add(Course toAdd);
    }
}