namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Models.Teachers;
    using Shkolo.Services.Teachers;
   
    public class TeachersController : Controller
    {
        private readonly ITeachersService teachersService;
        public TeachersController(ITeachersService teachersService)
        {
            this.teachersService = teachersService;
        }
        public IActionResult All()
        {
            var teachers=this.teachersService.GetAllTeachers();
            return View(teachers);
        }
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddTeacherFormModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            this.teachersService.AddTeacher(teacher);
            return RedirectToAction("Index", "Home");
        }
    }
}
