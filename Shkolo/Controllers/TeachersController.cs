namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Models.Teachers;

    public class TeachersController:Controller
    {
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddTeacherFormModel Teacher) => View();
    }
}
