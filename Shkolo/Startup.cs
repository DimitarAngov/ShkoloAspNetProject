namespace Shkolo
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Shkolo.Data;
    using Shkolo.Data.Infrastructure;
    using Shkolo.Data.Seeders;
    using Shkolo.Services.Courses;
    using Shkolo.Services.Statistics;
    using Shkolo.Services.Students;
    using Shkolo.Services.Subjects;
    using Shkolo.Services.Teachers;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;
        

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddDbContext<ShkoloDbContext>(options => options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ShkoloDbContext>();
            
            services
                .AddControllersWithViews();

            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddTransient<ITeachersService,TeachersService>();
            services.AddTransient<ISubjectsService, SubjectsService>();
            services.AddTransient<IStudentsService,StudentsService>();
            services.AddTransient<ICoursesService, CoursesService>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDataBase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
               
                app.UseHsts();
            }
            
            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                     endpoints.MapDefaultControllerRoute();
                     endpoints.MapRazorPages();
                });
            // app.ApplicationServices.GetService<ShkoloDbContext>().Database.Migrate();
            //app.ApplicationServices.GetService<DataSeeder>();
        }
    }
}
