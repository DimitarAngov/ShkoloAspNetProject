namespace MyApp.Tests
{
    using MyTested.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Shkolo;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Configuration;
    using Shkolo.Services.Teachers;
    using Shkolo.Services.Statistics;
    using Shkolo.Services.Subjects;
    using Shkolo.Services.Students;
    using Shkolo.Services.Schedules;
    using Shkolo.Data.Datasets.Services;
    using Shkolo.Data.Datasets;

    public class TestStartup :Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            // Replace only your own custom services. The ASP.NET Core ones 
            // are already replaced by MyTested.AspNetCore.Mvc. 
            //services.Replace<IService, MockedService>();
             services.ReplaceScoped<ITeachersService, TeachersService>();
            /*services.Replace<IStatisticsService, MockedStatisticsService>();
            services.ReplaceScoped<ISeedDataServices,SeedDataServices>();
           
            services.Replace<ISubjectsService, SubjectsService>();
            services.Replace<IStudentsService, StudentsService>();
            services.Replace<ICoursesService, CoursesService>();
            services.Replace<ISchedulesService, SchedulesService>();
            services.Replace<IScheduleHoursService, ScheduleHoursService>();
            services.Replace<IGradesService, GradesService>();
            services.Replace<IClaimsService, ClaimsService>();*/

        }
    }
}