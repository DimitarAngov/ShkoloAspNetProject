﻿namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Models.Students;
    using Shkolo.Services.Grades;
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

        public IActionResult Delete(int Id)
        {
            this.studentsService.Delete(Id);
            return this.Redirect("/Students/All");
        }
        public IActionResult Add() => View(new StudentFormModel {

            SDiaries = this.studentsService.GetStudentDiary(),
            SDoctors= this.studentsService.GetStudentDoctor(),
            SParents= this.studentsService.GetStudentParent()
        });

        [HttpPost]
        public IActionResult Add(StudentFormModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            this.studentsService.AddStudent(student);
                     
            return RedirectToAction("Index","Home");
        }

        public IActionResult Edit(int id)
        {
            var studentFindById = this.studentsService.FindById(id);
          
            return View(new StudentFormModel
            {
                StudentId = studentFindById.StudentId,
                Name = studentFindById.Name,
                DateOfBirth = studentFindById.DateOfBirth,
                PlaceOfBirth = studentFindById.PlaceOfBirth,
                Address = studentFindById.Address,
                Phone = studentFindById.Phone,
                NumInClass = studentFindById.NumInClass,
                DoctorId = studentFindById.DoctorId,
                ParentId = studentFindById.ParentId,
                DiaryId = studentFindById.DiaryId,
                SDiaries = this.studentsService.GetStudentDiary(),
                SDoctors = this.studentsService.GetStudentDoctor(),
                SParents = this.studentsService.GetStudentParent()
            });
        }


        [HttpPost]
        public IActionResult Edit(int id, StudentFormModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            this.studentsService.Edit(id, student);
            return RedirectToAction("All", "Students");
        }

        public IActionResult StudentAbsencesCount()
        {
            var absencesCount = this.studentsService.GetCountStudentAbsences();
            return View(absencesCount);
        }
        public IActionResult StudentAbsences()
        {
            var absences = this.studentsService.GetStudentAbsences();
            return View(absences);
        }
    }
}
