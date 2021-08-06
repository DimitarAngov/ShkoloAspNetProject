namespace Shkolo.Models.ScheduleHours
{
    using System.Collections.Generic;

    public class ScheduleHourSearchViewModel
    {
        public string TeacherName { get; set; }
        public IEnumerable<string> AllTeachersName { get; set; }
        public string SubjectName { get; set; }
        public IEnumerable<string> AllSubjectsName { get; set; }
        public string SearchTermOne { get; set; }
        public string SearchTermTwo { get; set; }
        public string SearchTermThree { get; set; }
public IEnumerable<AllScheduleHourModel> AllScheduleHours { get; set; }
    }
}
