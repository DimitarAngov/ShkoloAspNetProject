namespace Shkolo.Models.Teachers
{
 using System.ComponentModel.DataAnnotations;  
    public class AddTeacherFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
