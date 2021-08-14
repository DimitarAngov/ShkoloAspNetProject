namespace Shkolo.Services.Students
{
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Students;
    using System.Collections.Generic;
    using System.Linq;
    public class StudentsService : IStudentsService
    {
        private readonly ShkoloDbContext db;
        public StudentsService(ShkoloDbContext db)
        {
            this.db = db;
        }
        public void AddStudent(StudentFormModel student)
        {
            var studentData = new Student
            {
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                PlaceOfBirth = student.PlaceOfBirth,
                Address = student.Address,
                Phone = student.Phone,
                NumInClass = student.NumInClass,
                DiaryId = student.DiaryId,
                ParentId = student.ParentId,
                DoctorId = student.DoctorId,
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
                StudentId = x.StudentId,
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
        public StudentFormModel FindById(int id)
                     => this.db
                    .Students
                    .Where(x => x.StudentId == id)
                    .Select(x => new StudentFormModel
                    {
                        StudentId = x.StudentId,
                        Name = x.Name,
                        DateOfBirth = x.DateOfBirth,
                        PlaceOfBirth = x.PlaceOfBirth,
                        Address = x.Address,
                        Phone = x.Phone,
                        NumInClass = x.NumInClass,
                        DoctorId = x.DoctorId,
                        ParentId = x.ParentId,
                        DiaryId = x.DiaryId

                    })
                    .FirstOrDefault();
        public void Edit(int id, StudentFormModel student)
        {
            var studentData = new Student
            {
                StudentId = id,
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                PlaceOfBirth = student.PlaceOfBirth,
                Address = student.Address,
                Phone = student.Phone,
                NumInClass = student.NumInClass,
                DoctorId = student.DoctorId,
                ParentId = student.ParentId,
                DiaryId = student.DiaryId
            };

            db.Students.Update(studentData);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var StudentDel = this.db.Students.FirstOrDefault(x => x.StudentId == id);
            this.db.Students.Remove(StudentDel);
            db.SaveChanges();
        }
        public ICollection<StudentAbsencesModel> GetStudentAbsences()
        {
            var studentsAbsences = this.db
            .ScheduleHours
            .Where(x => x.TypeAbsence.Name != "")
            .OrderBy(x => x.Schedule.Term_Number)
            .ThenBy(x => x.Date)
            .ThenBy(x => x.Student.NumInClass)
            .ThenBy(x => x.Schedule.SchoolHour)
            .Select(x => new StudentAbsencesModel
            {
                StudentId = x.StudentId,
                StudentName = x.Student.Name,
                StudentNumInClass = x.Student.NumInClass,
                SubjectName = x.Schedule.Course.Subject.Name,
                Date = x.Date,
                Hour = x.Schedule.SchoolHour,
                AbsenceTypeName = x.TypeAbsence.Name,
                AbsenceTypeReasonName = x.TypeAbsenceReason.Name
            }).ToList();

            return studentsAbsences;
        }
        public ICollection<StudentAbsencesCountModel> GetCountStudentAbsences()
        {
            var studentsAbsencesCount = this.db
               .ScheduleHours
               .Where(x => x.TypeAbsence.Name != "")
               .GroupBy(x=>x.Student.Name)
               .Select(o => new StudentAbsencesCountModel 
               {
                   StudentName=o.Key,
                   AbsencesCount = o.Count(),
               })
               .OrderByDescending(x=>x.AbsencesCount)
               .Where(x=>x.StudentName!="-")
               .ToList();

            return studentsAbsencesCount;
        }
    }
}
