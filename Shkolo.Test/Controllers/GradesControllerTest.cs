namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Data.Models;
    using Shkolo.Models.Grades;
    using System.Collections.Generic;
    using System.Linq;
    public class GradesControllerTest
    {
        [Test]
        [TestCase("", "Стамен Станетков Пикянски", "Информационни технологии", "2,00")]
        public void AllShouldReturnCorrect(
            string searchTerm,
            string studentName,
            string subjectName,
            string gradeStudent)
        => MyMvc
        .Pipeline()
        .ShouldMap("/Grades/All")
        .To<GradesController>(c => c.All(searchTerm, studentName, subjectName, gradeStudent))
        .Which(controller => controller
                .WithData(Enumerable.Range(1, 10).Select(i => new Grade())))
                .ShouldReturn()
                .View(view => view
                .WithModelOfType<IEnumerable<GradeFormModel>>());
    }
}
