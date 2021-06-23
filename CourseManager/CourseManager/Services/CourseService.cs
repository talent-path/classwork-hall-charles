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
        ICourseRepo _courseRepo = new DbCoursesRepo();
        ITeacherRepo _teacherRepo = new DbTeachersRepo();
        IStudentRepo _studentRepo = new DBStudentsRepo();

        public List<Course> GetAll()
        {
            List<Course> toReturn = _courseRepo.GetAll();

            foreach(Course course in toReturn)
            {
                course.ClassTeacher = _teacherRepo.GetById(course.ClassTeacher.Id.Value);
            }

            return toReturn;

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
            Course toReturn = _courseRepo.GetById(id);
            toReturn.ClassTeacher = _teacherRepo.GetById(toReturn.ClassTeacher.Id.Value);

            if( toReturn == null)
            {
                throw new CourseNotFoundException($"No course has an id of {id}.");
            }

            return toReturn;
        }

        public int AddStudent(string name)
        {
            return _studentRepo.Add(name);
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

        public int AddTeacher(string name)
        {
            return _teacherRepo.Add(name);
        }

        public int AddCourse(Course toAdd)
        {
            return _courseRepo.Add(toAdd);
        }

        public void EditCourse(Course toEdit)
        {
            //_courseRepo.Edit(toEdit);

            //may need to fix all students and teachers
            //because of stupid in-mem relationships

            List<Course> allCourses = _courseRepo.GetAll();
            List<Student> allStudents = _studentRepo.GetAll();
            List<Teacher> allTeachers = _teacherRepo.GetAll();

            foreach( Student anyStudent in allStudents)
            {
                anyStudent.Courses =
                    allCourses.Where(
                        course => course.ClassStudents.Any(
                            classStudent => classStudent.Id == anyStudent.Id)).ToList();


            }
            foreach( var anyTeacher in allTeachers)
            {
                anyTeacher.Courses = allCourses
                    .Where(course => course.ClassTeacher.Id == anyTeacher.Id)
                    .ToList();
            }
        }

        public void EditTeacher(Teacher toEdit)
        {
            _teacherRepo.Edit(toEdit);


        }

        public Student GetStudentById(int id)
        {
            Student toReturn = _studentRepo.GetById(id);

            List<Course> toAdd = new List<Course>();
            List<int> courseIds = _courseRepo.GetCoursesByStudentId(id);

            foreach(int courseId in courseIds)
            {
                toAdd.Add(_courseRepo.GetById(courseId));
            }

            toReturn.Courses = toAdd;

            return toReturn;
        }

        public void DeleteCourse(int id)
        {
            _courseRepo.Delete(id);

            List<Course> allCourses = _courseRepo.GetAll();
            List<Student> allStudents = _studentRepo.GetAll();
            List<Teacher> allTeachers = _teacherRepo.GetAll();

            foreach (Student anyStudent in allStudents)
            {
                anyStudent.Courses.RemoveAll(c => c.Id == id);
            }
            foreach (var anyTeacher in allTeachers)
            {
                anyTeacher.Courses.RemoveAll(c => c.Id == id);
            }
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
