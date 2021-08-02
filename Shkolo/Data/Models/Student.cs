namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public Student()
        {
            this.StudentsCourses = new HashSet<StudentCourse>();
            this.ScheduleHours = new HashSet<ScheduleHour>();
        }
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string DateOfBirth { get; set; }

        [Required]
        [MaxLength(20)]
        public string PlaceOfBirth { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(2)]
        public int NumInClass { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int DiaryId { get; set; }
        public Diary Diary { get; set; }

        [MaxLength(10)]
        public string PageNumCompulsoryEducationBook { get; set; }

        [MaxLength(30)]
        public string OrderToLeave { get; set; }

        [MaxLength(20)]
        public string OrderToEnroll { get; set; }
        public ICollection<StudentCourse> StudentsCourses { get; set; }
        public ICollection<ScheduleHour> ScheduleHours { get; set; }
    }

}
