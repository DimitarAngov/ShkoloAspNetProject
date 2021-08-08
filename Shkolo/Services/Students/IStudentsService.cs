namespace Shkolo.Services.Students
{
    using Shkolo.Models.Students;
    using System.Collections.Generic;

    public interface IStudentsService
    {
        public ICollection<AllStudentViewModel> GetAllStudents();
        public IEnumerable<StudentDiaryModel> GetStudentDiary();
        public IEnumerable<StudentParentModel> GetStudentParent();
        public IEnumerable<StudentDoctorModel> GetStudentDoctor();
        public void AddStudent(StudentFormModel student);
        public StudentFormModel FindById(int id);
        public void Edit(int id, StudentFormModel student);
        public void Delete(int id);

    }
}
