namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StudentCourse
    {
        public StudentCourse()
        {
            this.Grades = new HashSet<Grade>();
        }
        [Key]
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Students { get; set; }
        public Course Courses { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
