namespace Shkolo.Services.Courses
{
    using Shkolo.Models.Courses;
    using Shkolo.Models.Subjects;
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;
    public interface ICoursesService
    {
        public ICollection<AllCourseViewModel> GetAllCourses();
        public IEnumerable<TeacherFormModel> GetCourseTeachers();
        public IEnumerable<SubjectFormModel> GetCourseSubjects();
        public IEnumerable<TypeSubjectModel> GetCourseTypeSubjects();
        public void AddCourse(CourseFormModel course);
        public void Delete(int id);
        public CourseFormModel FindById(int id);
        public void Edit(int id, CourseFormModel course);
    }
}
