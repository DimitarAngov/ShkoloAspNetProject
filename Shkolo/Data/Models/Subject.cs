namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Subject
    {
        public Subject()
        {
            this.Courses = new HashSet<Course>();
        }
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
