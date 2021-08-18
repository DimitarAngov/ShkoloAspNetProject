namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Parent
    {
        public Parent()
        {
            this.Students = new HashSet<Student>();
        }
        public int ParentId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string Phone { get; set; }

        [MaxLength(EmailMaxLength)]
        [EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(AdressMaxLength)]
        public string Address { get; set; }
        public ICollection<Student> Students { get; set; }
    }

}
