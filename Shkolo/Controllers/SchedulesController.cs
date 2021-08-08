namespace Shkolo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Models.Schedules;
    using Shkolo.Services.Schedules;
     public class SchedulesController:Controller
    {
        private readonly ISchedulesService schedulesService;
        public SchedulesController(ISchedulesService schedulesService)
        {
            this.schedulesService = schedulesService;
        }

        public IActionResult All()
        {
            var schedules = this.schedulesService.GetAllSchedules();
            return View(schedules);
        }
        public IActionResult Delete(int Id)
        {
            this.schedulesService.Delete(Id);
            return this.Redirect("/Schedules/All");
        }

        public IActionResult Add() => View(new ScheduleFormModel
        {
            SchCourses = this.schedulesService.GetScheduleCourses()
        });

        [HttpPost]
        public IActionResult Add(ScheduleFormModel schedule)
        {
            if (!ModelState.IsValid)
            {
                return View(schedule);
            }

            this.schedulesService.AddSchedule(schedule);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var scheduleFindById = this.schedulesService.FindById(id);

            return View(new ScheduleFormModel
            {
                ScheduleId = scheduleFindById.ScheduleId,
                Term_Number = scheduleFindById.Term_Number,
                DayOfWeek = scheduleFindById.DayOfWeek,
                SchoolHour = scheduleFindById.SchoolHour,
                FromTime = scheduleFindById.FromTime,
                ToTime = scheduleFindById.ToTime,
                CourseId = scheduleFindById.CourseId,
                SchCourses = this.schedulesService.GetScheduleCourses()
            });
        }


        [HttpPost]
        public IActionResult Edit(int id, ScheduleFormModel schedule)
        {
            if (!ModelState.IsValid)
            {
                return View(schedule);
            }

            this.schedulesService.Edit(id, schedule);
            return RedirectToAction("All", "Schedules");

        }



    }
}
