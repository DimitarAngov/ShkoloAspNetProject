using System.ComponentModel.DataAnnotations;

namespace Shkolo.Areas.Admin.Models
{
    public class AspNetUsers
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
       
        [Required]
        [MaxLength(50)]
        public string PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
