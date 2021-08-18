using Shkolo.Data.Models;
namespace Shkolo.Test.Data
{

    using System.Collections.Generic;
    using System.Linq;
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

        public static List<Schedule> GetSchedule(int scheduleId, int term_Number, int dayOfWeek, int schoolHour, int courseId)
        =>
          Enumerable
              .Range(1, scheduleId)
              .Select(i => new Schedule
              {
                  ScheduleId = scheduleId,
                  Term_Number = term_Number,
                  DayOfWeek = dayOfWeek,
                  SchoolHour = schoolHour,
                  CourseId = courseId

              })
              .ToList();

        public static List<Student> GetStudent(int studentId, string name, string dateOfBirth, string placeOfBirth,
            string adress, string phone, int numInClass, int parentId, int doctorId, int diaryId)
       =>
         Enumerable
             .Range(1, studentId)
             .Select(i => new Student
             {
                 StudentId = studentId,
                 Name = name,
                 DateOfBirth = dateOfBirth,
                 PlaceOfBirth = placeOfBirth,
                 Address = adress,
                 Phone = phone,
                 NumInClass = numInClass,
                 ParentId = parentId,
                 DoctorId = doctorId,
                 DiaryId = diaryId,
                 PageNumCompulsoryEducationBook=""
             })
             .ToList();

        public static List<Grade> GetGrade(int gradeId, int term_Number, int studentCourseId,
            string gradeStudents, int typeGradeId, string date)
       =>
         Enumerable
             .Range(1, gradeId)
             .Select(i => new Grade
             {
                 GradeId = gradeId,
                 Term_Number = term_Number,
                 StudentCourseId = studentCourseId,
                 GradeStudents = gradeStudents,
                 TypeGradeId = typeGradeId,
                 Date = date
             })
             .ToList();

        public static List<ScheduleHour> GetScheduleHour(int scheduleHourId, string date, int scheduleId, string topics,
            int studentIdAbsences, int typeAbsenceId, int typeAbsenceReasonId)
       =>
         Enumerable
             .Range(1, scheduleHourId)
             .Select(i => new ScheduleHour
             {
                 ScheduleHourId = scheduleHourId,
                 Date = date,
                 ScheduleId = scheduleId,
                 Topics = topics,
                 StudentId = studentIdAbsences,
                 TypeAbsenceId = typeAbsenceId,
                 TypeAbsenceReasonId = typeAbsenceReasonId
             })
             .ToList();
    }
}
