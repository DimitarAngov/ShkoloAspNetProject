namespace Shkolo.Models.Courses
{
    using Shkolo.Models.Subjects;
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;

    public class AddCourseFormModel
    {
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public int TypeSubjectId { get; set; }
        public int TeacherId { get; set; }

        public IEnumerable<AddTeacherFormModel> CTeachers { get; set; }
        public IEnumerable<AddSubjectFormModel> CSubjects { get; set; }
        public IEnumerable<TypeSubjectModel> CTypeSubjects { get; set; }

    }
}
