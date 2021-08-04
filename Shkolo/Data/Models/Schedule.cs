namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Schedule
    {
        public Schedule()
        {
           this.ScheduleHours = new HashSet<ScheduleHour>();
        }
        public int ScheduleId { get; set; }

        [Range(1,2)]
        public int Term_Number { get; set; }

        [Range(1,5)]
        public int DayOfWeek { get; set; }

        [Range(1,11)]
        public int SchoolHour { get; set; }

        [MaxLength(10)]
        public string FromTime { get; set; }

        [MaxLength(10)]
        public string ToTime { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<ScheduleHour> ScheduleHours { get; set; }
    }

}
