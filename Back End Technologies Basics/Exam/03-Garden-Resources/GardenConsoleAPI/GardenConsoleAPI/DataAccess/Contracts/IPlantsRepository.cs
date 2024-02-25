using GardenConsoleAPI.Data.Models;

namespace GardenConsoleAPI.DataAccess.Contracts
{
    public interface IPlantsRepository
    {
        Task<Plant> GetPlantByCatalogNumberAsync(string catalogNumber);
        Task<IEnumerable<Plant>> GetAllPlantsAsync();
        Task<IEnumerable<Plant>> SearchPlantsByFoodType(string foodType);
        Task AddPlantAsync(Plant plant);
        Task UpdatePlantAsync(Plant plant);
        Task DeletePlantAsync(string catalogNumber);
    }
}
