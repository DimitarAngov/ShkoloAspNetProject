﻿namespace Shkolo.Services.Students
{
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Students;
    using System.Collections.Generic;
    using System.Linq;
    public class StudentsService:IStudentsService
    {
        private readonly ShkoloDbContext db;
        public StudentsService(ShkoloDbContext db)
        {
            this.db = db;
        }
        public void AddStudent(AddStudentFormModel student)
        {
            var studentData = new Student
            {
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                PlaceOfBirth = student.PlaceOfBirth,
                Address = student.Address,
                Phone = student.Phone,
                NumInClass = student.NumInClass,
                DiaryId = int.Parse(student.DiaryId),
                ParentId = int.Parse(student.ParentId),
                DoctorId = int.Parse(student.DoctorId),
            };

            db.Students.Add(studentData);
            db.SaveChanges();
        }

        public ICollection<AllStudentViewModel> GetAllStudents()
        {
            var students = this.db
            .Students
            .OrderBy(x => x.NumInClass)
            .Select(x => new AllStudentViewModel
            {
                Name = x.Name,
                NumInClass = x.NumInClass,
                DateOfBirth = x.DateOfBirth,
                PlaceOfBirth = x.PlaceOfBirth,
                Address = x.Address,
                Phone = x.Phone
            }).ToList();

            return students;
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