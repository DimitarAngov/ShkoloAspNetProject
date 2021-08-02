namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Teacher
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
            this.Diaries = new HashSet<Diary>();
        }
        public int TeacherId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Diary> Diaries { get; set; }
    }

}
