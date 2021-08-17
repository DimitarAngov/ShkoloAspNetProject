namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Data.Models;
    using Shkolo.Models.Subjects;
    using Shkolo.Test.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class SubjectsControllerTest
    {
        [Test]
        public void AllShouldReturnCorrect()
           => MyMvc
           .Pipeline()
           .ShouldMap("/Subjects/All")
           .To<SubjectsController>(c => c.All())
           .Which(controller => controller
                   .WithData(Enumerable.Range(1, 10).Select(i => new Subject())))
                   .ShouldReturn()
                   .View(view => view
                   .WithModelOfType<IEnumerable<SubjectFormModel>>());
        [Test]
        public void AddShouldReturnCorrect()
        {
            var model = new SubjectFormModel();
            MyMvc
            .Pipeline()
            .ShouldMap(request=>request
            .WithPath("/Subjects/Add")
            .WithUser("Admin"))
            .To<SubjectsController>(c => c.Add())
            .Which()
            .ShouldHave()
            .ActionAttributes(atr=>atr
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<IEnumerable<SubjectFormModel>>());
                        
        }

        [Test]
        [TestCase(1, "SubjectName 1")]
        public void DeleteShouldHaveRestrictionsForAuthorizedUsers(int id, string name)
            => MyController<SubjectsController>
                .Instance()
                .WithData(TestData.GetSubject(id, name))
                .WithUser("Admin")
                .Calling(c => c.Delete(id))
                .ShouldReturn()
                .Redirect(redirect => redirect
                .To<SubjectsController>(c => c.All()));

        [Test]
        [TestCase("Admin")]
        public void CreateGetShouldHaveRestrictionsForHttpGetOnlyAndAuthorizedUsersAndShouldReturnView(string role)
                 => MyController<SubjectsController>
                 .Instance()
                 .WithUser("", role)
                 .Calling(c => c.Add())
                 .ShouldHave()
                 .ActionAttributes(attrs => attrs
                 .RestrictingForHttpMethod(HttpMethod.Get)
                 .RestrictingForAuthorizedRequests())
                 .AndAlso()
                 .ShouldReturn()
                 .Ok();

        [Test]
        [TestCase(1, "-")]
        public void CreateShouldHaveInvalidModelStateWhenRequestModelIsInvalid(int id, string name)
           => MyController<SubjectsController>
                .Calling(c => c.Add(new SubjectFormModel
                {
                    SubjectId = id,
                    Name = name
                }))
                .ShouldHave()
               .InvalidModelState();

        [Test]
        [TestCase(20,"Математика")]
        public void CreatePostShouldSaveArticleSetModelStateMessageAndRedirectWhenValidModelState(int id, string name)
          => MyController<SubjectsController>
              .Instance()
              .WithUser()
              .Calling(c => c.Add(new SubjectFormModel
              {
                  SubjectId = id,
                  Name = name
              }))
              .ShouldHave()
              .ValidModelState()
              .AndAlso()
              .ShouldHave()
               .Data(data => data
                    .WithSet<Subject>(subjects => subjects
                        .Any(d =>
                            d.SubjectId == id &&
                            d.Name == name)))
              .AndAlso()
              .ShouldHave()
              .TempData(tempData => tempData
              .ContainingEntryWithValue("Математика"))
              .AndAlso()
              .ShouldReturn()
              .Redirect(redirect => redirect
              .To<HomeController>(c => c.Index()));

        [Test]
        [TestCase(20, "Математика")]
        public void CreateShouldReturnCreatedResultWhenValidModelState(int id, string name)
           => MyController<SubjectsController>
               .Instance(instance => instance
               .WithUser())
               .Calling(c => c.Add(new SubjectFormModel
               {
                   SubjectId = id,
                   Name = name
               }))
               .ShouldHave()
               .ValidModelState()
               .AndAlso()
               .ShouldReturn()
               .Redirect(redirect => redirect
               .To<HomeController>(c => c.Index()));
    }
}
