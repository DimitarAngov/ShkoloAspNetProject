namespace Shkolo.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;
    public class AspNetRoles
    {
        public string Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
