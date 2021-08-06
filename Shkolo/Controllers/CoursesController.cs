namespace Shkolo.Controllers
{
   using Microsoft.AspNetCore.Mvc;
   using Shkolo.Models.Courses;
   using Shkolo.Services.Courses;
   public class CoursesController:Controller
    {
        private readonly ICoursesService coursesService;
        public CoursesController(ICoursesService coursesService)
        {
            this.coursesService = coursesService;
        }
        public IActionResult All()
        {
            var courses=this.coursesService.GetAllCourses();
            return View(courses);
        }
        public IActionResult Add() => View(new AddCourseFormModel
        {
            CTeachers = this.coursesService.GetCourseTeachers(),
            CSubjects = this.coursesService.GetCourseSubjects(),
            CTypeSubjects = this.coursesService.GetCourseTypeSubjects()
        });

        [HttpPost]
        public IActionResult Add(AddCourseFormModel course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            this.coursesService.AddCourse(course);
            return RedirectToAction("Index", "Home");
        }
    }
}
