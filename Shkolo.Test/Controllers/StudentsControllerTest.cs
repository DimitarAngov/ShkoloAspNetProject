namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
    using Shkolo.Models.Students;
    using Shkolo.Test.Data;
    using System.Collections.Generic;
    public class StudentsControllerTest
    {
        [Test]
        [TestCase(1, "Мартин Ризов Бакалов", "2004 - 12 - 11", "Сандански", " ул. Кукуш No 6", "+359877745103", 11, 5, 13, 2)]
        public void AllShouldReturnCorrect(int id, string name, string dateOfBirth, string placeOfBirth,
                                           string adress, string phone, int numInClass, int parentId, int doctorId, int diaryId)
                => MyController<StudentsController>
                .Instance()
                  .WithData(TestData.GetStudent(id,name,dateOfBirth,placeOfBirth,
                            adress, phone, numInClass, parentId, doctorId, diaryId))
                  .Calling(c => c.All())
                  .ShouldReturn()
                  .View(view => view
                  .WithModelOfType<List<AllStudentViewModel>>());

       /* [Test]
        [TestCase(1, "Мартин Ризов Бакалов", "2004 - 12 - 11", "Сандански", " ул. Кукуш No 6", "+359877745103", 11,5,13,2)]
        public void AddShouldReturnCreatedResultWhenValidModelState(int id, string name, string dateOfBirth,string placeOfBirth,
                                                string adress,string phone, int numInClass, int parentId, int doctorId, int diaryId)
           => MyController<StudentsController>
               .Instance(instance => instance
               .WithUser())
               .Calling(c => c.Add(new StudentFormModel
               {
                   StudentId = id,
                   Name = name,
                   DateOfBirth= dateOfBirth,
                   PlaceOfBirth = placeOfBirth,
                   Address=adress,
                   Phone = phone,
                   NumInClass = numInClass,
                   ParentId = parentId,
                   DoctorId= doctorId,
                   DiaryId=diaryId,
               }))
               .ShouldHave()
               .ValidModelState()
               .AndAlso()
               .ShouldReturn()
               .Redirect(redirect => redirect
               .To<HomeController>(c => c.Index()));
*/
        [Test]
        [TestCase(1, "Мартин Ризов Бакалов", "2004 - 12 - 11", "Сандански", " ул. Кукуш No 6", "+359877745103", 11, 5, 13, 2)]
        public void DeleteShouldHaveRestrictionsForAuthorizedUsers(int id, string name, string dateOfBirth, string placeOfBirth,
                                                string adress, string phone, int numInClass, int parentId, int doctorId, int diaryId)
            => MyController<StudentsController>
                .Instance()
                .WithData(TestData.GetStudent(id, name, dateOfBirth, placeOfBirth,
                            adress, phone, numInClass, parentId, doctorId, diaryId))
                .WithUser()
                .Calling(c => c.Delete(id))
                .ShouldReturn()
                .Redirect(redirect => redirect
                .To<StudentsController>(c => c.All()));
    }
}
