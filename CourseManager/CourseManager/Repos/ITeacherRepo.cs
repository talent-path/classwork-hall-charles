using CourseManager.Models;
using System.Collections.Generic;

namespace CourseManager.Repos
{
    public interface ITeacherRepo
    {
        void Delete(int id);
        int Add(string name);
        void Edit(Teacher toEdit);
        List<Teacher> GetAll();
        Teacher GetById(int id);
    }
}