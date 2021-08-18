namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    using static DataConstants.Student;

    public class Student
    {
        public Student()
        {
            this.StudentsCourses = new HashSet<StudentCourse>();
            this.ScheduleHours = new HashSet<ScheduleHour>();
        }
        public int StudentId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(StudentDateOfBirthMin)]
        public string DateOfBirth { get; set; }

        [Required]
        [MaxLength(StudentPlaceOfBirthMax)]
        public string PlaceOfBirth { get; set; }

        [Required]
        [MaxLength(AdressMaxLength)]
        public string Address { get; set; }

        [MaxLength(PhoneNumberMaxLength)]
        public string Phone { get; set; }

        [Range(NumInClassMin, NumInClassMax)]
        public int NumInClass { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int DiaryId { get; set; }
        public Diary Diary { get; set; }

        [MaxLength(StudentPageNum)]
        public string PageNumCompulsoryEducationBook { get; set; }

        [MaxLength(StudentOrderToLeave)]
        public string OrderToLeave { get; set; }

        [MaxLength(StudentOrderToEnroll)]
        public string OrderToEnroll { get; set; }
        public ICollection<StudentCourse> StudentsCourses { get; set; }
        public ICollection<ScheduleHour> ScheduleHours { get; set; }
    }

}
