namespace Shkolo.Models.Schedules
{
    using Shkolo.Models.Courses;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AddScheduleFormModel
    {
        public int ScheduleId { get; set; }

        [Required]
        [MaxLength(1)]
        public int Term_Number { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(2)]
        public int DayOfWeek { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(2)]
        public int SchoolHour { get; set; }

        [MaxLength(10)]
        public string FromTime { get; set; }

        [MaxLength(10)]
        public string ToTime { get; set; }
        public int CourseId { get; set; }
        public IEnumerable<AllCourseModel> SchCourses { get; set; }
    }
}
