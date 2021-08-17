namespace Shkolo.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.Grades;
    public class GradesControllerTest
    {

        [Test]
        [TestCase("", "Стамен Станетков Пикянски", "Информационни технологии", "2,00")]
        public void GetAllBecomeShouldBeMapped(
            string searchTerm,
            string studentName,
            string subjectName,
            string gradeStudent)
        {
            var search = new { searchTerm = $"SearchTerm ={searchTerm}",
                               studentName=$"StudentName={studentName}",
                               subjectName=$"SubjectName={subjectName}",
                               gradeStudent=$"GradeStudent={gradeStudent}"};

            var id = "SearchTerm =&StudentName=Стамен+Станетков+Пикянски&SubjectName=Информационни+технологии&GradeStudent=2.00";
            var route = $"/Grades/All?{id}";
            MyRouting
               .Configuration().ShouldMap("/Grades/All/?SearchTerm=&StudentName=Стамен Станетков Пикянски&SubjectName=Информационни технологии&GradeStudent=2.00")
               .To<GradesController>(c => c.All(searchTerm, studentName, subjectName, gradeStudent));
               
        }
        [Test]
        public void GetAddBecomeShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Grades/Add")
               .To<GradesController>(c => c.Add(With.Any<GradeFormModel>()));

        [Test]
        public void PostAddBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Grades/Add")
                    .WithMethod(HttpMethod.Post))
                .To<GradesController>(c => c.Add(With.Any<GradeFormModel>()));

        [Test]
        [TestCase(1)]
        public void PostEditBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Grades/Edit/1")
                   .WithMethod(HttpMethod.Post))
               .To<GradesController>(c => c.Edit(id));
        [Test]
        [TestCase(1)]
        public void GetDelBecomeShouldBeMapped(int id)
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Grades/Delete/1")
                   .WithMethod(HttpMethod.Get))
               .To<GradesController>(c => c.Delete(id));
    }
}
