namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.ScheduleHours;
    using Shkolo.Test.Data;
    public class ScheduleHoursControllerTest
    {
        /*[Test]
        [TestCase(3, "16.09.2020", 66, "Триъгълник и трапец", 21, 4, 4)]
        public void AllShouldReturnCorrect(int id, string date, int scheduleId, string topics,
                                           int studentIdAbsences, int typeAbsenceId, int typeAbsenceReasonId)
          => MyController<ScheduleHoursController>
               .Instance()
                 .WithData(TestData.GetScheduleHour(id,date,scheduleId,topics,
                                             studentIdAbsences, typeAbsenceId,typeAbsenceReasonId))
                 .Calling(c => c.All("", "", "", "",""))
                 .ShouldReturn()
                 .View(view => view
                 .WithModelOfType<ScheduleHourSearchViewModel>());


        [Test]
        [TestCase(3, "16.09.2020", 66, "Триъгълник и трапец", 21, 4, 4)]
        public void DeleteShouldHaveRestrictionsForAuthorizedUsers(int id, string date, int scheduleId, string topics,
                                                                 int studentIdAbsences, int typeAbsenceId, int typeAbsenceReasonId)
           => MyController<ScheduleHoursController>
               .Instance()
               .WithData(TestData.GetScheduleHour(id, date, scheduleId, topics,
                                             studentIdAbsences, typeAbsenceId, typeAbsenceReasonId))
               .WithUser()
               .Calling(c => c.Delete(id))
               .ShouldReturn()
               .Redirect(redirect => redirect
               .To<ScheduleHoursController>(c => c.All("", "", "", "", "")));
*/

        [Test]
        [TestCase(3, "16.09.2020", 66, "Триъгълник и трапец", 21, 4, 4)]
        public void AddShouldReturnCreatedResultWhenValidModelState(int id, string date, int scheduleId, string topics,
            int studentIdAbsences, int typeAbsenceId, int typeAbsenceReasonId)
           => MyController<ScheduleHoursController>
               .Instance()
               .WithUser()
               .Calling(c => c.Add(new ScheduleHourFormModel
               {
                   ScheduleHourId = id,
                   Date = date,
                   ScheduleId = scheduleId,
                   Topics = topics,
                   StudentId = studentIdAbsences,
                   TypeAbsenceId = typeAbsenceId,
                   TypeAbsenceReasonId = typeAbsenceReasonId
               }))
               .ShouldHave()
               .ValidModelState()
               .AndAlso()
               .ShouldReturn()
               .Redirect(redirect => redirect
               .To<HomeController>(c => c.Index()));
    }
}
