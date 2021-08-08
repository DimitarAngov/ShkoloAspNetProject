namespace Shkolo.Models.Courses
{
    using Shkolo.Models.Subjects;
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;

    public class CourseFormModel
    {
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public int TypeSubjectId { get; set; }
        public int TeacherId { get; set; }

        public IEnumerable<TeacherFormModel> CTeachers { get; set; }
        public IEnumerable<SubjectFormModel> CSubjects { get; set; }
        public IEnumerable<TypeSubjectModel> CTypeSubjects { get; set; }

    }
}
