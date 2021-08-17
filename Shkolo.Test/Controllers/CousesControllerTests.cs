namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Data.Models;
    using Shkolo.Models.Courses;
    using Shkolo.Test.Data;
    using System.Collections.Generic;
    using System.Linq;
    public class CousesControllerTests
    {

        [Test]
        [TestCase(1, 20, 1, 9)]
        public void AllShouldReturnCorrect()
          => MyMvc
          .Pipeline()
          .ShouldMap("/Cources/All")
          .To<CoursesController>(c => c.All())
          .Which(controller => controller
                  .WithData(Enumerable.Range(1, 10).Select(i => new Course())))
                  .ShouldReturn()
                  .View(view => view
                  .WithModelOfType<IEnumerable<CourseFormModel>>());

        [Test]
        [TestCase(1,20,1,9)]
        public void DeleteShouldHaveRestrictionsForAuthorizedUsers(int id, int subjectId, int typeSubjectId,int teacherId)
            => MyController<CoursesController>
                .Instance()
                .WithData(TestData.GetCourse(id, subjectId,typeSubjectId, teacherId))
                .WithUser("Admin")
                .Calling(c => c.Delete(id))
                .ShouldReturn()
                .Redirect(redirect => redirect
                .To<CoursesController>(c => c.All()));

        [Test]
        [TestCase(1, 20, 1, 9)]
        public void DeleteShouldReturnNotFoundWhenNonAuthorUser(int id, int subjectId, int typeSubjectId, int teacherId)
           => MyController<CoursesController>
               .Instance()
               .WithUser(user => user.WithIdentifier("NonAuthor"))
               .WithData(TestData.GetCourse(id, subjectId, typeSubjectId, teacherId))
               .Calling(c => c.Delete(id))
               .ShouldReturn()
               .NotFound();

        [Test]
        [TestCase(1,15,1,1)]
        public void CreateShouldReturnCreatedResultWhenValidModelState(int id, int subjectid, int typeSubjectId, int teacherId)
           => MyController<CoursesController>
               .Instance(instance => instance
               .WithUser())
               .Calling(c => c.Add(new CourseFormModel
               {
                   CourseId=id,
                   SubjectId = subjectid,
                   TypeSubjectId = typeSubjectId,
                   TeacherId=teacherId
               }))
               .ShouldHave()
               .ValidModelState()
               .AndAlso()
               .ShouldReturn()
               .Redirect(redirect => redirect
               .To<HomeController>(c => c.Index()));

    }
}
