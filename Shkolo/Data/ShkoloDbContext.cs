namespace Shkolo.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Shkolo.Data.Models;

    public class ShkoloDbContext : IdentityDbContext
    {
        public ShkoloDbContext(DbContextOptions<ShkoloDbContext> options)
            : base(options)
        {
            
        }
               
        public DbSet<Course> Courses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ScheduleHour> ScheduleHours { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TypeAbsence> TypeAbsences { get; set; }
        public DbSet<TypeAbsenceReason> TypeAbsenceReasons { get; set; }
        public DbSet<TypeSubject> TypeSubjects { get; set; }
        public DbSet<TypeGrade> TypeGrades { get; set; }


        /*protected override void OnModelCreating(ModelBuilder model)
        {
           
            model.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(x => new { x.CourseId, x.StudentId });
                entity
                .HasOne(x => x.Students)
                .WithMany(x => x.StudentsCourses)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
                
            });
                
        }*/

    }

    
}
