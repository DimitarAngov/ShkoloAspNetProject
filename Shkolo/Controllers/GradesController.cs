namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Models.Grades;
    using Shkolo.Services.Grades;
  
    public class GradesController : Controller
    {
        private readonly IGradesService gradesService;
        public GradesController(IGradesService gradesService)
        {
            this.gradesService=gradesService;
        }

        public IActionResult All(
            string searchTerm,
            string studentName,
            string subjectName,
            string gradeStudent)
        {
            var grades = this.gradesService.GetAllGrades(searchTerm,studentName,subjectName,gradeStudent);

            var studentN = gradesService.StudenttN();
            var subjectN = gradesService.SubjectN();
            var gradeStudents = gradesService.GradeStudents();

            return View(new AllGradeSearchViewModel
            {
                AllGradesStudents=gradeStudents,
                AllStudentsName=studentN,
                AllSubjectsName= subjectN,
                AllGrades = grades,
                SearchTerm=searchTerm,
            }) ;
        }
        public IActionResult Delete(int Id)
        {
            this.gradesService.Delete(Id);
            return this.Redirect("/Grades/All");
        }
        public IActionResult Add() => View(new GradeFormModel
        {
            GTypeGrade =this.gradesService.GetTypeGrades(),
            GStudentCourses= this.gradesService.GetStudentCourses()
        });

        [HttpPost]
        public IActionResult Add(GradeFormModel grade)
        {
            if (!ModelState.IsValid)
            {
                return View(grade);
            }

            this.gradesService.AddGrade(grade);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
           
            var gradeFindById = this.gradesService.FindById(id);

            return View(new GradeFormModel
            {
                GradeId = gradeFindById.GradeId,
                Term_Number = gradeFindById.Term_Number,
                StudentCourseId = gradeFindById.StudentCourseId,
                GradeStudents = gradeFindById.GradeStudents,
                TypeGradeId = gradeFindById.TypeGradeId,
                Date = gradeFindById.Date,
                Description = gradeFindById.Description,
                GTypeGrade = this.gradesService.GetTypeGrades(),
                GStudentCourses = this.gradesService.GetStudentCourses()
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, GradeFormModel grade)
        {
            if (!ModelState.IsValid)
            {
                return View(grade);
            }

            this.gradesService.Edit(id, grade);
            return RedirectToAction("All", "Grades");
        }

        public IActionResult GradesStudent(string studentName)
        {
            var grades = this.gradesService.GetAllGradesByStudent(studentName);

            var studentN = gradesService.StudenttN();
            
            return View(new AllGradeSearchViewModel
            {
                AllStudentsName = studentN,
                AllGrades = grades,
            });
        }
         public IActionResult GradesSubject(string subjectName)
        {
            var grades = this.gradesService.GetAllGradesBySubject(subjectName);
            var subjectN = gradesService.SubjectN();

            return View(new AllGradeSearchViewModel
            {
                AllSubjectsName = subjectN,
                AllGrades = grades,
            });
        }

    }
}
