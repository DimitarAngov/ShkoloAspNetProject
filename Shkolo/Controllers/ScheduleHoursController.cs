namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.ScheduleHours;
    using Shkolo.Models.Schedules;
    using Shkolo.Models.Students;
    using System.Collections.Generic;
    using System.Linq;

    public class ScheduleHoursController:Controller
    {
        private readonly ShkoloDbContext db;
        public ScheduleHoursController(ShkoloDbContext db)
        {
            this.db = db;
        }

        public IActionResult All(string teacherName, string subjectName)
        {
            var sheduleHourQuery = this.db.ScheduleHours.AsQueryable();

            if (!string.IsNullOrWhiteSpace(subjectName))
            {
                sheduleHourQuery = sheduleHourQuery.Where(x => x.Schedule.Course.Subject.Name == subjectName);
            }

            if (!string.IsNullOrWhiteSpace(teacherName))
            {
                sheduleHourQuery = sheduleHourQuery.Where(x => x.Schedule.Course.Teacher.Name == teacherName);
            }

            var scheduleHour = sheduleHourQuery
                .OrderBy(x => x.Schedule.Term_Number)
                
                .Select(x => new AllScheduleHourModel
                {
                    Term_Number = x.Schedule.Term_Number,
                    Date = x.Date,
                    DayOfWeek = x.Schedule.DayOfWeek,
                    SchoolHour = x.Schedule.SchoolHour,
                    ScheduleSubjectName = x.Schedule.Course.Subject.Name,
                    ScheduleTeacherName=x.Schedule.Course.Teacher.Name,
                    Topics=x.Topics,
                    AbsenceStudentNimberInClass=x.Student.NumInClass
                }).ToList();

            var subjectN = this.db
                .Subjects
                .Select(x => x.Name)
                .ToList();

            var teacherN = this.db
                .Teachers
                .Select(x => x.Name)
                .ToList();

            return View(new ScheduleHourSearchViewModel 
            {
                AllTeachersName=teacherN,
                AllSubjectsName=subjectN,
                AllScheduleHours=scheduleHour
            });
        }

        public IActionResult Add() => View(new AddScheduleHourFormModel
        {

            SchStudent = GetScheduleStudents(),
            SchSchedule = GetSchedule(),
            SchTypeAbsence = GetScheduleTypeAbsences(),
            SchTypeAbsenceReason = GetScheduleTypeAbsenceReasons(),
        });

    [HttpPost]
        public IActionResult Add(AddScheduleHourFormModel scheduleHour)
        {
            if (!ModelState.IsValid)
            {
                return View(scheduleHour);
            }

            var scheduleHourData = new ScheduleHour
            {
                Date = scheduleHour.Date,
                ScheduleId=scheduleHour.ScheduleId,
                Topics=scheduleHour.Topics,
                StudentId=scheduleHour.StudentId,
                TypeAbsenceId=scheduleHour.TypeAbsenceId,
                TypeAbsenceReasonId=scheduleHour.TypeAbsenceReasonId
            };

            db.ScheduleHours.Add(scheduleHourData);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<ScheduleHourTypeAbsenceReason> GetScheduleTypeAbsenceReasons()
        => this.db
           .TypeAbsenceReasons
           .Select(x => new ScheduleHourTypeAbsenceReason
           {
               TypeAbsenceReasonId = x.TypeAbsenceReasonId,
               Name = x.Name
           })
           .ToList();

        private IEnumerable<ScheduleHourTypeAbsence> GetScheduleTypeAbsences()
        => this.db
           .TypeAbsences
           .Select(x => new ScheduleHourTypeAbsence
           {
               TypeAbsenceId = x.TypeAbsenceId,
               Name = x.Name
           })
           .ToList();

        private IEnumerable<AllScheduleModel> GetSchedule()
        => this.db
           .Schedules
           .Select(x => new AllScheduleModel
           {
               ScheduleId = x.ScheduleId,
               SubjectName = x.Course.Subject.Name,
               TeacherName = x.Course.Teacher.Name,
               Term_Number = x.Term_Number,
               DayOfWeek = x.DayOfWeek,
               SchoolHour = x.SchoolHour
           })
           .ToList();

        private IEnumerable<AddStudentFormModel> GetScheduleStudents()
        => this.db
           .Students
           .Select(x => new AddStudentFormModel
           {
               StudentId=x.StudentId,
               NumInClass = x.NumInClass,
               Name = x.Name
           })
           .ToList();
    }
}
