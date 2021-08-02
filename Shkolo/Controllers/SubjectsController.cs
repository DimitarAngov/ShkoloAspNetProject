namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Subjects;
    using System.Linq;

    public class SubjectsController:Controller
    {
        private readonly ShkoloDbContext db;
        public SubjectsController(ShkoloDbContext db)
        {
            this.db = db;
        }

        public IActionResult All()
        {
            var subjects = this.db
            .Subjects
            .OrderBy(x => x.SubjectId)
            .Select(x => new AddSubjectFormModel
            {
                SubjectId=x.SubjectId,
                Name = x.Name,


            }).ToList();

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

            var subjectData = new Subject
            {
                Name = subject.Name,
            };

            db.Subjects.Add(subjectData);
            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

    }
}
