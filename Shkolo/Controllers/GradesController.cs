namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Grades;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GradesController : Controller
    {
        private readonly ShkoloDbContext db;
        public GradesController(ShkoloDbContext db)
        {
            this.db = db;
        }

        public IActionResult All()
        {
            var grade = this.db
                .Grades
                .OrderBy(x=>x.Term_Number)
                .ThenBy(x=>x.StudentCourse.Courses.Subject.Name)
                .Select(x => new AllGradeModel
                {
                    Term_Number = x.Term_Number,
                    Date = x.Date,
                    StudentName = x.StudentCourse.Students.Name,
                    SubjectName = x.StudentCourse.Courses.Subject.Name,
                    GradeStudent = x.GradeStudents,
                    TypeGradeName = x.TypeGrade.Name
                }).ToList();

            return View(grade);
        }

        public IActionResult Add() => View(new AddGradeFormModel
        {
            GTypeGrade = GetTypeGrades(),
            GStudentCourses=GetStudentCourses()
        });

        [HttpPost]
        public IActionResult Add(AddGradeFormModel grade)
        {
            if (!ModelState.IsValid)
            {
                return View(grade);
            }

            var gradeData = new Grade
            {
                GradeId = grade.GradeId,
                Term_Number = grade.Term_Number,
                StudentCourseId = grade.StudentCourseId,
                GradeStudents = grade.GradeStudents,
                TypeGradeId= grade.TypeGradeId,
                Date=grade.Date,
                Description=grade.Description
            };

            db.Grades.Add(gradeData);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<TypeGradeModel> GetTypeGrades()
        => this.db
           .TypeGrades
           .Select(x => new TypeGradeModel
           {
               TypeGradeId = x.TypeGradeId,
               Name = x.Name
           })
           .ToList();

        private IEnumerable<StudentCourseModel> GetStudentCourses()
        => this.db
           .StudentsCourses
           .Select(x => new StudentCourseModel
           {
               StudentCourseId = x.StudentCourseId,
               StudentName = x.Students.Name,
               SubjectName=x.Courses.Subject.Name,
               TeacherName=x.Courses.Teacher.Name
           })
           .ToList();

    }
}
