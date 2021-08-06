namespace Shkolo.Services.Teachers
{
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;
    public interface ITeachersService
    {
        public ICollection<AddTeacherFormModel> GetAllTeachers();
        public void AddTeacher(AddTeacherFormModel teacher);
    }
}
