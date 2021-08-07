namespace Shkolo.Services.Schedules
{
    using Shkolo.Models.Courses;
    using Shkolo.Models.Schedules;
    using System.Collections.Generic;
    public interface ISchedulesService
    {
        public ICollection<AllScheduleViewModel> GetAllSchedules();
        public IEnumerable<AllCourseViewModel> GetScheduleCourses();
        public void AddSchedule(AddScheduleFormModel schedule);
    }
}
