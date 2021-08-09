namespace Shkolo.Models.Students
{
    public class StudentAbsencesModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public int StudentNumInClass { get; set; }
        public string Date { get; set; }
        public int Hour { get; set; }
        public string AbsenceTypeName { get; set; }
        public string AbsenceTypeReasonName { get; set; }

    }
}
