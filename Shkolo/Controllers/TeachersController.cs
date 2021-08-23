namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Models.Teachers;
    using Shkolo.Services.Teachers;
    
    [Authorize(Roles = "Admin")]
    public class TeachersController : Controller
    {
        private readonly ITeachersService teachersService;
        public TeachersController(ITeachersService teachersService)
        {
            this.teachersService = teachersService;
        }

    [AllowAnonymous]
        public IActionResult All()
        {
            var teachers = this.teachersService.GetAllTeachers();
            return View(teachers);
        }
        public IActionResult Add() => View();

        public IActionResult Edit(int id)
        {
            var teacherFindById = this.teachersService.FindById(id);

            return View(new TeacherFormModel
            {
                TeacherId = teacherFindById.TeacherId,
                Name = teacherFindById.Name
            });
        }
        public IActionResult Delete(int Id)
        {
            this.teachersService.Delete(Id);
            return this.Redirect("/Teachers/All");
        }

        [HttpPost]
        public IActionResult Add(TeacherFormModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            this.teachersService.AddTeacher(teacher);
            return RedirectToAction("Index", "Home");
        }
    
       [HttpPost]
        public IActionResult Edit(int id, TeacherFormModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            this.teachersService.Edit(id,teacher);
            return RedirectToAction("All", "Teachers");

        }
    }
}
