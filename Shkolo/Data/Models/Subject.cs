namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Subject
    {
        public Subject()
        {
            this.Courses = new HashSet<Course>();
        }
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
