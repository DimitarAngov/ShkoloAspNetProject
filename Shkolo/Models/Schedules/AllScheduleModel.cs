namespace Shkolo.Models.Schedules
{
    using System.ComponentModel.DataAnnotations;
    public class AllScheduleModel
    {
        public int ScheduleId { get; set; }
        public int Term_Number { get; set; }
        public int DayOfWeek { get; set; }
        public int SchoolHour { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
    }
}
