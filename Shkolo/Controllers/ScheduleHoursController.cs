namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.ScheduleHours;
    using Shkolo.Models.Schedules;
    using Shkolo.Models.Students;
    using Shkolo.Services.Grades;
    using Shkolo.Services.ScheduleHours;
    using System.Collections.Generic;
    using System.Linq;

    public class ScheduleHoursController:Controller
    {
       
        private readonly IScheduleHoursService scheduleHoursService;
        private readonly IGradesService gradesService;
        public ScheduleHoursController(IScheduleHoursService scheduleHoursService,IGradesService gradesService)
        {
            this.scheduleHoursService = scheduleHoursService;
            this.gradesService=gradesService;
        }

        public IActionResult All(string teacherName, 
                                 string subjectName,
                                 string searchTermOne,
                                 string searchTermTwo,
                                 string searchTermThree)
        {
                    
            var teacherN = scheduleHoursService.TeacherN();
            var subjectN = gradesService.SubjectN();
            var scheduleHour = scheduleHoursService.GetAllScheduleHours(teacherName,subjectName,searchTermOne,searchTermTwo,searchTermThree);
            
            return View(new ScheduleHourSearchViewModel 
            {
                AllTeachersName=teacherN,
                AllSubjectsName=subjectN,
                AllScheduleHours=scheduleHour,
                SearchTermOne=searchTermOne,
                SearchTermTwo=searchTermTwo
            });
        }
       
        public IActionResult Add() => View(new ScheduleHourFormModel
        {
            SchStudent = this.scheduleHoursService.GetScheduleStudents(),
            SchSchedule = this.scheduleHoursService.GetSchedule(),
            SchTypeAbsence = this.scheduleHoursService.GetScheduleTypeAbsences(),
            SchTypeAbsenceReason = this.scheduleHoursService.GetScheduleTypeAbsenceReasons(),
        });

        [HttpPost]
        public IActionResult Add(ScheduleHourFormModel scheduleHour)
        {
            if (!ModelState.IsValid)
            {
                return View(scheduleHour);
            }

            this.scheduleHoursService.AddScheduleHour(scheduleHour);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var scheduleHoursFindById = this.scheduleHoursService.FindById(id);

            return View(new ScheduleHourFormModel
            {
                ScheduleHourId = scheduleHoursFindById.ScheduleHourId,
                Date = scheduleHoursFindById.Date,
                ScheduleId = scheduleHoursFindById.ScheduleId,
                Topics = scheduleHoursFindById.Topics,
                StudentId = scheduleHoursFindById.StudentId,
                TypeAbsenceId = scheduleHoursFindById.TypeAbsenceId,
                TypeAbsenceReasonId = scheduleHoursFindById.TypeAbsenceReasonId,
                SchStudent = this.scheduleHoursService.GetScheduleStudents(),
                SchSchedule = this.scheduleHoursService.GetSchedule(),
                SchTypeAbsence = this.scheduleHoursService.GetScheduleTypeAbsences(),
                SchTypeAbsenceReason = this.scheduleHoursService.GetScheduleTypeAbsenceReasons()
            });
        }


        [HttpPost]
        public IActionResult Edit(int id, ScheduleHourFormModel scheduleHour)
        {
            if (!ModelState.IsValid)
            {
                return View(scheduleHour);
            }

            this.scheduleHoursService.Edit(id, scheduleHour);
            return RedirectToAction("All", "ScheduleHours");

        }
    }
}
