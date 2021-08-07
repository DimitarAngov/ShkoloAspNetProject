namespace Shkolo.Services.Schedules
{
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Courses;
    using Shkolo.Models.Schedules;
    using System.Collections.Generic;
    using System.Linq;

    public class SchedulesService:ISchedulesService
    {
        private readonly ShkoloDbContext db;
        public SchedulesService(ShkoloDbContext db)
        {
            this.db = db;
        }

        public void AddSchedule(AddScheduleFormModel schedule)
        {
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
        }

        public ICollection<AllScheduleViewModel> GetAllSchedules()
        {
            var schedules = this.db
            .Schedules
            .OrderBy(x => x.Term_Number)
            .ThenBy(x => x.DayOfWeek)
            .ThenBy(x => x.SchoolHour)
            .Select(x => new AllScheduleViewModel
            {

                Term_Number = x.Term_Number,
                DayOfWeek = x.DayOfWeek,
                SchoolHour = x.SchoolHour,
                TeacherName = x.Course.Teacher.Name,
                SubjectName = x.Course.Subject.Name

            }).ToList();
            return schedules;
        }

        public IEnumerable<AllCourseViewModel> GetScheduleCourses()
         => this.db
           .Courses
           .Select(x => new AllCourseViewModel
           {
               CourseId = x.CourseId,
               TeacherName = x.Teacher.Name,
               SubjectName = x.Subject.Name,
               TypeSubjectName = x.TypeSubject.Name
           })
           .ToList();
    }
}
