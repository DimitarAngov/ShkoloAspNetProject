namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TypeSubject
    {
        public TypeSubject()
        {
            this.Courses = new HashSet<Course>();
        }
        public int TypeSubjectId { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
