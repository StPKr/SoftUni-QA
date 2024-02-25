using GardenConsoleAPI.Business;
using GardenConsoleAPI.Data.Models;
using System.Text.Json;

namespace GardenConsoleAPI.DataAccess
{
    public class DatabaseSeeder
    {
        public static async Task SeedDatabaseAsync(PlantsDbContext context, PlantsManager PlantsManager)
        {
            if (context.Plants.Count() == 0)
            {
                string jsonFilePath = Path.Combine("Data", "Seed", "plants.json");
                string jsonData = File.ReadAllText(jsonFilePath);

                var plants = JsonSerializer.Deserialize<List<Plant>>(jsonData);

                if (plants != null)
                {
                    foreach (var plant in plants)
                    {
                        if (!context.Plants.Any(a => a.CatalogNumber == plant.CatalogNumber))
                        {
                            var newPlant = new Plant()
                            {
                                Name = plant.Name,
                                CatalogNumber = plant.CatalogNumber,
                                FoodType = plant.FoodType,
                                PlantType = plant.PlantType,
                                Quantity = plant.Quantity,
                                IsEdible = plant.IsEdible,
                            };
                            await PlantsManager.AddAsync(newPlant);
                        }
                    }

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
