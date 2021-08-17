namespace Shkolo.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.Schedules;
    public class SchedulesControllerTest
    {
        [Test]
        public void GetAllBecomeShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Schedules/All")
               .To<SchedulesController>(c => c.All());

        [Test]
        public void GetAddBecomeShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Schedules/Add")
               .To<SchedulesController>(c => c.Add(With.Any<ScheduleFormModel>()));

        [Test]
        public void PostAddBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Schedules/Add")
                    .WithMethod(HttpMethod.Post))
                .To<SchedulesController>(c => c.Add(With.Any<ScheduleFormModel>()));

        [Test]
        [TestCase(1)]
        public void PostEditBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Schedules/Edit/1")
                   .WithMethod(HttpMethod.Post))
               .To<SchedulesController>(c => c.Edit(id));
        [Test]
        [TestCase(1)]
        public void GetDelBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Schedules/Delete/1")
                   .WithMethod(HttpMethod.Get))
               .To<SchedulesController>(c => c.Delete(id));
    }
}
