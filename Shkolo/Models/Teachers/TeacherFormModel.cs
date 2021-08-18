namespace Shkolo.Models.Teachers
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class TeacherFormModel
    {
        public int TeacherId { get; set; }
        
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

    }
}
