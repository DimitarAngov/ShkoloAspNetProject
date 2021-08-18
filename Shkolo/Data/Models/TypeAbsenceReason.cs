namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.TypeAbsence;
    public class TypeAbsenceReason
    {
        public TypeAbsenceReason()
        {
            this.ScheduleHours = new HashSet<ScheduleHour>();
        }
        public int TypeAbsenceReasonId { get; set; }

        [Required]
        [MaxLength(TypeAbsenceNameMaxLength)]
        public string Name { get; set; }

        public ICollection<ScheduleHour> ScheduleHours { get; set; }
    }
}
