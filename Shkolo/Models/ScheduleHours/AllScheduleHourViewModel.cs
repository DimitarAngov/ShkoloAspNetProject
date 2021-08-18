namespace Shkolo.Models.ScheduleHours
{
    public class AllScheduleHourViewModel
    {
        public int ScheduleHourId { get; set; }
        public int Term_Number { get; set; }
        public string Date { get; set; }
        public int DayOfWeek { get; set; }
        public int SchoolHour { get; set; }
        public string ScheduleSubjectName { get; set; }
        public string ScheduleTeacherName { get; set; }
        public string Topics { get; set; }
        public int AbsenceStudentNimberInClass{ get; set; }
       
    }
}
