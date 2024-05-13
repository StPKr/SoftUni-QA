using GardenConsoleAPI.Data.Models;

namespace GardenConsoleAPI.Business.Contracts
{
    public interface IPlantsManager
    {
        Task AddAsync(Plant plant);
        Task<IEnumerable<Plant>> GetAllAsync();
        Task<IEnumerable<Plant>> SearchByFoodTypeAsync(string foodType);
        Task<Plant> GetSpecificAsync(string catalogNumber);
        Task UpdateAsync(Plant plant);
        Task DeleteAsync(string catalogNumber);
    }
}
