namespace Shkolo.Data.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int Term_Number { get; set; }
        public int StudentCourseId { get; set; }
        public StudentCourse StudentCourse { get; set; }
        public string GradeStudents { get; set; }
        public int TypeGradeId { get; set; }
        public TypeGrade TypeGrade { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }

}
