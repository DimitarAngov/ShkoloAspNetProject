namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Courses;
    using Shkolo.Models.Schedules;
    using System.Collections.Generic;
    using System.Linq;

    public class SchedulesController:Controller
    {
        private readonly ShkoloDbContext db;
        public SchedulesController(ShkoloDbContext db)
        {
            this.db = db;
        }

        public IActionResult All()
        {
            var schedules = this.db
            .Schedules
            .OrderBy(x => x.Term_Number)
            .ThenBy(x=>x.DayOfWeek)
            .ThenBy(x=>x.SchoolHour)
            .Select(x => new AllScheduleModel
            { 
                
                Term_Number = x.Term_Number,
                DayOfWeek=x.DayOfWeek,
                SchoolHour=x.SchoolHour,
                TeacherName=x.Course.Teacher.Name,
                SubjectName=x.Course.Subject.Name

            }).ToList();

            return View(schedules);
        }

        public IActionResult Add() => View(new AddScheduleFormModel
        {
            SchCourses = GetScheduleCourses()
        });

        [HttpPost]
        public IActionResult Add(AddScheduleFormModel schedule)
        {
            if (!ModelState.IsValid)
            {
                return View(schedule);
            }

            var scheduleData = new Schedule
            {
                ScheduleId = schedule.ScheduleId,
                Term_Number = schedule.Term_Number,
                DayOfWeek = schedule.DayOfWeek,
                SchoolHour = schedule.Term_Number,
                FromTime = schedule.FromTime,
                ToTime = schedule.ToTime,
                CourseId = schedule.CourseId,
                
            };

            db.Schedules.Add(scheduleData);
            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        public IEnumerable<AllCourseModel> GetScheduleCourses()
        => this.db
            .Courses
            .Select(x => new AllCourseModel
            {
                CourseId = x.CourseId,
                TeacherName = x.Teacher.Name,
                SubjectName = x.Subject.Name,
                TypeSubjectName=x.TypeSubject.Name
            })
            .ToList();

    }
}
