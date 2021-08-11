namespace Shkolo.Data.Infrastructure
{
    using Shkolo.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using Shkolo.Data.Datasets;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDataBase(this IApplicationBuilder app)
        {
            using var scopedServicesData = app.ApplicationServices.CreateScope();
            using var scopedServicesSeeder = app.ApplicationServices.CreateScope();
            
            var data = scopedServicesData.ServiceProvider.GetService<ShkoloDbContext>();
            var seeder = scopedServicesSeeder.ServiceProvider.GetService<SeedDataServices>();
           
            data.Database.Migrate();
            seeder.SeederData();

            return app;
        }
    }
}
