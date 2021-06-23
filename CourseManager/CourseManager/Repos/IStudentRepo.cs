using CourseManager.Models;
using System.Collections.Generic;

namespace CourseManager.Repos
{
    public interface IStudentRepo
    {
        void Delete(int id);
        List<Student> GetAll();
        Student GetById(int id);
        int Add(string name);
    }
}