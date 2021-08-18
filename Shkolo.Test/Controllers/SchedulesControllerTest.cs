namespace Shkolo.Test.Controllers
{

    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Data.Models;
    using Shkolo.Models.Schedules;
    using Shkolo.Test.Data;
    using System.Collections.Generic;
    using System.Linq;
    public class SchedulesControllerTest
    {
        [Test]
        public void AllShouldReturnCorrect()
          => MyMvc
          .Pipeline()
          .ShouldMap("/Schedules/All")
          .To<SchedulesController>(c => c.All())
          .Which(controller => controller
                  .WithData(Enumerable.Range(1, 10).Select(i => new Schedule())))
                  .ShouldReturn()
                  .View(view => view
                  .WithModelOfType<IEnumerable<AllScheduleViewModel>>());

        [Test]
        [TestCase(1, 1, 4, 4, 8)]
        public void AddShouldReturnCreatedResultWhenValidModelState(int id, int term_Number, int dayOfWeek, int schoolHour, int courseId)
           => MyController<SchedulesController>
               .Instance(instance => instance
               .WithUser())
               .Calling(c => c.Add(new ScheduleFormModel
               {
                   ScheduleId = id,
                   Term_Number = term_Number,
                   DayOfWeek = dayOfWeek,
                   SchoolHour = schoolHour,
                   CourseId = courseId
               }))
               .ShouldHave()
               .ValidModelState()
               .AndAlso()
               .ShouldReturn()
               .Redirect(redirect => redirect
               .To<HomeController>(c => c.Index()));

        [Test]
        [TestCase(1, 1, 4, 4, 8)]
        public void DeleteShouldHaveRestrictionsForAuthorizedUsers(int id, int term_Number, int dayOfWeek, int schoolHour, int courseId)
           => MyController<SchedulesController>
               .Instance()
               .WithUser()
               .WithData(TestData.GetSchedule(id,term_Number, dayOfWeek, schoolHour, courseId))
               .Calling(c => c.Delete(id))
               .ShouldReturn()
               .Redirect(redirect => redirect
               .To<SchedulesController>(c => c.All()));
    }
}
