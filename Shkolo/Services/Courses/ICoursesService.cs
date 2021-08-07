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
        public IEnumerable<AddTeacherFormModel> GetCourseTeachers();
        public IEnumerable<AddSubjectFormModel> GetCourseSubjects();
        public IEnumerable<TypeSubjectModel> GetCourseTypeSubjects();
        public void AddCourse(AddCourseFormModel course);
    }
}
