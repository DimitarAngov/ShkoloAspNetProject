using Shkolo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkolo.Test.Data
{
   public class TestData
    {
        public static List<Teacher> GetTeacher(int TeacherId,string Name)
           => Enumerable
               .Range(1, TeacherId)
               .Select(i => new Teacher
               {
                   TeacherId = i,
                   Name = $"TeacherName {i}",
               })
               .ToList();
        public static List<Subject> GetSubject(int SubjectId, string Name)
          => Enumerable
              .Range(1, SubjectId)
              .Select(i => new Subject
              {
                  SubjectId = i,
                  Name = $"SubjectName {i}",
              })
              .ToList();
        public static List<Course> GetCourse(int courseId, int subjectId, int typeSubjectId, int teacherId)
        =>
          Enumerable
              .Range(1, courseId)
              .Select(i => new Course
              {
                  CourseId = i,
                  SubjectId = subjectId,
                  TypeSubjectId= typeSubjectId,
                  TeacherId= teacherId

              })
              .ToList();
        
    }
}
