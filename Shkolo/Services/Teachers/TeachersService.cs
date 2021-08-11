namespace Shkolo.Services.Teachers
{
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;
    using System.Linq;
    public class TeachersService : ITeachersService
    {
        private readonly ShkoloDbContext db;
        public TeachersService(ShkoloDbContext db)
        {
            this.db = db;
        }
        public ICollection<TeacherFormModel> GetAllTeachers()
        {
            var teachers = this.db
           .Teachers
           .OrderBy(x => x.TeacherId)
           .Select(x => new TeacherFormModel
           {
               TeacherId = x.TeacherId,
               Name = x.Name,
           }).ToList();
            
            return teachers;
        }
        public void AddTeacher(TeacherFormModel teacher)
        {
            var teacherData = new Teacher
            {
                Name = teacher.Name,
            };

            db.Teachers.Add(teacherData);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var TeacherDel = this.db.Teachers.FirstOrDefault(x => x.TeacherId == id);
            this.db.Teachers.Remove(TeacherDel);
            db.SaveChanges();
        }
        public TeacherFormModel FindById(int id)
                    => this.db
                    .Teachers
                    .Where(x=>x.TeacherId==id)
                    .Select(x=>new TeacherFormModel 
                    {
                        TeacherId=x.TeacherId,
                        Name=x.Name
                    })
                    .FirstOrDefault();
        public void Edit(int id,TeacherFormModel teacher)
        {
            var teacherData = new Teacher
            {
                TeacherId=id,
                Name = teacher.Name,
            };

            db.Teachers.Update(teacherData);
            db.SaveChanges();
        }
    }
}
