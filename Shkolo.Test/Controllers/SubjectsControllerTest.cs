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
        [TestCase(20, "Математика")]
        public void AddShouldReturnCreatedResultWhenValidModelState(int id, string name)
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

        /*[Test]
        [TestCase(3, "SubjectName 4")]
        public void EditShouldReturnOkResultWhenValidModelState(int id, string editName)
           => MyController<SubjectsController>
               .Instance(instance => instance
                    .WithUser()
                   .WithData(TestData.GetSubject(3, "SubjectName 3")))
               .Calling(c => c.Edit(id, new SubjectFormModel
               {
                   Name = editName
               }))
                .ShouldHave()
                .ValidModelState()
                .AndAlso()
                .ShouldReturn()
               .Ok();*/


    }
}
