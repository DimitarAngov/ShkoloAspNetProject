namespace Shkolo.Services.Grades
{
    using Shkolo.Data.Models;
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
        public void AddGrade(GradeFormModel grade);
        public IEnumerable<string> SubjectN();
        public IEnumerable<string> StudenttN();
        public IEnumerable<string> GradeStudents();
        public void Delete(int id);
        public GradeFormModel FindById(int id);
        public void Edit(int id, GradeFormModel teacher);
        public ICollection<AllGradeViewModel> GetAllGradesByStudent(string studentName);
        public ICollection<AllGradeViewModel> GetAllGradesBySubject(string subjectName);
               
    }
}
