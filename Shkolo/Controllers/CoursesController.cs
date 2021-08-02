namespace Shkolo.Controllers
{
   using Microsoft.AspNetCore.Mvc;
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models;
    using Shkolo.Models.Courses;
    using Shkolo.Models.Subjects;
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;
    using System.Linq;

    public class CoursesController:Controller
    {
        private readonly ShkoloDbContext db;
        public CoursesController(ShkoloDbContext db)
        {
            this.db = db;
        }

        public IActionResult All()
        {
            var courses = this.db
            .Courses
            .OrderBy(x => x.CourseId)
            .Select(x => new Models.Courses.AllCourseModel
            {
                CourseId=x.CourseId,
                TeacherName=x.Teacher.Name,
                SubjectName=x.Subject.Name,
                TypeSubjectName=x.TypeSubject.Name
 
            }).ToList();

            return View(courses);
        }

        public IActionResult Add() => View(new AddCourseFormModel
        {

            CTeachers = GetCourseTeachers(),
            CSubjects = GetCourseSubjects(),
            CTypeSubjects = GetCourseTypeSubjects()
        });

        [HttpPost]
        public IActionResult Add(AddCourseFormModel course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            var courseData = new Course
            {
               TeacherId = course.TeacherId,
               SubjectId = course.SubjectId,
               TypeSubjectId=course.TypeSubjectId
            };

            db.Courses.Add(courseData);
            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        public IEnumerable<AddTeacherFormModel> GetCourseTeachers()
        => this.db
            .Teachers
            .Select(x => new AddTeacherFormModel
            {
                TeacherId = x.TeacherId,
                Name = x.Name,
            })
            .ToList();

        public IEnumerable<AddSubjectFormModel> GetCourseSubjects()
        => this.db
           .Subjects
           .Select(x => new AddSubjectFormModel
           {
               SubjectId = x.SubjectId,
               Name = x.Name
           })
           .ToList();

        public IEnumerable<TypeSubjectModel> GetCourseTypeSubjects()
        => this.db
           .TypeSubjects
           .Select(x => new TypeSubjectModel
           {
               TypeSubjectId = x.TypeSubjectId,
               Name = x.Name
           })
           .ToList();
    }
}
