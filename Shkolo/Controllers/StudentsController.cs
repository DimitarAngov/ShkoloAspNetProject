namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Models.Students;
    using Shkolo.Services.Students;
 
    public class StudentsController : Controller
    {
        private readonly IStudentsService studentsService;
        public StudentsController(IStudentsService studentsService)
        {
           this.studentsService = studentsService;
        }
            
        public IActionResult All() 
        {
            var students = this.studentsService.GetAllStudents();
            return View(students);
        }

        public IActionResult Add() => View(new AddStudentFormModel {

            SDiaries = this.studentsService.GetStudentDiary(),
            SDoctors= this.studentsService.GetStudentDoctor(),
            SParents= this.studentsService.GetStudentParent()
        });

        [HttpPost]
        public IActionResult Add(AddStudentFormModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            this.studentsService.AddStudent(student);
                     
            return RedirectToAction("Index","Home");
        }
    }
}
