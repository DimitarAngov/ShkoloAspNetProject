namespace Shkolo.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using NUnit.Framework;
    using Shkolo.Controllers;
     public class HomeControllerTest
    {
        [Test]
        public void AllShouldReturnCorrect()
         => MyController<HomeController>
                .Instance()
                    .Calling(c => c.Index())
                    .ShouldReturn()
                    .View();
           
    }
}
