namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Data.Models;
    using Shkolo.Models.Subjects;
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
            .WithUser())
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
    }
}
