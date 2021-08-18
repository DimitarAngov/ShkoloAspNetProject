namespace Shkolo.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.ScheduleHours;
    public class ScheduleHoursControllerTest
    {
        [Test]
        public void GetAddBecomeShouldBeMapped()
          => MyRouting
              .Configuration()
              .ShouldMap("/ScheduleHours/Add")
              .To<ScheduleHoursController>(c => c.Add(With.Any<ScheduleHourFormModel>()));

        [Test]
        public void PostAddBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/ScheduleHours/Add")
                    .WithMethod(HttpMethod.Post))
                .To<ScheduleHoursController>(c => c.Add(With.Any<ScheduleHourFormModel>()));

        [Test]
        [TestCase(1)]
        public void PostEditBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/ScheduleHours/Edit/1")
                   .WithMethod(HttpMethod.Post))
               .To<ScheduleHoursController>(c => c.Edit(id));
        [Test]
        [TestCase(1)]
        public void GetDelBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/ScheduleHours/Delete/1")
                   .WithMethod(HttpMethod.Get))
               .To<ScheduleHoursController>(c => c.Delete(id));
    }
}
