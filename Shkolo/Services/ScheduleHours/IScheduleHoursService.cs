using Shkolo.Models.ScheduleHours;
using Shkolo.Models.Schedules;
using Shkolo.Models.Students;
using System.Collections.Generic;

namespace Shkolo.Services.ScheduleHours
{
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
        public IEnumerable<AddStudentFormModel> GetScheduleStudents();
        public void AddScheduleHour(AddScheduleHourFormModel scheduleHour);
        public IEnumerable<string> TeacherN();
    }
}
