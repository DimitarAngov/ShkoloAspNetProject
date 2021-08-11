namespace Shkolo.Services.ScheduleHours
{
    using Shkolo.Models.ScheduleHours;
    using Shkolo.Models.Schedules;
    using Shkolo.Models.Students;
    using System.Collections.Generic;
    public interface IScheduleHoursService
    {
        public ICollection<AllScheduleHourViewModel> GetAllScheduleHours(
                                 string teacherName,
                                 string subjectName,
                                 string searchTermOne,
                                 string searchTermTwo,
                                 string searchTermThree);
        public IEnumerable<ScheduleHourTypeAbsenceReason> GetScheduleTypeAbsenceReasons();
        public IEnumerable<ScheduleHourTypeAbsence> GetScheduleTypeAbsences();
        public IEnumerable<AllScheduleViewModel> GetSchedule();
        public IEnumerable<StudentFormModel> GetScheduleStudents();
        public void AddScheduleHour(ScheduleHourFormModel scheduleHour);
        public IEnumerable<string> TeacherN();
        public void Delete(int id);
        public ScheduleHourFormModel FindById(int id);
        public void Edit(int id, ScheduleHourFormModel teacher);
    }
}
