namespace Shkolo.Models.ScheduleHours
{
    using Shkolo.Models.Schedules;
    using Shkolo.Models.Students;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AddScheduleHourFormModel
    {
        public int ScheduleHourId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Date { get; set; }
        
        [Required]
        public int ScheduleId { get; set; }
        
        [Required]
        [MaxLength(1000)]
        public string Topics { get; set; }

        [Required]
        [Range(1,2000)]
        public int StudentId { get; set; }
        
        [Required]
        [Range(1,10)]
        public int TypeAbsenceId { get; set; }

        [Required]
        [Range(1,10)]
        public int TypeAbsenceReasonId { get; set; }

        public IEnumerable<AllScheduleViewModel> SchSchedule { get; set; }
        public IEnumerable<AddStudentFormModel> SchStudent { get; set; }
        public IEnumerable<ScheduleHourTypeAbsence> SchTypeAbsence { get; set; }
        public IEnumerable<ScheduleHourTypeAbsenceReason> SchTypeAbsenceReason { get; set; }


    }
}
