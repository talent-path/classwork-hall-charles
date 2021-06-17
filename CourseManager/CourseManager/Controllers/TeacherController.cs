using System;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers
{
    public class TeacherController : Controller
    {
        CourseService _service = new CourseService();

        //List of all teachers
        public IActionResult Index()
        {
            var teachers = _service.GetAllTeachers();

            return View(teachers);
        }

        //Detail page of teacher
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    Teacher toDisplay = _service.GetTeacherById(id.Value);
                    return View(toDisplay);
                }
                catch (TeacherNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Delete(Teacher teacher)
        {
            if (teacher.Id != null)
            {
                try
                {
                    Teacher toDelete = _service.GetTeacherById(teacher.Id.Value);
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
                _service.DeleteTeacher(id.Value);
                return RedirectToAction("Index");
            }

            return BadRequest();
        }

    }
}
