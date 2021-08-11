namespace Shkolo.Services.Grades
{
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models.Grades;
    using System.Collections.Generic;
    using System.Linq;
    public class GradesService : IGradesService
    {
        private readonly ShkoloDbContext db;
        public GradesService(ShkoloDbContext db)
        {
            this.db = db;
        }
        public void AddGrade(GradeFormModel grade)
        {
            var gradeData = new Grade
            {
                GradeId = grade.GradeId,
                Term_Number = grade.Term_Number,
                StudentCourseId = grade.StudentCourseId,
                GradeStudents = grade.GradeStudents,
                TypeGradeId = grade.TypeGradeId,
                Date = grade.Date,
                Description = grade.Description
            };

            db.Grades.Add(gradeData);
            db.SaveChanges();
        }
        public ICollection<AllGradeViewModel> GetAllGrades(
            string searchTerm,
            string studentName,
            string subjectName,
            string gradeStudent)
        {
            var gradeQuery = this.db.Grades.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                gradeQuery = gradeQuery.Where(x => x.TypeGrade.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(studentName))
            {
                gradeQuery = gradeQuery.Where(x => x.StudentCourse.Students.Name == studentName);
            }

            if (!string.IsNullOrWhiteSpace(subjectName))
            {
                gradeQuery = gradeQuery.Where(x => x.StudentCourse.Courses.Subject.Name == subjectName);
            }

            if (!string.IsNullOrWhiteSpace(gradeStudent))
            {
                gradeQuery = gradeQuery.Where(x => x.GradeStudents == gradeStudent);
            }

            var gradesOrder = gradeQuery
                .OrderBy(x => x.Term_Number)
                .ThenBy(x => x.StudentCourse.Students.NumInClass)
                .ThenBy(x => x.StudentCourse.Courses.Subject.Name);

            var gradesAllGrades = GetG(gradesOrder);
                      
            return gradesAllGrades;
        }
        public IEnumerable<StudentCourseModel> GetStudentCourses()
        => this.db
           .StudentsCourses
           .Select(x => new StudentCourseModel
           {
               StudentCourseId = x.StudentCourseId,
               StudentId = x.StudentId,
               StudentName = x.Students.Name,
               SubjectName = x.Courses.Subject.Name,
               TeacherName = x.Courses.Teacher.Name
           })
           .ToList();
        public IEnumerable<TypeGradeModel> GetTypeGrades()
        => this.db
           .TypeGrades
           .Select(x => new TypeGradeModel
           {
               TypeGradeId = x.TypeGradeId,
               Name = x.Name
           })
           .ToList();
        public IEnumerable<string> SubjectN()
            =>this.db
                .Subjects
                .Select(x => x.Name)
                .ToList();

        public IEnumerable<string> StudenttN()
            =>this.db
                .Students
                .Select(x => x.Name)
                .ToList();
        public IEnumerable<string> GradeStudents()
            =>this.db
                .Grades
                .Select(x => x.GradeStudents)
                .Distinct()
                .OrderBy(x=>x)
                .ToList();

        public void Delete(int id)
        {
            var gradeDel = this.db.Grades.FirstOrDefault(x => x.GradeId == id);
            this.db.Grades.Remove(gradeDel);
            db.SaveChanges();
        }
        public GradeFormModel FindById(int id)
                => this.db
                    .Grades
                    .Where(x => x.GradeId == id)
                    .Select(x => new GradeFormModel
                    {
                        GradeId = x.GradeId,
                        Term_Number=x.Term_Number,
                        StudentCourseId=x.StudentCourseId,
                        GradeStudents=x.GradeStudents,
                        TypeGradeId = x.TypeGradeId,
                        Date = x.Date,
                        Description = x.Description
                    })
                    .FirstOrDefault();
        public void Edit(int id, GradeFormModel grade)
        {
            var gradeData = new Grade
            {
                GradeId = id,
                Term_Number = grade.Term_Number,
                StudentCourseId = grade.StudentCourseId,
                GradeStudents = grade.GradeStudents,
                TypeGradeId = grade.TypeGradeId,
                Date = grade.Date,
                Description = grade.Description
            };

            db.Grades.Update(gradeData);
            db.SaveChanges();
        }
        public ICollection<AllGradeViewModel> GetAllGradesByStudent(string studentName)
        {
            var gradeQuery = this.db.Grades.AsQueryable();

            if (!string.IsNullOrWhiteSpace(studentName))
            {
                gradeQuery = gradeQuery.Where(x => x.StudentCourse.Students.Name == studentName);
            }

            var gradesOrder = gradeQuery
                .OrderBy(x => x.StudentCourse.Courses.Subject.Name)
                .ThenBy(x => x.Term_Number);

            var gradesAllGrades = GetG(gradesOrder);
            
            return gradesAllGrades;
        }
        public ICollection<AllGradeViewModel> GetAllGradesBySubject(string subjectName)
        {
            var gradeQuery = this.db.Grades.AsQueryable();

            if (!string.IsNullOrWhiteSpace(subjectName))
            {
                gradeQuery = gradeQuery.Where(x => x.StudentCourse.Courses.Subject.Name == subjectName);
            }
            
           var gradesOrder = gradeQuery
                .OrderBy(x => x.StudentCourse.Students.NumInClass)
                .ThenBy(x => x.Term_Number);
           
           var gradesAllGrades = GetG(gradesOrder);
          
           return gradesAllGrades;
        }
        private static ICollection<AllGradeViewModel> GetG(IQueryable<Grade> gradeQuery)
            =>gradeQuery
            .Select(x => new AllGradeViewModel
            {
                GradeId = x.GradeId,
                Term_Number = x.Term_Number,
                Date = x.Date,
                StudentName = x.StudentCourse.Students.Name,
                SubjectName = x.StudentCourse.Courses.Subject.Name,
                GradeStudent = x.GradeStudents,
                TypeGradeName = x.TypeGrade.Name,
                StudentPhoneNumber=x.StudentCourse.Students.Phone
            })
            .ToList();
    }
}
