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

        public IActionResult Add() => View(new AddGradeFormModel
        {
            GTypeGrade =this.gradesService.GetTypeGrades(),
            GStudentCourses= this.gradesService.GetStudentCourses()
        });

        [HttpPost]
        public IActionResult Add(AddGradeFormModel grade)
        {
            if (!ModelState.IsValid)
            {
                return View(grade);
            }

            this.gradesService.AddGrade(grade);
            return RedirectToAction("Index", "Home");
        }
    }
}
