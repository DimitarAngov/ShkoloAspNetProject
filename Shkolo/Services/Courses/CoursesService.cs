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
        public void AddCourse(CourseFormModel course)
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

        public void Delete(int id)
        {
            var CourseDel = this.db.Courses.FirstOrDefault(x => x.CourseId == id);
            this.db.Courses.Remove(CourseDel);
            db.SaveChanges();
        }

        public void Edit(int id, CourseFormModel course)
        {
            var courseData = new Course
            {
                CourseId = id,
                TeacherId = course.TeacherId,
                SubjectId = course.SubjectId,
                TypeSubjectId = course.TypeSubjectId
            };

            db.Courses.Update(courseData);
            db.SaveChanges();
        }

        public CourseFormModel FindById(int id)
                     => this.db
                    .Courses
                    .Where(x => x.CourseId == id)
                    .Select(x => new CourseFormModel
                    {
                        CourseId=x.CourseId,
                        TeacherId = x.TeacherId,
                        SubjectId=x.SubjectId,
                        TypeSubjectId=x.TypeSubjectId
                    })
                    .FirstOrDefault();
       
        public ICollection<AllCourseViewModel> GetAllCourses()
        {
            var courses = this.db
            .Courses
            .OrderBy(x => x.CourseId)
            .Select(x => new Models.Courses.AllCourseViewModel
            {
                CourseId = x.CourseId,
                TeacherName = x.Teacher.Name,
                SubjectName = x.Subject.Name,
                TypeSubjectName = x.TypeSubject.Name

            }).ToList();
            return courses;
        }
        public IEnumerable<SubjectFormModel> GetCourseSubjects()
        => this.db
           .Subjects
           .Select(x => new SubjectFormModel
           {
               SubjectId = x.SubjectId,
               Name = x.Name
           })
           .ToList();
        public IEnumerable<TeacherFormModel> GetCourseTeachers()
       => this.db
           .Teachers
           .Select(x => new TeacherFormModel
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
