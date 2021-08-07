namespace Shkolo.Models.Courses
{
    using Shkolo.Models.Courses;
    using Shkolo.Models.Subjects;
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;

    public class AllCourseViewModel
    {
        public int CourseId { get; set; }
        public string SubjectName { get; set; }
        public string TypeSubjectName { get; set; }
        public string TeacherName { get; set; }
           
    }
}
