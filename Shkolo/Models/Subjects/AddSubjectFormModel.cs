namespace Shkolo.Models.Subjects
{
    using System.ComponentModel.DataAnnotations;
    public class AddSubjectFormModel
    {
        public int SubjectId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
