namespace Shkolo.Models.Teachers
{
 using System.ComponentModel.DataAnnotations;  
    public class AddTeacherFormModel
    {
        public int TeacherId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
