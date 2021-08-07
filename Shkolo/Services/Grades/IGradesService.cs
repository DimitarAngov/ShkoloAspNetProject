namespace Shkolo.Services.Grades
{
    using Shkolo.Models.Grades;
    using System.Collections.Generic;
    public interface IGradesService
    {
        public ICollection<AllGradeViewModel> GetAllGrades(
            string searchTerm,
            string studentName,
            string subjectName,
            string gradeStudent);
        public IEnumerable<TypeGradeModel> GetTypeGrades();
        public IEnumerable<StudentCourseModel> GetStudentCourses();
        public void AddGrade(AddGradeFormModel grade);
        public IEnumerable<string> SubjectN();
        public IEnumerable<string> StudenttN();
        public IEnumerable<string> GradeStudents();
    }
}
