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

        public IActionResult Add() => View(new AddScheduleFormModel
        {
            SchCourses = this.schedulesService.GetScheduleCourses()
        });

        [HttpPost]
        public IActionResult Add(AddScheduleFormModel schedule)
        {
            if (!ModelState.IsValid)
            {
                return View(schedule);
            }

            this.schedulesService.AddSchedule(schedule);
            return RedirectToAction("Index", "Home");
        }

       

    }
}
