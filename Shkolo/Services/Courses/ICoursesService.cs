using Shkolo.Models.Courses;
using Shkolo.Models.Subjects;
using Shkolo.Models.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shkolo.Services.Courses
{
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
