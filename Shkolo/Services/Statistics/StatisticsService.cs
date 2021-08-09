namespace Shkolo.Services.Statistics
{
    using Shkolo.Data;
    using System.Linq;
    public class StatisticsService:IStatisticsService
    {
        private readonly ShkoloDbContext db;
        public StatisticsService(ShkoloDbContext db)
            => this.db = db;
        public StatisticsServiceModel Total()
        {
            var totalStudents = this.db.Students.Count();
            var totalSubjects = this.db.Subjects.Count();
            var totalTeachers = this.db.Teachers.Count();
            var totalCourses = this.db.Courses.Count();
            var totalGrades=this.db.Grades.Count();
            var totalHours = this.db.ScheduleHours.Count();
            var totalAbsences = this.db.ScheduleHours.Where(x => x.TypeAbsence.Name !="").Count();


            return new StatisticsServiceModel
            {
                TotalStudents = totalStudents,
                TotalSubjects = totalSubjects,
                TotalTeachers=totalTeachers,
                TotalCouses=totalCourses,
                TotalGrages=totalGrades,
                TotalHours=totalHours,
                TotalAbsences=totalAbsences
            };
        }
    }
}
