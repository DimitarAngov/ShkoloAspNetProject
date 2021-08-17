namespace Shkolo.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.Courses;
    public class CousesControllerTests
    {

        [Test]
        public void GetAllBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Courses/All")
                .To<CoursesController>(c => c.All());

        [Test]
        public void GetAddBecomeShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Courses/Add")
               .To<CoursesController>(c => c.Add(With.Any<CourseFormModel>()));

        [Test]
        public void PostAddBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Courses/Add")
                    .WithMethod(HttpMethod.Post))
                .To<CoursesController>(c => c.Add(With.Any<CourseFormModel>()));

        [Test]
        [TestCase(1)]
        public void PostEditBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Courses/Edit/1")
                   .WithMethod(HttpMethod.Post))
               .To<CoursesController>(c => c.Edit(id));
        [Test]
        [TestCase(1)]
        public void GetDelBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Courses/Delete/1")
                   .WithMethod(HttpMethod.Get))
               .To<CoursesController>(c => c.Delete(id));
    } 
}

