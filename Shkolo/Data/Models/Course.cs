namespace Shkolo.Data.Models
{
    using System.Collections.Generic;
    public class Course
    {
        public Course()
        {
            this.StudentsCourses = new HashSet<StudentCourse>();
            this.Schedules = new HashSet<Schedule>();

        }
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int TypeSubjectId { get; set; }
        public TypeSubject TypeSubject { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<StudentCourse> StudentsCourses { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }

}
