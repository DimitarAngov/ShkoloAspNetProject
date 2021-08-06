namespace Shkolo.Services.Courses
{
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Courses;
    using Shkolo.Models.Subjects;
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;
    using System.Linq;
    public class CoursesService : ICoursesService
    {
        private readonly ShkoloDbContext db;
        public CoursesService(ShkoloDbContext db)
        {
            this.db = db;
        }
        public void AddCourse(AddCourseFormModel course)
        {

            var courseData = new Course
            {
                TeacherId = course.TeacherId,
                SubjectId = course.SubjectId,
                TypeSubjectId = course.TypeSubjectId
            };

            db.Courses.Add(courseData);
            db.SaveChanges();

        }
        public ICollection<AllCourseModel> GetAllCourses()
        {
            var courses = this.db
            .Courses
            .OrderBy(x => x.CourseId)
            .Select(x => new Models.Courses.AllCourseModel
            {
                CourseId = x.CourseId,
                TeacherName = x.Teacher.Name,
                SubjectName = x.Subject.Name,
                TypeSubjectName = x.TypeSubject.Name

            }).ToList();
            return courses;
        }
        public IEnumerable<AddSubjectFormModel> GetCourseSubjects()
        => this.db
           .Subjects
           .Select(x => new AddSubjectFormModel
           {
               SubjectId = x.SubjectId,
               Name = x.Name
           })
           .ToList();
        public IEnumerable<AddTeacherFormModel> GetCourseTeachers()
       => this.db
           .Teachers
           .Select(x => new AddTeacherFormModel
           {
               TeacherId = x.TeacherId,
               Name = x.Name,
           })
           .ToList();
        public IEnumerable<TypeSubjectModel> GetCourseTypeSubjects()
        => this.db
           .TypeSubjects
           .Select(x => new TypeSubjectModel
           {
               TypeSubjectId = x.TypeSubjectId,
               Name = x.Name
           })
           .ToList();
    }
}
