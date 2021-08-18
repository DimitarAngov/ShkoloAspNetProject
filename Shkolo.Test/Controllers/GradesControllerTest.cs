namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.Grades;
    using Shkolo.Test.Data;
    public class GradesControllerTest
    {
        [Test]
        [TestCase(1, 1, 343, "4.00", 16, "06.10.2020")]
        public void AllShouldReturnCorrect(int id, int term_Number, int studentCourseId,
            string gradeStudents, int typeGradeId, string date)
           => MyController<GradesController>
                .Instance()
                  .WithData(TestData.GetGrade(id,term_Number,studentCourseId,
                                                    gradeStudents, typeGradeId, date))
                  .Calling(c => c.All("","","",""))
                  .ShouldReturn()
                  .View(view => view
                  .WithModelOfType<AllGradeSearchViewModel>());

        [Test]
        [TestCase(1, 1, 343, "4.00", 16, "06.10.2020")]
        public void AddShouldReturnCreatedResultWhenValidModelState(int id, int term_Number, int studentCourseId, 
            string gradeStudents, int typeGradeId,string date)
           => MyController<GradesController>
               .Instance(instance => instance
               .WithUser())
               .Calling(c => c.Add(new GradeFormModel
               {
                   GradeId = id,
                   Term_Number = term_Number,
                   StudentCourseId = studentCourseId,
                   GradeStudents = gradeStudents,
                   TypeGradeId = typeGradeId,
                   Date=date
               }))
               .ShouldHave()
               .ValidModelState()
               .AndAlso()
               .ShouldReturn()
               .Redirect(redirect => redirect
               .To<HomeController>(c => c.Index()));

        [Test]
        [TestCase(1, 1, 343, "4.00", 16, "06.10.2020")]
        public void DeleteShouldHaveRestrictionsForAuthorizedUsers(int id, int term_Number, int studentCourseId,
                                                            string gradeStudents, int typeGradeId, string date)
           => MyController<GradesController>
               .Instance()
               .WithData(TestData.GetGrade(id, term_Number, studentCourseId,
                                                    gradeStudents, typeGradeId, date))
               .WithUser("Admin")
               .Calling(c => c.Delete(id))
               .ShouldReturn()
               .Redirect(redirect => redirect
               .To<GradesController>(c => c.All("", "", "", "")));
    }
}
