namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Students;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsController : Controller
    {
        private readonly ShkoloDbContext db;
        public StudentsController(ShkoloDbContext db)
        {
            this.db = db;
        }

        
        public IActionResult All() 
        {
            var students = this.db
            .Students
            .OrderBy(x=>x.NumInClass)
            .Select(x => new AllStudentViewModel
            {
                Name=x.Name,
                NumInClass=x.NumInClass,
                DateOfBirth=x.DateOfBirth,
                PlaceOfBirth=x.PlaceOfBirth,
                Address=x.Address,
                Phone=x.Phone
            }).ToList();

            return View(students);
        }

        public IActionResult Add() => View(new AddStudentFormModel {

            SDiaries = GetStudentDiary(),
            SDoctors=GetStudentDoctor(),
            SParents=GetStudentParent()
        });

        [HttpPost]
        public IActionResult Add(AddStudentFormModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            var studentData = new Student
            {
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                PlaceOfBirth = student.PlaceOfBirth,
                Address = student.Address,
                Phone = student.Phone,
                NumInClass = student.NumInClass,
                DiaryId = int.Parse(student.DiaryId),
                ParentId= int.Parse(student.ParentId),
                DoctorId = int.Parse(student.DoctorId),

            };

            db.Students.Add(studentData);
            db.SaveChanges();

            
            return RedirectToAction("Index","Home");
        }

        public IEnumerable<StudentDiaryModel> GetStudentDiary()
        => this.db
            .Diaries
            .Select(x => new StudentDiaryModel
            {
                DiaryId = x.DiaryId,
                NumberClassName = x.NumberClassName,
                ClassName = x.ClassName
            })
            .ToList();

        public IEnumerable<StudentParentModel> GetStudentParent()
        => this.db
           .Parents
           .Select(x => new StudentParentModel
           {
               ParentId = x.ParentId,
               Name = x.Name
           })
           .ToList();

        public IEnumerable<StudentDoctorModel> GetStudentDoctor()
        => this.db
           .Doctors
           .Select(x => new StudentDoctorModel
           {
               DoctorId = x.DoctorId,
               Name = x.Name
           })
           .ToList();
    }
}
