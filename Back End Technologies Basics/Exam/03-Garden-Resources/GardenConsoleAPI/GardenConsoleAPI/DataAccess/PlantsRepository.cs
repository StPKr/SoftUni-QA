using GardenConsoleAPI.Data.Models;
using GardenConsoleAPI.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GardenConsoleAPI.DataAccess
{
    public class PlantsRepository : IPlantsRepository
    {
        private readonly PlantsDbContext context;

        public PlantsRepository(PlantsDbContext context)
        {
            this.context = context;
        }
        public async Task AddPlantAsync(Plant plant)
        {
            await context.Plants.AddAsync(plant);
            await context.SaveChangesAsync();
        }

        public async Task DeletePlantAsync(string catalogNumber)
        {
            var plant = await context.Plants.FirstOrDefaultAsync(p => p.CatalogNumber == catalogNumber);
            if (plant != null)
            {
                context.Plants.Remove(plant);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Plant>> GetAllPlantsAsync()
        {
            var plants = await context.Plants.ToListAsync();
            return plants;
        }

        public async Task<Plant> GetPlantByCatalogNumberAsync(string catalogNumber)
        {
            var plant = await context.Plants.FirstOrDefaultAsync(p => p.CatalogNumber == catalogNumber);
            return plant;
        }

        public async Task<IEnumerable<Plant>> SearchPlantsByFoodType(string foodType)
        {
            var plants = await context.Plants.Where(p => p.FoodType == foodType).ToListAsync();
            return plants; ;
        }

        public async Task UpdatePlantAsync(Plant plant)
        {
            context.Plants.Update(plant);
            await context.SaveChangesAsync();
        }
    }
}
