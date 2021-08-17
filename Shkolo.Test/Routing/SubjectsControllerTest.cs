namespace Shkolo.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.Subjects;
    public class SubjectsControllerTest
    {
        [Test]
        public void GetAllBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Subjects/All")
                .To<SubjectsController>(c => c.All());

        [Test]
        public void GetAddBecomeShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Subjects/Add")
               .To<SubjectsController>(c => c.Add(With.Any<SubjectFormModel>()));

        [Test]
        public void PostAddBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Subjects/Add")
                    .WithMethod(HttpMethod.Post))
                .To<SubjectsController>(c => c.Add(With.Any<SubjectFormModel>()));

        [Test]
        [TestCase(1)]
        public void PostEditBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Subjects/Edit/1")
                   .WithMethod(HttpMethod.Post))
               .To<SubjectsController>(c => c.Edit(id));
        [Test]
        [TestCase(1)]
        public void GetDelBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Subjects/Delete/1")
                   .WithMethod(HttpMethod.Get))
               .To<SubjectsController>(c => c.Delete(id));
    }
}

