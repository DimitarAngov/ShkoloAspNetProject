using Shkolo.Data;
using Shkolo.Data.Models;
using Shkolo.Models.ScheduleHours;
using Shkolo.Models.Schedules;
using Shkolo.Models.Students;
using System.Collections.Generic;
using System.Linq;

namespace Shkolo.Services.ScheduleHours
{
    public class ScheduleHoursService : IScheduleHoursService
    {
        private readonly ShkoloDbContext db;
        public ScheduleHoursService(ShkoloDbContext db)
        {
            this.db = db;
        }
        public void AddScheduleHour(ScheduleHourFormModel scheduleHour)
        {
            var scheduleHourData = new ScheduleHour
            {
                Date = scheduleHour.Date,
                ScheduleId = scheduleHour.ScheduleId,
                Topics = scheduleHour.Topics,
                StudentId = scheduleHour.StudentId,
                TypeAbsenceId = scheduleHour.TypeAbsenceId,
                TypeAbsenceReasonId = scheduleHour.TypeAbsenceReasonId
            };

            db.ScheduleHours.Add(scheduleHourData);
            db.SaveChanges();
        }
        public ICollection<AllScheduleHourViewModel> GetAllScheduleHours(
                                 string teacherName,
                                 string subjectName,
                                 string searchTermOne,
                                 string searchTermTwo,
                                 string searchTermThree)
        {
            var sheduleHourQuery = this.db.ScheduleHours.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTermOne))
            {
                sheduleHourQuery = sheduleHourQuery.Where(x => x.Schedule.DayOfWeek.ToString().Contains(searchTermOne.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchTermTwo))
            {
                sheduleHourQuery = sheduleHourQuery.Where(x => x.Schedule.SchoolHour.ToString().Contains(searchTermTwo.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchTermThree))
            {
                sheduleHourQuery = sheduleHourQuery.Where(x => x.Topics.ToLower().Contains(searchTermThree.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(subjectName))
            {
                sheduleHourQuery = sheduleHourQuery.Where(x => x.Schedule.Course.Subject.Name == subjectName);
            }

            if (!string.IsNullOrWhiteSpace(teacherName))
            {
                sheduleHourQuery = sheduleHourQuery.Where(x => x.Schedule.Course.Teacher.Name == teacherName);
            }

            var scheduleHour = sheduleHourQuery
                .OrderBy(x => x.Schedule.Term_Number)
                .Select(x => new AllScheduleHourViewModel
                {
                    ScheduleHourId=x.ScheduleHourId,
                    Term_Number = x.Schedule.Term_Number,
                    Date = x.Date,
                    DayOfWeek = x.Schedule.DayOfWeek,
                    SchoolHour = x.Schedule.SchoolHour,
                    ScheduleSubjectName = x.Schedule.Course.Subject.Name,
                    ScheduleTeacherName = x.Schedule.Course.Teacher.Name,
                    Topics = x.Topics,
                    AbsenceStudentNimberInClass = x.Student.NumInClass
                }).ToList();
            
            return scheduleHour;
        }
        public IEnumerable<AllScheduleViewModel> GetSchedule()
        => this.db
           .Schedules
           .Select(x => new AllScheduleViewModel
           {
               ScheduleId = x.ScheduleId,
               SubjectName = x.Course.Subject.Name,
               TeacherName = x.Course.Teacher.Name,
               Term_Number = x.Term_Number,
               DayOfWeek = x.DayOfWeek,
               SchoolHour = x.SchoolHour
           })
           .ToList();

        public void Delete(int id)
        {
            var scheduleHourDel = this.db.ScheduleHours.FirstOrDefault(x => x.ScheduleHourId == id);
            this.db.ScheduleHours.Remove(scheduleHourDel);
            db.SaveChanges();
        }
        public IEnumerable<StudentFormModel> GetScheduleStudents()
        => this.db
           .Students
           .Select(x => new StudentFormModel
           {
               StudentId = x.StudentId,
               NumInClass = x.NumInClass,
               Name = x.Name
           })
           .ToList();
        public IEnumerable<ScheduleHourTypeAbsenceReason> GetScheduleTypeAbsenceReasons()
         => this.db
           .TypeAbsenceReasons
           .Select(x => new ScheduleHourTypeAbsenceReason
           {
               TypeAbsenceReasonId = x.TypeAbsenceReasonId,
               Name = x.Name
           })
           .ToList();
        public IEnumerable<ScheduleHourTypeAbsence> GetScheduleTypeAbsences()
        => this.db
           .TypeAbsences
           .Select(x => new ScheduleHourTypeAbsence
           {
               TypeAbsenceId = x.TypeAbsenceId,
               Name = x.Name
           })
           .ToList();
        public IEnumerable<string> TeacherN()
          => this.db
                .Teachers
                .Select(x => x.Name)
                .ToList();

        public ScheduleHourFormModel FindById(int id)
                => this.db
                    .ScheduleHours
                    .Where(x => x.ScheduleHourId == id)
                    .Select(x => new ScheduleHourFormModel
                    {
                        ScheduleHourId = x.ScheduleHourId,
                        Date = x.Date,
                        ScheduleId=x.ScheduleId,
                        Topics=x.Topics,
                        StudentId=x.StudentId,
                        TypeAbsenceId=x.TypeAbsenceId,
                        TypeAbsenceReasonId=x.TypeAbsenceReasonId
                        
                    })
                    .FirstOrDefault();

        public void Edit(int id, ScheduleHourFormModel scheduleHour)
        {
            var scheduleHourData = new ScheduleHour
            {
                ScheduleHourId = id,
                Date = scheduleHour.Date,
                ScheduleId = scheduleHour.ScheduleId,
                Topics = scheduleHour.Topics,
                StudentId = scheduleHour.StudentId,
                TypeAbsenceId = scheduleHour.TypeAbsenceId,
                TypeAbsenceReasonId = scheduleHour.TypeAbsenceReasonId
            };

            db.ScheduleHours.Update(scheduleHourData);
            db.SaveChanges();
        }
    }
}
