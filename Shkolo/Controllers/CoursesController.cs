namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
   using Shkolo.Models.Courses;
   using Shkolo.Services.Courses;

    [Authorize(Roles = "Admin")]
    public class CoursesController:Controller
    {
        private readonly ICoursesService coursesService;
        public CoursesController(ICoursesService coursesService)
        {
            this.coursesService = coursesService;
        }
   [AllowAnonymous]
        public IActionResult All()
        {
            var courses=this.coursesService.GetAllCourses();
            return View(courses);
        }

        public IActionResult Delete(int Id)
        {
            this.coursesService.Delete(Id);
            return this.Redirect("/Courses/All");
        }
        public IActionResult Add() => View(new CourseFormModel
        {
            CTeachers = this.coursesService.GetCourseTeachers(),
            CSubjects = this.coursesService.GetCourseSubjects(),
            CTypeSubjects = this.coursesService.GetCourseTypeSubjects()
        });

        [HttpPost]
        public IActionResult Add(CourseFormModel course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            this.coursesService.AddCourse(course);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var courseFindById = this.coursesService.FindById(id);

            return View(new CourseFormModel
            {
                CourseId = courseFindById.TeacherId,
                TeacherId = courseFindById.TeacherId,
                SubjectId=courseFindById.SubjectId,
                TypeSubjectId=courseFindById.TypeSubjectId,
                CTeachers = this.coursesService.GetCourseTeachers(),
                CSubjects = this.coursesService.GetCourseSubjects(),
                CTypeSubjects = this.coursesService.GetCourseTypeSubjects()
            });
        }


        [HttpPost]
        public IActionResult Edit(int id, CourseFormModel course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            this.coursesService.Edit(id, course);
            return RedirectToAction("All", "Courses");

        }
    }
}
