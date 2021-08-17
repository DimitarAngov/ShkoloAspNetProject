namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using Shkolo.Controllers;
    using NUnit.Framework;
    using Shkolo.Data.Models;
    using Shkolo.Models.Teachers;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class TeachersControllerShould
    {

        [Test]
        public void IndexShouldReturnCorrectViewWithModel()
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

 
    } 
}
