namespace Shkolo.Data.Datasets
{
    using Shkolo.Data.Seeders;
    using Shkolo.Data.Models;
    using System.Linq;
    using Shkolo.Data.Infrastructure;
    using System.Reflection;

    public class SeedSubjects
    {
        public static void DataSeedSubjects(ShkoloDbContext data, DataSeeder seed)
        {
            
            if (data.Subjects.Any() == false)
            {
                for (int i = 0; i < seed.DataSubjects.Length; i++)
                {
                    data.Subjects.Add(new Subject
                    {
                        Name = seed.DataSubjects[i]
                    });
                }

            }
            data.SaveChanges();
        }
    }
}
