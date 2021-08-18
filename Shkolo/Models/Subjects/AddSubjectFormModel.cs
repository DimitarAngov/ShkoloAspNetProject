namespace Shkolo.Models.Subjects
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class AddSubjectFormModel
    {
        public int SubjectId { get; set; }
        
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
    }
}
