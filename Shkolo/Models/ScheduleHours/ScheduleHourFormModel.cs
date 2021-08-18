namespace Shkolo.Models.ScheduleHours
{
    using Shkolo.Models.Schedules;
    using Shkolo.Models.Students;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    using static Data.DataConstants.ScheduleHour;
    using static Data.DataConstants.Student;
    public class ScheduleHourFormModel
    {
        public int ScheduleHourId { get; set; }

        [Required]
        [MaxLength(DateMax)]
        public string Date { get; set; }
        
        [Required]
        public int ScheduleId { get; set; }
        
        [Required]
        [MaxLength(ScheduleHourTopicsMaxLength)]
        public string Topics { get; set; }

        [Required]
        [Range(StudentIdMin, StudentIdMax)]
        public int StudentId { get; set; }
        
        [Required]
        [Range(TypeAbsenceIdMin, TypeAbsenceIdMax)]
        public int TypeAbsenceId { get; set; }

        [Required]
        [Range(TypeAbsenceReasonIdMin, TypeAbsenceReasonIdMax)]
        public int TypeAbsenceReasonId { get; set; }

        public IEnumerable<AllScheduleViewModel> SchSchedule { get; set; }
        public IEnumerable<StudentFormModel> SchStudent { get; set; }
        public IEnumerable<ScheduleHourTypeAbsence> SchTypeAbsence { get; set; }
        public IEnumerable<ScheduleHourTypeAbsenceReason> SchTypeAbsenceReason { get; set; }


    }
}
