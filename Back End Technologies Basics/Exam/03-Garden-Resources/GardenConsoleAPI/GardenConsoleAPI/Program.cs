using GardenConsoleAPI.Business;
using GardenConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GardenConsoleAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var engine = new Engine();

                var contextFactory = new PlantsDbContextFactory();

                using var context = contextFactory.CreateDbContext(args);

                await context.Database.MigrateAsync();

                var plantsRepository = new PlantsRepository(context);
                var plantsManager = new PlantsManager(plantsRepository);

                await DatabaseSeeder.SeedDatabaseAsync(context, plantsManager);

                await engine.Run(plantsManager);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }
    }
}
