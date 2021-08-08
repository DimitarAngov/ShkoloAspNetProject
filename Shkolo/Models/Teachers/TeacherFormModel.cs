namespace Shkolo.Models.Teachers
{
 using System.ComponentModel.DataAnnotations;  
    public class TeacherFormModel
    {
        public int TeacherId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
