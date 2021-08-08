namespace Shkolo.Services.Teachers
{
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;
    public interface ITeachersService
    {
        public ICollection<TeacherFormModel> GetAllTeachers();
        public void AddTeacher(TeacherFormModel teacher);
        public void Delete(int id);
        public TeacherFormModel FindById(int id);
        public void Edit(int id,TeacherFormModel teacher);
    }
}
