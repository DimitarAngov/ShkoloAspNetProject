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
        public void AddScheduleHour(AddScheduleHourFormModel scheduleHour)
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

        public IEnumerable<AddStudentFormModel> GetScheduleStudents()
        => this.db
           .Students
           .Select(x => new AddStudentFormModel
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
    }
}
