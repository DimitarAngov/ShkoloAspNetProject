﻿namespace Shkolo.Data.Models
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
       
        [Required]
        [MaxLength(4)]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        [MaxLength(1)]
        public int TypeAbsenceId { get; set; }
        public TypeAbsence TypeAbsence { get; set; }

        [Required]
        [MaxLength(1)]
        public int TypeAbsenceReasonId { get; set; }
        public TypeAbsenceReason TypeAbsenceReason { get; set; }
    }

}
