namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    using static DataConstants.Schedule;

    public class Schedule
    {
        public Schedule()
        {
           this.ScheduleHours = new HashSet<ScheduleHour>();
        }
        public int ScheduleId { get; set; }

        [Range(TermNumberMin, TermNumberMax)]
        public int Term_Number { get; set; }

        [Range(ScheduleDayOfWeekMin, ScheduleDayOfWeekMax)]
        public int DayOfWeek { get; set; }

        [Range(ScheduleSchoolHourMin, ScheduleSchoolHourMax)]
        public int SchoolHour { get; set; }

        [MaxLength(DateMax)]
        public string FromTime { get; set; }

        [MaxLength(DateMax)]
        public string ToTime { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<ScheduleHour> ScheduleHours { get; set; }
    }

}
