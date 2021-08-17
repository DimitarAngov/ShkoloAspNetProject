namespace Shkolo.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.Teachers;
    public class TeachersControllerTest
    {
        [Test]
        public void GetAllBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Teachers/All")
                .To<TeachersController>(c => c.All());

        [Test]
        public void GetAddBecomeShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Teachers/Add")
               .To<TeachersController>(c => c.Add(With.Any<TeacherFormModel>()));

        [Test]
        public void PostAddBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Teachers/Add")
                    .WithMethod(HttpMethod.Post))
                .To<TeachersController>(c => c.Add(With.Any<TeacherFormModel>()));

        [Test]
        [TestCase(1)]
        public void PostEditBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Teachers/Edit/1")
                   .WithMethod(HttpMethod.Post))
               .To<TeachersController>(c => c.Edit(id));
        [Test]
        [TestCase(1)]
        public void GetDelBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Teachers/Delete/1")
                   .WithMethod(HttpMethod.Get))
               .To<TeachersController>(c => c.Delete(id));
    }
}
