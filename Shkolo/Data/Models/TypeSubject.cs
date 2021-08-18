namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.TypeSubject;
    public class TypeSubject
    {
        public TypeSubject()
        {
            this.Courses = new HashSet<Course>();
        }
        public int TypeSubjectId { get; set; }
        
        [Required]
        [MaxLength(TypeSubjectNameMaxLength)]
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
