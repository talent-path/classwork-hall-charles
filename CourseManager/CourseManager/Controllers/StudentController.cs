using System;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers
{
    public class StudentController : Controller
    {

        CourseService _service = new CourseService();

        //List of all students
        public IActionResult Index()
        {
            var students = _service.GetAllStudents();

            return View(students);
        }

        //Detail page of student
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    Student toDisplay = _service.GetStudentById(id.Value);
                    return View(toDisplay);
                }
                catch (StudentNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(String name)
        {
            _service.AddStudent(name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Student student)
        {
            if (student.Id != null)
            {
                try
                {
                    Student toDelete = _service.GetStudentById(student.Id.Value);
                    return View(toDelete);
                }
                catch (CourseNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _service.DeleteStudent(id.Value);
                return RedirectToAction("Index");
            }

            return BadRequest();
        }

    }
}
