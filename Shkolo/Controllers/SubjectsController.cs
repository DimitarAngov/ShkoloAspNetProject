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
        public IActionResult Delete(int Id)
        {
            this.subjectsService.Delete(Id);
            return this.Redirect("/Subjects/All");
        }
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(SubjectFormModel subject)
        {
            if (!ModelState.IsValid)
            {
                return View(subject);
            }

            this.subjectsService.AddSubject(subject);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var subjectFindById = this.subjectsService.FindById(id);

            return View(new SubjectFormModel
            {
                SubjectId = subjectFindById.SubjectId,
                Name = subjectFindById.Name
            });
        }


        [HttpPost]
        public IActionResult Edit(int id, SubjectFormModel subject)
        {
            if (!ModelState.IsValid)
            {
                return View(subject);
            }

            this.subjectsService.Edit(id,subject);
            return RedirectToAction("All", "Subjects");

        }

    }
}
