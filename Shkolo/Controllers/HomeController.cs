namespace Shkolo.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Models;
    using Shkolo.Services.Statistics;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;
        public HomeController(IStatisticsService statistics)
        {
                this.statistics = statistics;
        }
        public IActionResult Index()
        
        {
            var viewModel=statistics.Total();
            return View(viewModel);
        }
        
              
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()=>View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        public IActionResult Error() => View();
    }
}
