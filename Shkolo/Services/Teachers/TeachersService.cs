using Shkolo.Data;
using Shkolo.Data.Models;
using Shkolo.Models.Teachers;
using System.Collections.Generic;
using System.Linq;

namespace Shkolo.Services.Teachers
{
    public class TeachersService:ITeachersService
    {
        private readonly ShkoloDbContext db;
        public TeachersService(ShkoloDbContext db)
        {
            this.db = db;
        }
        public ICollection<AddTeacherFormModel> GetAllTeachers() 
        {
            var teachers = this.db
           .Teachers
           .OrderBy(x => x.TeacherId)
           .Select(x => new AddTeacherFormModel
           {
               TeacherId = x.TeacherId,
               Name = x.Name,
           }).ToList();

            return teachers;
        }

        public void AddTeacher(AddTeacherFormModel teacher)
        {
            var teacherData = new Teacher
            {
                Name = teacher.Name,
            };

            db.Teachers.Add(teacherData);
            db.SaveChanges();
        }

    }
}
