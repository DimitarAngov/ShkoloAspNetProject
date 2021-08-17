namespace Shkolo.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.Students;
    public class StudentsControllerTest
    {
        [Test]
        public void GetAllBecomeShouldBeMapped()
          => MyRouting
              .Configuration()
              .ShouldMap("/Students/All")
              .To<StudentsController>(c => c.All());

        [Test]
        public void GetAddBecomeShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Students/Add")
               .To<StudentsController>(c => c.Add(With.Any<StudentFormModel>()));

        [Test]
        public void PostAddBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Students/Add")
                    .WithMethod(HttpMethod.Post))
                .To<StudentsController>(c => c.Add(With.Any<StudentFormModel>()));

        [Test]
        [TestCase(1)]
        public void PostEditBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Students/Edit/1")
                   .WithMethod(HttpMethod.Post))
               .To<StudentsController>(c => c.Edit(id));
        [Test]
        [TestCase(1)]
        public void GetDelBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Students/Delete/1")
                   .WithMethod(HttpMethod.Get))
               .To<StudentsController>(c => c.Delete(id));
    }
}
