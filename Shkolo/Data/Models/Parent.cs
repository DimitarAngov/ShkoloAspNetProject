namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Parent
    {
        public Parent()
        {
            this.Students = new HashSet<Student>();
        }
        public int ParentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(30)]
        [EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(100)]
        public string Address { get; set; }
        public ICollection<Student> Students { get; set; }
    }

}
