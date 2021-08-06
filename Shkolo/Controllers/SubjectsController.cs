namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Models.Subjects;
    using Shkolo.Services.Subjects;
    public class SubjectsController:Controller
    {
        private readonly ISubjectsService subjectsService;
        public SubjectsController(ISubjectsService subjectsService)
        {
            this.subjectsService = subjectsService;
        }
        public IActionResult All()
        {
            var subjects = this.subjectsService.GetAllSubjects();
            return View(subjects);
        }
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddSubjectFormModel subject)
        {
            if (!ModelState.IsValid)
            {
                return View(subject);
            }

            this.subjectsService.AddSubject(subject);
            return RedirectToAction("Index", "Home");
        }

    }
}
