namespace Shkolo.Data.Datasets.Services
{
    using Shkolo.Data.Datasets.Seeders;
    public interface ISeedDataServices
    {
        public void SeedSubjects(ShkoloDbContext db, DataSeeder seed);
        public void SeedTeachers(ShkoloDbContext db, DataSeeder seed);
        public void SeedTypeSubjects(ShkoloDbContext db, DataSeeder seed);
        public void SeedTypeGrades(ShkoloDbContext db, DataSeeder seed);
        public void SeedTypeAbsences(ShkoloDbContext db, DataSeeder seed);
        public void SeedTypeAbsenceReasons(ShkoloDbContext db, DataSeeder seed);
        public void SeedCourses(ShkoloDbContext db, DataSeeder seed);
        public void SeedDiaries(ShkoloDbContext db, DataSeeder seed);
        public void SeedStudents(ShkoloDbContext db, DataSeeder seed);
        public void SeedStudentsCourses(ShkoloDbContext db);
        public void SeedSchedules(ShkoloDbContext db, DataSeeder seed);
        public void SeedSchedulesHours(ShkoloDbContext db, DataSeederScheduleHour seedSchedule);
        public void SeedGrade(ShkoloDbContext db, DataSeederGrade seedGrade);
        public void SeederData();
    }
}
