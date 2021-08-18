namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.TypeAbsence;

    public class TypeAbsence
    {
        public TypeAbsence()
        {
            this.ScheduleHours = new HashSet<ScheduleHour>();
        }
        public int TypeAbsenceId { get; set; }

        [Required]
        [MaxLength(TypeAbsenceNameMaxLength)]
        public string Name { get; set; }

        public ICollection<ScheduleHour> ScheduleHours { get; set; }

    }
}
