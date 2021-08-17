namespace Shkolo.Data.Infrastructure
{
    using Shkolo.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using Shkolo.Data.Datasets;
    using System;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using Shkolo.Data.Datasets.Seeders;
    using System.Security.Claims;
    using System.Collections.Generic;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDataBase(this IApplicationBuilder app)
        {
            using var scopedServicesData = app.ApplicationServices.CreateScope();
            using var scopedServicesSeeder = app.ApplicationServices.CreateScope();
            using var serviceScope = app.ApplicationServices.CreateScope();
           
            var db = scopedServicesData.ServiceProvider.GetService<ShkoloDbContext>();
            var seeder = scopedServicesSeeder.ServiceProvider.GetService<SeedDataServices>();
            var services = serviceScope.ServiceProvider;
          
            MigrateDatabase(db);
            //SeedDataServices(db, seeder);
            //SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(ShkoloDbContext db)
        {
            db.Database.Migrate();
        }

        private static void SeedDataServices(ShkoloDbContext db, SeedDataServices seeder)
        {
            var seed = new DataSeeder();
            var seedSchedule = new DataSeederScheduleHour();
            var seedGrade = new DataSeederGrade();
            
            seeder = new SeedDataServices(db, seed, seedSchedule, seedGrade);
            seeder.SeederData();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            DataAdminArea dataAdminArea = new DataAdminArea();
            DataSeeder dataSeeder = new DataSeeder();

            var claimsS = new List<Claim>();
            var claimsT = new List<Claim>();
                    
            
            for (int i = 0; i < 12; i+=3)
            {
                claimsS.Clear();
                claimsT.Clear();
                Task
                        .Run(async () =>
                        {
                            var role = new IdentityRole { Name = dataAdminArea.DataRole[i] };

                            if (!await roleManager.RoleExistsAsync(dataAdminArea.DataRole[i]))
                            {
                                await roleManager.CreateAsync(role);
                            }

                            string adminEmail = dataAdminArea.DataUser[i];
                            string adminPhone = dataAdminArea.DataUser[i+1];
                            string password = dataAdminArea.DataUser[i + 2];

                            var user = new IdentityUser
                            {
                                UserName = adminEmail,
                                Email = adminEmail,
                                PhoneNumber = adminPhone

                            };
                            
                            await userManager.CreateAsync(user, password);
                            await userManager.AddToRoleAsync(user, role.Name);
                            
                            if (i == 3)
                            {
                                claimsT.Add(new Claim(dataAdminArea.DataClaims[3], dataSeeder.DataSubjects[3]));
                                await userManager.AddClaimsAsync(user, claimsT);
                            }

                            else if (i == 6)
                            {
                                claimsS.Add(new Claim(dataAdminArea.DataClaims[0], dataSeeder.DataStudents[0]));
                                claimsS.Add(new Claim(dataAdminArea.DataClaims[1], dataSeeder.DataStudents[4]));
                                claimsS.Add(new Claim(dataAdminArea.DataClaims[2], dataSeeder.DataStudents[5]));
                                await userManager.AddClaimsAsync(user, claimsS);
                            }
                            else if (i == 9)
                            {
                                claimsS.Add(new Claim(dataAdminArea.DataClaims[0], dataSeeder.DataStudents[6*i]));
                                claimsS.Add(new Claim(dataAdminArea.DataClaims[1], dataSeeder.DataStudents[6*i+4]));
                                claimsS.Add(new Claim(dataAdminArea.DataClaims[2], dataSeeder.DataStudents[6*i+5]));
                                await userManager.AddClaimsAsync(user, claimsS);
                            }
                        })
                        .GetAwaiter()
                        .GetResult();
                 
            }
        }
    }
}
