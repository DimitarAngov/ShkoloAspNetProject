namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Doctor
    {
        public Doctor()
        {
            this.Students = new HashSet<Student>();
        }
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string Phone { get; set; }
        public ICollection<Student> Students { get; set; }
    }

}
