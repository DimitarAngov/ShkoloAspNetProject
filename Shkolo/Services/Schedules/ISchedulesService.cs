namespace Shkolo.Services.Schedules
{
    using Shkolo.Models.Courses;
    using Shkolo.Models.Schedules;
    using System.Collections.Generic;
    public interface ISchedulesService
    {
        public ICollection<AllScheduleViewModel> GetAllSchedules();
        public IEnumerable<AllCourseViewModel> GetScheduleCourses();
        public void AddSchedule(ScheduleFormModel schedule);
        public void Delete(int id);
        public ScheduleFormModel FindById(int id);
        public void Edit(int id, ScheduleFormModel teacher);
    }
}
