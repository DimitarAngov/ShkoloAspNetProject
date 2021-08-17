using Shkolo.Controllers;

namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using Shkolo.Controllers;
    using NUnit.Framework;
    using Shkolo.Data.Models;
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;
    using System.Linq;
    using Shkolo.Test.Data;

    [TestFixture]
    public class TeachersControllerTest
    {

        [Test]
        public void AllShouldReturnCorrectViewWithModel()
            => MyController<TeachersController>
                .Instance(controller => controller
                    .WithData(Enumerable.Range(1, 10).Select(i => new Teacher())))
                    .Calling(c => c.All())
                    .ShouldReturn()
                    .View(view=>view
                    .WithModelOfType<IEnumerable<TeacherFormModel>>()
                    .Passing(c=>c.Count()==10));

        [Test]
        public void EIndexShouldReturnCorrectAction()
            => MyController<TeachersController>
                .Instance()
                .Calling(c => c.All())
                .ShouldReturn()
                .View();

        [Test]
        public void GetBecomeShouldBeForAuthorizedUsersAndReturnView()
            => MyController<TeachersController>
                .Instance()
                .Calling(c => c.All())
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                .AllowingAnonymousRequests())
                 .AndAlso()
                .ShouldReturn()
                .View();


        [Test]
        [TestCase("Admin")]
        [TestCase("Teacher")]

        public void ReturnOneTeacherWhenUserIsNotAuthorizedInGetAction(string user)
        {
            var model = new TeacherFormModel {Name = "Сашка Андонова Николова" };
            
            MyController<TeachersController>
                .Instance()
                .WithUser(user)
                .Calling(c => c.Add(model))
                .ShouldReturn().Redirect(redirect => redirect.ToAction("Index"));
            //.Ok();
            //.ShouldPassForThe<ViewResult>(viewResult
            //=> Assert.AreSame(model, viewResult.Model));
            //.Passing(c => c.Count == 1);

        }

  
        [Test]
        public void IndexShouldReturnViewWithTeachers()
         => MyController<TeachersController>
        // Arrange
        .Instance()
        .WithData(
            new Teacher { Name = "Сашка Андонова Николова" },
            new Teacher { Name = "Елза Василева Булакиева" })
        // Act
        .Calling(c => c.All())
        // Assert
        .ShouldReturn()
        .View(result => result
            .WithModelOfType<List<TeacherFormModel>>()
            .Passing(model => model.Count == 2));


        [Test]
        public void ShouldReturnCreatedShouldNotThrowExceptionWithCreatedAtRouteResult()
        {

            MyController<TeachersController>
            .Calling(c => c.CreatedAtAction("Add", 5))
            .ShouldReturn()
            .Created();
        }

        [Test]
        [TestCase(1, "TeacherName 1")]
        public void DeleteShouldHaveRestrictionsForAuthorizedUsers(int id, string name)
            => MyController<TeachersController>
                .Instance()
                .WithData(TestData.GetTeacher(id, name))
                .WithUser("Admin")
                .Calling(c => c.Delete(id))
                .ShouldReturn()
                .Redirect(redirect => redirect
                .To<TeachersController>(c => c.All()));

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void DeleteShouldReturnOkResultWhenAddressDeleted(int id)
           => MyController<TeachersController>
               .Instance(instance => instance
                   .WithUser("Admin")
                   .WithData(
                   new Teacher { TeacherId=1,Name = "Сашка Андонова Николова" },
                   new Teacher { TeacherId = 2, Name = "Елза Василева Булакиева" }))
               .Calling(c => c.Delete(id))

               .ShouldReturn()
               .Ok();

        [Test]
        public void DeleteShouldReturnBadRequestWhenAddressIdIsNotExisting()
            => MyController<TeachersController>
                .Instance(instance => instance
                    .WithUser())
                .Calling(c => c.Delete(With.Any<int>()))
                .ShouldReturn()
                .BadRequest();

        [Test]
        [TestCase(1, "-")]
        public void CreateShouldHaveInvalidModelStateWhenRequestModelIsInvalid(int id, string name)
           => MyController<TeachersController>
                .Calling(c => c.Add(new TeacherFormModel
                {
                    TeacherId = id,
                    Name = name
                }))
                .ShouldHave()
               .InvalidModelState();

        [Test]
        [TestCase(1, "Стефани Николаева Мездрова-Кирова")]
        public void CreatePostShouldSaveArticleSetModelStateMessageAndRedirectWhenValidModelState(int id, string name)
          => MyController<TeachersController>
              .Instance()
              .WithUser("mitko@abv.bg")
              .Calling(c => c.Add(new TeacherFormModel
              {
                  TeacherId = id,
                  Name = name
              }))
              .ShouldHave()
              .ValidModelState()
              .AndAlso()
              .ShouldHave()
               .Data(data => data
                    .WithSet<Teacher>(teachers => teachers
                        .Any(d =>
                            d.TeacherId == id &&
                            d.Name == name )))
              /*.AndAlso()
              .ShouldHave()
              .TempData(tempData => tempData
              .ContainingEntryWithValue("Стефани Николаева Мездрова-Кирова"))*/
              .AndAlso()
              .ShouldReturn()
              .Redirect(redirect => redirect
                  .To<HomeController>(c => c.Index()));

        [Test]
        [TestCase(3, "TeacherName 4")]
        public void EditShouldReturnOkResultWhenValidModelState(int id, string editName)
           => MyController<TeachersController>
               .Instance(instance => instance
                    .WithUser(new[] { "Admin" })
                   .WithData(TestData.GetTeacher(3,"TeacherName 3")))
               .Calling(c => c.Edit(id, new TeacherFormModel
                {
                   Name = editName
                }))
                .ShouldHave()
                .ValidModelState()
                .AndAlso()
                .ShouldReturn()
               .Ok();
    }
}
       