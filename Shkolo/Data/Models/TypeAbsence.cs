namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TypeAbsence
    {
        public TypeAbsence()
        {
            this.ScheduleHours = new HashSet<ScheduleHour>();
        }
        public int TypeAbsenceId { get; set; }

        [Required]
        [MaxLength(12)]
        public string Name { get; set; }

        public ICollection<ScheduleHour> ScheduleHours { get; set; }

    }
}
