namespace Shkolo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ScheduleHour
    {
        public int ScheduleHourId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Date { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Topics { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public int? TypeAbsenceId { get; set; }
        public TypeAbsence TypeAbsence { get; set; }
        public int? TypeAbsenceReasonId { get; set; }
        public TypeAbsenceReason TypeAbsenceReason { get; set; }
    }

}
