namespace Shkolo.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Data;
    using Shkolo.Data.Models;
    using Shkolo.Models;
    using Shkolo.Services.Statistics;

    public class HomeController : Controller
    {
        
        private readonly IStatisticsService statistics;
        private readonly ShkoloDbContext db;
        public HomeController(IStatisticsService statistics,ShkoloDbContext db)
        {
                this.statistics = statistics;
                this.db = db;
        }

        public IActionResult Index()
        
        {
            var viewModel = new StatisticsServiceModel
            {
                TotalStudents = db.Students.Count(),
                TotalSubjects = db.Subjects.Count(),
                TotalTeachers = db.Teachers.Count(),
                TotalCouses = db.Courses.Count()
            };

            return View(viewModel);
        }
        
              
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()=>View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        
    }
}
