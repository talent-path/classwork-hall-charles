using System;
using System.Collections.Generic;
using System.Linq;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Repos;

namespace CourseManager.Services
{
    public class CourseService
    {
        ICourseRepo _courseRepo = new EFCourseRepo();
        ITeacherRepo _teacherRepo = new DbTeachersRepo();
        IStudentRepo _studentRepo = new DBStudentsRepo();
        public List<Course> GetAll()
        {
            return _courseRepo.GetAll();
        }
        public List<Teacher> GetAllTeachers()
        {
            return _teacherRepo.GetAll();
        }
        public List<Student> GetAllStudents()
        {
            return _studentRepo.GetAll();
        }
        public Course GetById(int id)
        {
            return _courseRepo.GetById(id);
        }
        public Teacher GetTeacherById(int id)
        {
            Teacher toReturn = _teacherRepo.GetById(id);
            toReturn.Courses = _courseRepo.GetCoursesByTeacherId(id);

            if (toReturn == null)
            {
                throw new TeacherNotFoundException($"No teacher has an id of {id}.");
            }

            return toReturn;
        }
        public Student GetStudentById(int id)
        {
            Student toReturn = _studentRepo.GetById(id);

            List<Course> toAdd = new List<Course>();
            List<int> courseIds = _courseRepo.GetCoursesByStudentId(id);

            foreach (int courseId in courseIds)
            {
                toAdd.Add(_courseRepo.GetById(courseId));
            }

            toReturn.Courses = toAdd;

            return toReturn;
        }
        public int AddCourse(Course toAdd)
        {
            return _courseRepo.Add(toAdd);
        }
        public int AddTeacher(string name)
        {
            return _teacherRepo.Add(name);
        }
        public int AddStudent(string name)
        {
            return _studentRepo.Add(name);
        }
        public void EditCourse(Course toEdit)
        {

        }
        public void EditTeacher(Teacher toEdit)
        {
            _teacherRepo.Edit(toEdit);
        }
        public void DeleteCourse(int id)
        {
            _courseRepo.Delete(id);
        }
        public void DeleteStudent(int id)
        {
            _studentRepo.Delete(id);
        }
        public void DeleteTeacher(int id)
        {
            _teacherRepo.Delete(id);
        }
    }
}
