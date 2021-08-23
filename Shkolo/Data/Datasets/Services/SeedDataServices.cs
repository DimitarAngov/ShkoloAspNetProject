namespace Shkolo.Data.Datasets
{
    using Shkolo.Data.Models;
    using System.Linq;
    using Shkolo.Data.Datasets.Services;
    using Shkolo.Data.Datasets.Seeders;

    public class SeedDataServices : ISeedDataServices
    {
        private readonly ShkoloDbContext db;
        private readonly DataSeeder seed;
        private readonly DataSeederScheduleHour seedSchedule;
        private readonly DataSeederGrade seedGrade;
        public SeedDataServices(ShkoloDbContext db,
                                DataSeeder seed,
                                DataSeederScheduleHour seedSchedule,
                                DataSeederGrade seedGrade)
        {
            this.db = db;
            this.seed = seed;
            this.seedSchedule = seedSchedule;
            this.seedGrade = seedGrade;
        }
        public void SeedSubjects(ShkoloDbContext db, DataSeeder seed)
        {
            if (db.Subjects.Any() == false)
            {
                for (int i = 0; i < seed.DataSubjects.Length; i++)
                {
                    db.Subjects.Add(new Subject
                    {
                        Name = seed.DataSubjects[i]
                    });
                }
            }
            db.SaveChanges();
        }
        public void SeedTeachers(ShkoloDbContext db, DataSeeder seed)
        {
            if (db.Teachers.Any() == false)
            {
                for (int i = 0; i < seed.DataTeachers.Length; i++)
                {
                    db.Teachers.Add(new Teacher
                    {
                        Name = seed.DataTeachers[i]
                    });
                }
            }
            db.SaveChanges();
        }
        public void SeedTypeSubjects(ShkoloDbContext db, DataSeeder seed)
        {
            if (db.TypeSubjects.Any() == false)
            {
                for (int i = 0; i < seed.DataTypeSubjects.Length; i++)
                {
                    db.TypeSubjects.Add(new TypeSubject
                    {
                        Name = seed.DataTypeSubjects[i]
                    });
                }
            }
            db.SaveChanges();
        }

        public void SeedTypeGrades(ShkoloDbContext db, DataSeeder seed)
        {
            if (db.TypeGrades.Any() == false)
            {
                for (int i = 0; i < seed.DataTypeGrade.Length; i++)
                {
                    db.TypeGrades.Add(new TypeGrade
                    {
                        Name = seed.DataTypeGrade[i]
                    });
                }
            }
            db.SaveChanges();
        }

        public void SeedTypeAbsences(ShkoloDbContext db, DataSeeder seed)
        {
            if (db.TypeAbsences.Any() == false)
            {
                for (int i = 0; i < seed.DataTypeAbsences.Length; i++)
                {
                    db.TypeAbsences.Add(new TypeAbsence
                    {
                        Name = seed.DataTypeAbsences[i]
                    });
                }
            }
            db.SaveChanges();
        }
        public void SeedTypeAbsenceReasons(ShkoloDbContext db, DataSeeder seed)
        {
            if (db.TypeAbsenceReasons.Any() == false)
            {
                for (int i = 0; i < seed.DataTypeAbsencesReason.Length; i++)
                {
                    db.TypeAbsenceReasons.Add(new TypeAbsenceReason
                    {
                        Name = seed.DataTypeAbsencesReason[i]
                    });
                }
            }
            db.SaveChanges();
        }
        public void SeedCourses(ShkoloDbContext db, DataSeeder seed)
        {
            if (db.Courses.Any() == false)
            {
                for (int i = 0; i < seed.DataCourses.Length - 2; i += 3)
                {
                    var courseTemp = new { s = seed.DataCourses[i], t = seed.DataCourses[i + 1], ts = seed.DataCourses[i + 2] };

                    var subjectName = db.Subjects.Select(x => x.Name).Contains(courseTemp.s);
                    var subjectNameIndex = db.Subjects.Select(x => x.Name).ToList().IndexOf(courseTemp.s);
                    var typeSubjectName = db.TypeSubjects.Select(x => x.Name).Contains(courseTemp.t);
                    var typeSubjectNameIndex = db.TypeSubjects.Select(x => x.Name).ToList().IndexOf(courseTemp.t);
                    var teachersName = db.Teachers.Select(x => x.Name).Contains(courseTemp.ts);
                    var teachersNameIndex = db.Teachers.Select(x => x.Name).ToList().IndexOf(courseTemp.ts);

                    if (subjectName && typeSubjectName && teachersName)
                    {
                        db.Courses.Add(new Course
                        {
                            SubjectId = subjectNameIndex + 1,
                            TypeSubjectId = typeSubjectNameIndex + 1,
                            TeacherId = teachersNameIndex + 1
                        });
                    }
                }
            }
            db.SaveChanges();
        }
        public void SeedDiaries(ShkoloDbContext db, DataSeeder seed)
        {
            if (db.Diaries.Any() == false)
            {
                string[] DiariesTemp = seed.DataDiary;

                for (int i = 0; i < DiariesTemp.Length - 4; i += 5)
                {
                    var teacherTemp = int.Parse(db.Teachers
                                            .Where(x => x.Name == DiariesTemp[i + 3])
                                            .Select(x => x.TeacherId)
                                            .ToList()[0].ToString());
                    db.Diaries.Add(
                        new Diary
                        {
                            SchoolName = DiariesTemp[i],
                            NumberClassName = int.Parse(DiariesTemp[i + 1]),
                            ClassName = DiariesTemp[i + 2],
                            TeacherId = teacherTemp,
                            SchoolYear = DiariesTemp[i + 4]
                        });
                }
            }
            db.SaveChanges();
        }
        public void SeedStudents(ShkoloDbContext db, DataSeeder seed)
        {
            if (db.Students.Any() == false)
            {
                string[] studentTemp = seed.DataStudents;

                for (int i = 0; i < studentTemp.Length - 17; i += 18)
                {
                    if (db.Parents.Any() == false)
                    {
                        db.Parents.Add(
                                 new Parent
                                 {
                                     Name = studentTemp[i + 9],
                                     Phone = studentTemp[i + 10],
                                     Email = studentTemp[i + 11],
                                     Address = studentTemp[i + 12],
                                 });
                    }
                    if (db.Doctors.Any() == false)
                    {
                        db.Doctors.Add(
                                 new Doctor
                                 {
                                     Name = studentTemp[i + 13],
                                     Phone = studentTemp[i + 14],
                                 });
                    }
                }

                for (int i = 0; i < studentTemp.Length - 17; i += 18)
                {
                    var parentName = db.Parents.Select(x => x.Name).Contains(studentTemp[i + 9]);
                    var doctorName = db.Doctors.Select(x => x.Name).Contains(studentTemp[i + 13]);
                    var parentNameIndex = db.Parents.Select(x => x.Name).ToList().IndexOf(studentTemp[i + 9]);
                    var doctorNameIndex = db.Doctors.Select(x => x.Name).ToList().IndexOf(studentTemp[i + 13]);

                    if (parentName && doctorName)
                    {
                        db.Students.Add(
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
                                DiaryId = db.Diaries.Select(x => x.DiaryId).ToList().Count
                            });
                    }
                }
            }

            db.SaveChanges();
        }
        public void SeedStudentsCourses(ShkoloDbContext db)
        {
            if (db.StudentsCourses.Any() == false)
            {
                for (int i = 1; i <= db.Students.Count(); i++)
                {
                    for (int i1 = 1; i1 <= db.Courses.Count(); i1++)
                    {
                        db.StudentsCourses.Add(
                                new StudentCourse
                                {
                                    StudentId = i,
                                    CourseId = i1
                                });
                    }
                }
            }
            db.SaveChanges();
        }
        public void SeedSchedules(ShkoloDbContext db, DataSeeder seed)
        {
            if (db.Schedules.Any() == false)
            {
                string[] scheduleTemp = seed.DataSchedules;

                for (int i = 0; i < scheduleTemp.Length; i += 7)
                {
                    var courseTemp = new { s = scheduleTemp[i + 4], t = scheduleTemp[i + 5], ts = scheduleTemp[i + 6] };

                    var subjectNameIndex = db.Subjects.Select(x => x.Name).ToList().IndexOf(courseTemp.s) + 1;
                    var typeSubjectNameIndex = db.TypeSubjects.Select(x => x.Name).ToList().IndexOf(courseTemp.t) + 1;
                    var teachersNameIndex = db.Teachers.Select(x => x.Name).ToList().IndexOf(courseTemp.ts) + 1;

                    var tempCourseId = int.Parse(db.Courses
                        .Where(x =>
                                    x.SubjectId == subjectNameIndex &&
                                    x.TypeSubjectId == typeSubjectNameIndex &&
                                    x.TeacherId == teachersNameIndex)
                        .Select(x => x.CourseId)
                        .FirstOrDefault()
                        .ToString()
                        );

                    db.Schedules.Add(
                          new Schedule
                          {
                              Term_Number = i < scheduleTemp.Length / 2 ? 1 : 2,
                              DayOfWeek = int.Parse(scheduleTemp[i].ToString()),
                              SchoolHour = int.Parse(seed.DataSchedules[i + 1].ToString()),
                              CourseId = tempCourseId
                          });
                }
            }
            db.SaveChanges();
        }
        public void SeedSchedulesHours(ShkoloDbContext db, DataSeederScheduleHour seedSchedule)
        {
            if (db.ScheduleHours.Any() == false)
            {
                string[] scheduleTemp = seedSchedule.DataScheduleHours;

                for (int i = 0; i < scheduleTemp.Length; i += 15)
                {
                    var scheduleHour = new
                    {
                        dw = int.Parse(scheduleTemp[i + 1]),
                        h = int.Parse(scheduleTemp[i + 2]),
                        s = scheduleTemp[i + 5],
                        t = scheduleTemp[i + 6],
                        ts = scheduleTemp[i + 7]
                    };

                    var subjectNameIndex = db.Subjects.Select(x => x.Name).ToList().IndexOf(scheduleHour.s) + 1;
                    var typeSubjectNameIndex = db.TypeSubjects.Select(x => x.Name).ToList().IndexOf(scheduleHour.t) + 1;
                    var teachersNameIndex = db.Teachers.Select(x => x.Name).ToList().IndexOf(scheduleHour.ts) + 1;

                    var tempCourseId = int.Parse(db.Courses
                        .Where(x =>
                                    x.SubjectId == subjectNameIndex &&
                                    x.TypeSubjectId == typeSubjectNameIndex &&
                                    x.TeacherId == teachersNameIndex)
                        .Select(x => x.CourseId)
                        .FirstOrDefault()
                        .ToString()
                        );

                    var tempI = i < 10250 ? 1 : 2;
                    var tempScheduleId = int.Parse(db.Schedules
                        .Where(x =>
                                x.DayOfWeek == scheduleHour.dw &&
                                x.SchoolHour == scheduleHour.h &&
                                x.CourseId == tempCourseId &&
                                x.Term_Number == tempI)
                        .Select(x => x.ScheduleId)
                        .FirstOrDefault()
                        .ToString()
                        );

                    var typeAbsenceId = 4;
                    var typeAbsenceReasonId = 4;
                    var studentId = 21;

                    if (scheduleTemp[i + 9] != "")
                    {
                        studentId = int.Parse(db.Students
                            .Where(x => x.NumInClass == int.Parse(scheduleTemp[i + 9]))
                            .Select(x => x.StudentId)
                            .FirstOrDefault().ToString()
                            );
                    }
                    if (scheduleTemp[i + 10] != "")
                    {
                        typeAbsenceId = int.Parse(db.TypeAbsences
                        .Where(x => x.Name == scheduleTemp[i + 10])
                        .Select(x => x.TypeAbsenceId)
                        .FirstOrDefault().ToString()
                        );
                    }
                    if (scheduleTemp[i + 11] != "")
                    {
                        typeAbsenceReasonId = int.Parse(db.TypeAbsenceReasons
                        .Where(x => x.Name == scheduleTemp[i + 11])
                        .Select(x => x.TypeAbsenceReasonId)
                        .FirstOrDefault()
                        .ToString()
                        );
                    }

                    db.ScheduleHours.Add(

                          new ScheduleHour
                          {
                              Date = scheduleTemp[i],
                              ScheduleId = tempScheduleId,
                              Topics = scheduleTemp[i + 8],
                              StudentId = studentId,
                              TypeAbsenceId = typeAbsenceId,
                              TypeAbsenceReasonId = typeAbsenceReasonId
                          });
                }
            }
            db.SaveChanges();
        }
        public void SeedGrade(ShkoloDbContext db, DataSeederGrade seedGrade)
        {
            if (db.Grades.Any() == false)
            {
                string[] gradeTemp = seedGrade.DataGrades;
                var tempStudentCourseId = 0;
                var courseId = 1;
                for (int i = 0; i < gradeTemp.Length; i += 6)
                {
                    if (gradeTemp[i] == "")
                    {
                        var courseTemp = new
                        {
                            s = gradeTemp[i + 2],
                            t = gradeTemp[i + 3],
                            ts = gradeTemp[i + 4]
                        };

                        var subjectNameIndex = db.Subjects.Select(x => x.Name).ToList().IndexOf(courseTemp.s) + 1;
                        var typeSubjectNameIndex = db.TypeSubjects.Select(x => x.Name).ToList().IndexOf(courseTemp.t) + 1;
                        var teachersNameIndex = db.Teachers.Select(x => x.Name).ToList().IndexOf(courseTemp.ts) + 1;

                        courseId = int.Parse(db.Courses
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
                        var studentId = int.Parse(db.Students
                            .Where(x => x.NumInClass == int.Parse(gradeTemp[i + 1]))
                            .Select(x => x.StudentId)
                            .ToList()[0].ToString()
                            );

                        tempStudentCourseId = int.Parse(db.StudentsCourses
                            .Where(x =>
                                        x.StudentId == studentId &&
                                        x.CourseId == courseId)
                            .Select(x => x.StudentCourseId)
                            .FirstOrDefault().ToString()
                            );

                        var tempTypeGradeId = int.Parse(db.TypeGrades
                              .Where(x => x.Name == gradeTemp[i + 3])
                              .Select(x => x.TypeGradeId)
                              .FirstOrDefault().ToString()
                              );

                        db.Grades.Add(
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
            db.SaveChanges();
        }
        public void SeederData()
        {
            SeedTypeSubjects(db,seed);
            SeedSubjects(db,seed);
            SeedTeachers(db,seed);
            SeedCourses(db,seed);
            SeedDiaries(db,seed);
            SeedStudents(db,seed);
            SeedStudentsCourses(db);
            SeedSchedules(db,seed);
            SeedTypeAbsences(db,seed);
            SeedTypeAbsenceReasons(db,seed);
            SeedSchedulesHours(db,seedSchedule);
            SeedTypeGrades(db,seed);
            SeedGrade(db, seedGrade);
        }
    }        
}
