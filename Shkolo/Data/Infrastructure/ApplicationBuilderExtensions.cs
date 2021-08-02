namespace Shkolo.Data.Infrastructure
{
    using Shkolo.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Shkolo.Data.Models;
    using System.Reflection;
    using Shkolo.Data.Seeders;
    using System;

    using Shkolo.Data.Datasets;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDataBase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var data = scopedServices.ServiceProvider.GetService<ShkoloDbContext>();

            DataSeeder seed = new DataSeeder();
            DataSeederScheduleHour seedSchedule = new DataSeederScheduleHour();
            DataSeederGrade seedGrade = new DataSeederGrade();
            
            data.Database.Migrate();

            SeedTypeSubjects(data, seed);
            //SeedSubjects.DataSeedSubjects(data, seed);
            SeedSubjects(data, seed);
            SeedTeachers(data, seed);
            
            SeedCourses(data, seed);
            SeedDiaries(data,seed);
            SeedStudents(data, seed);
            SeedStudentsCourses(data);
            SeedSchedules(data, seed);
            SeedTypeAbsences(data, seed);
            SeedTypeAbsenceReasons(data,seed);
            SeedSchedulesHours(data, seedSchedule);
            SeedTypeGrades(data, seed);
            SeedGrade(data, seedGrade);
           
            //data.Database.EnsureDeleted();
            //data.Database.EnsureCreated();
         
            return app;
        }


        private static void SeedSubjects(ShkoloDbContext data, DataSeeder seed)
        {

            if (data.Subjects.Any() == false)
            {
                for (int i = 0; i < seed.DataSubjects.Length; i++)
                {
                    data.Subjects.Add(new Subject
                    {
                        Name = seed.DataSubjects[i]
                    });
                }

            }
            data.SaveChanges();
        }
        public static void SeedTeachers(ShkoloDbContext data, DataSeeder seed)
        {

            if (data.Teachers.Any() == false)
            {

                for (int i = 0; i < seed.DataTeachers.Length; i++)
                {
                    data.Teachers.Add(new Teacher
                    {
                        Name = seed.DataTeachers[i]
                    });
                }
            }
            data.SaveChanges();
        }

        private static void SeedTypeSubjects(ShkoloDbContext data, DataSeeder seed)
        {
            
            if (data.TypeSubjects.Any() == false)
            {
                for (int i = 0; i < seed.DataTypeSubjects.Length; i++)
                {
                    data.TypeSubjects.Add(new TypeSubject
                    {
                        Name = seed.DataTypeSubjects[i]
                    });
                }
            }
            data.SaveChanges();
        }

        private static void SeedTypeGrades(ShkoloDbContext data, DataSeeder seed)
        {
            if (data.TypeGrades.Any() == false)
            {
                for (int i = 0; i < seed.DataTypeGrade.Length; i++)
                {
                    data.TypeGrades.Add(new TypeGrade
                    {
                        Name = seed.DataTypeGrade[i]
                    });
                }

            }
            data.SaveChanges();
        }

        private static void SeedTypeAbsences(ShkoloDbContext data, DataSeeder seed)
        {

            if (data.TypeAbsences.Any() == false)
            {
                for (int i = 0; i < seed.DataTypeAbsences.Length; i++)
                {
                    data.TypeAbsences.Add(new TypeAbsence
                    {
                        Name = seed.DataTypeAbsences[i]
                    });
                }
            }
            data.SaveChanges();
        }

        private static void SeedTypeAbsenceReasons(ShkoloDbContext data, DataSeeder seed)
        {

            if (data.TypeAbsenceReasons.Any() == false)
            {
                for (int i = 0; i < seed.DataTypeAbsencesReason.Length; i++)
                {
                    data.TypeAbsenceReasons.Add(new TypeAbsenceReason
                    {
                        Name = seed.DataTypeAbsencesReason[i]
                    });
                }
            }
            data.SaveChanges();
        }

        private static void SeedCourses(ShkoloDbContext data, DataSeeder seed)
        {

            if (data.Courses.Any() == false)
            {
                for (int i = 0; i < seed.DataCourses.Length - 2; i += 3)
                {
                    var courseTemp = new { s = seed.DataCourses[i], t = seed.DataCourses[i + 1], ts = seed.DataCourses[i + 2] };

                    var subjectName = data.Subjects.Select(x => x.Name).Contains(courseTemp.s);
                    var subjectNameIndex = data.Subjects.Select(x => x.Name).ToList().IndexOf(courseTemp.s);
                    var typeSubjectName = data.TypeSubjects.Select(x => x.Name).Contains(courseTemp.t);
                    var typeSubjectNameIndex = data.TypeSubjects.Select(x => x.Name).ToList().IndexOf(courseTemp.t);
                    var teachersName = data.Teachers.Select(x => x.Name).Contains(courseTemp.ts);
                    var teachersNameIndex = data.Teachers.Select(x => x.Name).ToList().IndexOf(courseTemp.ts);

                    if (subjectName && typeSubjectName && teachersName)
                    {
                        data.Courses.Add(new Course
                        {
                            SubjectId = subjectNameIndex + 1,
                            TypeSubjectId = typeSubjectNameIndex + 1,
                            TeacherId = teachersNameIndex + 1
                        });

                    }
                }
            }
            data.SaveChanges();
        }

        private static void SeedDiaries(ShkoloDbContext data, DataSeeder seed)
        {
            if (data.Diaries.Any() == false)
            {
                string[] DiariesTemp = seed.DataDiary;
                
                for (int i = 0; i < DiariesTemp.Length - 4; i += 5)
                {
                    var teacherTemp = int.Parse(data.Teachers
                                            .Where(x => x.Name == DiariesTemp[i+3])
                                            .Select(x => x.TeacherId)
                                            .ToList()[0].ToString());
                    data.Diaries.Add(
                        new Diary
                        {
                            SchoolName = DiariesTemp[i],
                            NumberClassName= int.Parse(DiariesTemp[i + 1]),
                            ClassName = DiariesTemp[i+2],
                            TeacherId= teacherTemp,
                            SchoolYear= DiariesTemp[i + 4]
                        }); 
                }
            }
            data.SaveChanges();
        }
            private static void SeedStudents(ShkoloDbContext data, DataSeeder seed)
        {

            if (data.Students.Any() == false)
            {
                string[] studentTemp = seed.DataStudents;

                for (int i = 0; i < studentTemp.Length - 17; i += 18)
                {

                    data.Parents.Add(

                                 new Parent
                                 {
                                     Name = studentTemp[i + 9],
                                     Phone = studentTemp[i + 10],
                                     Email = studentTemp[i + 11],
                                     Address = studentTemp[i + 12],
                                 });
                    data.Doctors.Add(

                                 new Doctor
                                 {
                                     Name = studentTemp[i + 13],
                                     Phone = studentTemp[i + 14],
                                 });
                }
                
               
                for (int i = 0; i < studentTemp.Length - 17; i += 18)
                {
                    var parentName = data.Parents.Select(x => x.Name).Contains(studentTemp[i + 9]);
                    var doctorName = data.Doctors.Select(x => x.Name).Contains(studentTemp[i + 13]);
                    var parentNameIndex = data.Parents.Select(x => x.Name).ToList().IndexOf(studentTemp[i + 9]);
                    var doctorNameIndex = data.Doctors.Select(x => x.Name).ToList().IndexOf(studentTemp[i + 13]);

                   
                    if (parentName && doctorName)
                    {
                        data.Students.Add(

                            new Student
                            {
                                Name = studentTemp[i],
                                DateOfBirth = studentTemp[i + 1],
                                PlaceOfBirth = studentTemp[i + 2],
                                Address = studentTemp[i + 3],
                                Phone = studentTemp[i + 4],
                                NumInClass = int.Parse(studentTemp[i + 5].ToString()),
                                ParentId = parentNameIndex + 1,
                                DoctorId = doctorNameIndex + 1,
                                PageNumCompulsoryEducationBook = studentTemp[i + 15],
                                OrderToLeave = studentTemp[i + 16],
                                OrderToEnroll = studentTemp[i + 17],
                                DiaryId =data.Diaries.Select(x=>x.DiaryId).ToList().Count()
                            }) ;
                    }
                }
            }


            data.SaveChanges();
        }

        private static void SeedStudentsCourses(ShkoloDbContext data)
        {
            if (data.StudentsCourses.Any() == false)
            {
                for (int i = 1; i <= data.Students.Count(); i++)
                {
                    for (int i1 = 1; i1 <= data.Courses.Count(); i1++)
                    {
                        data.StudentsCourses.Add(

                                new StudentCourse
                                {
                                    StudentId = i,
                                    CourseId = i1
                                });
                    }
                }
            }
            data.SaveChanges();
        }
            private static void SeedSchedules(ShkoloDbContext data, DataSeeder seed)
        {
            
            if (data.Schedules.Any() == false)
            {
                string[] scheduleTemp = seed.DataSchedules;

                for (int i = 0; i <scheduleTemp.Count(); i += 7)
                {
                    var courseTemp = new { s = scheduleTemp[i + 4], t = scheduleTemp[i + 5], ts = scheduleTemp[i + 6] };

                    var subjectNameIndex = data.Subjects.Select(x => x.Name).ToList().IndexOf(courseTemp.s) + 1;
                    var typeSubjectNameIndex = data.TypeSubjects.Select(x => x.Name).ToList().IndexOf(courseTemp.t) + 1;
                    var teachersNameIndex = data.Teachers.Select(x => x.Name).ToList().IndexOf(courseTemp.ts) + 1;

                    var tempCourseId = int.Parse(data.Courses
                        .Where(x =>
                                    x.SubjectId == subjectNameIndex &&
                                    x.TypeSubjectId == typeSubjectNameIndex &&
                                    x.TeacherId == teachersNameIndex)
                        .Select(x => x.CourseId)
                        .FirstOrDefault()
                        .ToString()
                        );


                    data.Schedules.Add(

                          new Schedule
                          {
                              Term_Number = i < scheduleTemp.Length / 2 ? 1 : 2,
                              DayOfWeek = int.Parse(scheduleTemp[i].ToString()),
                              SchoolHour = int.Parse(seed.DataSchedules[i + 1].ToString()),
                              CourseId = tempCourseId
                          });

                }

            }
            data.SaveChanges();
        }

        private static void SeedSchedulesHours(ShkoloDbContext data, DataSeederScheduleHour seedSchedule)
        {

            if(data.ScheduleHours.Any() == false)
            {
                string[] scheduleTemp = seedSchedule.DataScheduleHours;

                for (int i =0 ; i < scheduleTemp.Length; i += 15)
                {
                    var scheduleHour = new
                    {
                        dw = int.Parse(scheduleTemp[i + 1]),
                        h = int.Parse(scheduleTemp[i + 2]),
                        s = scheduleTemp[i + 5],
                        t = scheduleTemp[i + 6],
                        ts = scheduleTemp[i + 7]
                    };


                    var subjectNameIndex = data.Subjects.Select(x => x.Name).ToList().IndexOf(scheduleHour.s) + 1;
                    var typeSubjectNameIndex = data.TypeSubjects.Select(x => x.Name).ToList().IndexOf(scheduleHour.t) + 1;
                    var teachersNameIndex = data.Teachers.Select(x => x.Name).ToList().IndexOf(scheduleHour.ts) + 1;

                                       
                    var tempCourseId = int.Parse(data.Courses
                        .Where(x =>
                                    x.SubjectId == subjectNameIndex &&
                                    x.TypeSubjectId == typeSubjectNameIndex &&
                                    x.TeacherId == teachersNameIndex)
                        .Select(x => x.CourseId)
                        .FirstOrDefault()
                        .ToString()
                        );

                    var tempI = i < 10250 ? 1 : 2;
                    var tempScheduleId = int.Parse(data.Schedules
                        .Where(x =>
                                x.DayOfWeek == scheduleHour.dw &&
                                x.SchoolHour == scheduleHour.h &&
                                x.CourseId == tempCourseId &&
                                x.Term_Number == tempI)
                        .Select(x => x.ScheduleId)
                        .FirstOrDefault()
                        .ToString()
                        );

                    var typeAbsenceId=4;
                    var typeAbsenceReasonId = 4;
                    var studentId = 21;

                    if (scheduleTemp[i + 9] != "")
                    {
                        studentId = int.Parse(data.Students
                            .Where(x => x.NumInClass == int.Parse(scheduleTemp[i + 9]))
                            .Select(x => x.StudentId)
                            .FirstOrDefault().ToString()
                            );
                    }
                    if (scheduleTemp[i+10]!="")
                    {
                        typeAbsenceId = int.Parse(data.TypeAbsences
                        .Where(x => x.Name == scheduleTemp[i + 10])
                        .Select(x => x.TypeAbsenceId)
                        .FirstOrDefault().ToString()
                        );
                    }
                    if (scheduleTemp[i + 11] != "")
                    {
                        typeAbsenceReasonId = int.Parse(data.TypeAbsenceReasons
                        .Where(x =>x.Name == scheduleTemp[i + 11])
                        .Select(x => x.TypeAbsenceReasonId)
                        .FirstOrDefault()
                        .ToString()
                        );
                    }
                    
                    data.ScheduleHours.Add(

                          new ScheduleHour
                          {
                              Date = scheduleTemp[i],
                              ScheduleId = tempScheduleId,
                              Topics = scheduleTemp[i + 8],
                              StudentId=studentId,
                              TypeAbsenceId=typeAbsenceId,
                              TypeAbsenceReasonId= typeAbsenceReasonId

                          });

                }

            }
            data.SaveChanges();
        }

        private static void SeedGrade(ShkoloDbContext data, DataSeederGrade seedGrade)
        {

            if (data.Grades.Any() == false)
            {
                string[] gradeTemp = seedGrade.DataGrades;
                var tempStudentCourseId= 0;
                var courseId = 1;
                for (int i =0 ; i < gradeTemp.Length; i += 6)
                {

                    if (gradeTemp[i] == "")
                    {
                        var courseTemp = new
                        {
                            s = gradeTemp[i + 2],
                            t = gradeTemp[i + 3],
                            ts = gradeTemp[i + 4]
                        };


                        var subjectNameIndex = data.Subjects.Select(x => x.Name).ToList().IndexOf(courseTemp.s) + 1;
                        var typeSubjectNameIndex = data.TypeSubjects.Select(x => x.Name).ToList().IndexOf(courseTemp.t) + 1;
                        var teachersNameIndex = data.Teachers.Select(x => x.Name).ToList().IndexOf(courseTemp.ts) + 1;

                        courseId = int.Parse(data.Courses
                            .Where(x =>
                                        x.SubjectId == subjectNameIndex &&
                                        x.TypeSubjectId == typeSubjectNameIndex &&
                                        x.TeacherId == teachersNameIndex)
                            .Select(x => x.CourseId)
                            .FirstOrDefault().ToString()
                            );
                    }
                    else
                    {
                        var studentId = int.Parse(data.Students
                            .Where(x => x.NumInClass == int.Parse(gradeTemp[i + 1]))
                            .Select(x => x.StudentId)
                            .ToList()[0].ToString()
                            );

                        tempStudentCourseId = int.Parse(data.StudentsCourses
                            .Where(x =>
                                        x.StudentId == studentId &&
                                        x.CourseId == courseId)
                            .Select(x => x.StudentCourseId)
                            .FirstOrDefault().ToString()
                            );




                       
                        var tempTypeGradeId = int.Parse(data.TypeGrades
                              .Where(x => x.Name == gradeTemp[i + 3])
                              .Select(x => x.TypeGradeId)
                              .FirstOrDefault().ToString()
                              );


                        data.Grades.Add(

                        new Grade
                        {
                            Term_Number = int.Parse(gradeTemp[i]),
                            GradeStudents = gradeTemp[i + 2],
                            Date = gradeTemp[i + 4],
                            StudentCourseId = tempStudentCourseId,
                            TypeGradeId = tempTypeGradeId
                        });
                    }
                     
                }

            }
         data.SaveChanges();
        }
    }
}
