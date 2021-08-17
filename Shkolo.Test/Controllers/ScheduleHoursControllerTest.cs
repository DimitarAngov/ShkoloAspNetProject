namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Data.Models;
    using Shkolo.Models.ScheduleHours;
    using System.Collections.Generic;
    using System.Linq;
    public class ScheduleHoursControllerTest
    {
        [Test]
        [TestCase("Елза Василева Булакиева", "Информационни технологии", "", "", "")]
        public void AllShouldReturnCorrect(string teacherName,
                                 string subjectName,
                                 string searchTermOne,
                                 string searchTermTwo,
                                 string searchTermThree)
        => MyMvc
        .Pipeline()
        .ShouldMap("/ScheduleHours/All")
        .To<ScheduleHoursController>(c => c.All(teacherName, subjectName, searchTermOne, searchTermTwo, searchTermThree))
        .Which(controller => controller
                .WithData(Enumerable.Range(1, 10).Select(i => new ScheduleHour())))
                .ShouldReturn()
                .View(view => view
                .WithModelOfType<IEnumerable<ScheduleHourFormModel>>());
    }
}
