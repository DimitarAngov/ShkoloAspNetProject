namespace Shkolo.Models.Schedules
{
    using Shkolo.Models.Courses;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    using static Data.DataConstants.Schedule;
    public class AddScheduleFormModel
    {
        public int ScheduleId { get; set; }

        [Required]
        [Range(TermNumberMin, TermNumberMax)]
        public int Term_Number { get; set; }

        [Required]
        [Range(ScheduleDayOfWeekMin, ScheduleDayOfWeekMax)]
        public int DayOfWeek { get; set; }

        [Required]
        [Range(ScheduleSchoolHourMin, ScheduleSchoolHourMax)]
        public int SchoolHour { get; set; }

        [MaxLength(10)]
        public string FromTime { get; set; }

        [MaxLength(10)]
        public string ToTime { get; set; }
        public int CourseId { get; set; }
        public IEnumerable<AllCourseModel> SchCourses { get; set; }
    }
}
