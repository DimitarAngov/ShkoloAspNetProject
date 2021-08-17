namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Data.Models;
    using Shkolo.Models.Students;
    using System.Collections.Generic;
    using System.Linq;
    public class StudentsControllerTest
    {
        [Test]
        public void AllShouldReturnCorrect()
         => MyMvc
         .Pipeline()
         .ShouldMap("/Students/All")
         .To<StudentsController>(c => c.All())
         .Which(controller => controller
                 .WithData(Enumerable.Range(1, 10).Select(i => new Student())))
                 .ShouldReturn()
                 .View(view => view
                 .WithModelOfType<IEnumerable<StudentFormModel>>());
    }
}
