﻿namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Teachers;
    using System.Linq;

    public class TeachersController : Controller
    {
        private readonly ShkoloDbContext db;
        public TeachersController(ShkoloDbContext db)
        {
            this.db = db;
        }

        public IActionResult All()
        {
            var teachers = this.db
            .Teachers
            .OrderBy(x => x.TeacherId)
            .Select(x => new AddTeacherFormModel
            {
                TeacherId=x.TeacherId,
                Name = x.Name,


            }).ToList();

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

            var teacherData = new Teacher
            {
                Name = teacher.Name,
            };

            db.Teachers.Add(teacherData);
            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
    }
}
