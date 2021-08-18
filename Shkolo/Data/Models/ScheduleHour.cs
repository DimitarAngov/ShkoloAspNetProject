namespace Shkolo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    using static DataConstants.ScheduleHour;
    using static DataConstants.Student;

    public class ScheduleHour
    {
        public int ScheduleHourId { get; set; }

        [Required]
        [MaxLength(DateMax)]
        public string Date { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        [Required]
        [MaxLength(ScheduleHourTopicsMaxLength)]
        public string Topics { get; set; }
       
        [Required]
        [Range(StudentIdMin,StudentIdMax)]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        [Range(TypeAbsenceIdMin, TypeAbsenceIdMax)]
        public int TypeAbsenceId { get; set; }
        public TypeAbsence TypeAbsence { get; set; }

        [Required]
        [Range(TypeAbsenceReasonIdMin, TypeAbsenceReasonIdMax)]
        public int TypeAbsenceReasonId { get; set; }
        public TypeAbsenceReason TypeAbsenceReason { get; set; }
    }

}
