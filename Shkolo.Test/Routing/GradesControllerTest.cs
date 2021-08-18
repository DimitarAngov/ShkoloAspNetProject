namespace Shkolo.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.Grades;
    public class GradesControllerTest
    {

        [Test]
        public void GetAddBecomeShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Grades/Add")
               .To<GradesController>(c => c.Add(With.Any<GradeFormModel>()));

        [Test]
        public void PostAddBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Grades/Add")
                    .WithMethod(HttpMethod.Post))
                .To<GradesController>(c => c.Add(With.Any<GradeFormModel>()));

        [Test]
        [TestCase(1)]
        public void PostEditBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Grades/Edit/1")
                   .WithMethod(HttpMethod.Post))
               .To<GradesController>(c => c.Edit(id));
        [Test]
        [TestCase(1)]
        public void GetDelBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Grades/Delete/1")
                   .WithMethod(HttpMethod.Get))
               .To<GradesController>(c => c.Delete(id));
    }
}
