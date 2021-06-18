using System;
using System.Collections.Generic;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    Teacher toDisplay = _service.GetTeacherById(id.Value);
                    List<Course> allCourses = _service.GetAll();

                    EditTeacherViewModel vm = new EditTeacherViewModel
                    {
                        ToEdit = toDisplay,
                        AllCourses = allCourses,
                    };

                    return View(vm);

                }
                catch (CourseNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Edit(EditTeacherViewModel vm)
        {

            if (vm.ToEdit != null)
            {

               
                List<Course> fullyHydratedCourses
                    = vm.SelectedCourseIds.Select(id => _service.GetById(id)).ToList();

                vm.ToEdit.Courses = fullyHydratedCourses;
                //TODO
                _service.EditCourse(vm.ToEdit);

                return RedirectToAction("Index");
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
