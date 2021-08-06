namespace Shkolo.Services.Statistics
{
    using Shkolo.Data;
    using System.Linq;
    public class StatisticsService:IStatisticsService
    {
        private readonly ShkoloDbContext data;
        public StatisticsService(ShkoloDbContext data)
            => this.data = data;
        public StatisticsServiceModel Total()
        {
            var totalStudents = this.data.Students.Count();
            var totalSubjects = this.data.Subjects.Count();
            var totalTeachers = this.data.Teachers.Count();
            var totalCourses = this.data.Courses.Count();

            return new StatisticsServiceModel
            {
                TotalStudents = totalStudents,
                TotalSubjects = totalSubjects,
                TotalTeachers=totalTeachers,
                TotalCouses=totalCourses
            };
        }
    }
}
