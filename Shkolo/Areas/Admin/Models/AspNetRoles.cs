namespace Shkolo.Areas.Admin.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AspNetRoles
    {
        public string Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<AspNetUserRoles> ur { get; set; } = new HashSet<AspNetUserRoles>();
    }
}
