namespace Shkolo.Models.Grades
{
    using Shkolo.Models.Students;
    using System.Collections.Generic;
    public class AllGradeSearchViewModel
    {
        public string StudentName { get; set; }
        public IEnumerable<string> AllStudentsName { get; set; }
        public string SubjectName { get; set; }
        public IEnumerable<string> AllSubjectsName { get; set; }
        public string GradeStudent { get; set; }
        public IEnumerable<string> AllGradesStudents { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<AllGradeViewModel> AllGrades { get; set; }
    }
}
