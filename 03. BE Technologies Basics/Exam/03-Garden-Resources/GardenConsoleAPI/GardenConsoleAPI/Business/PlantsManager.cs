using GardenConsoleAPI.Business.Contracts;
using GardenConsoleAPI.Data.Models;
using GardenConsoleAPI.DataAccess.Contracts;
using System.ComponentModel.DataAnnotations;

namespace GardenConsoleAPI.Business
{
    public class PlantsManager : IPlantsManager
    {
        private readonly IPlantsRepository repository;

        public PlantsManager(IPlantsRepository repository)
        {
            this.repository = repository;
        }
        public async Task AddAsync(Plant plant)
        {
            if (!IsValid(plant))
            {
                throw new ValidationException("Invalid plant!");
            }
            else
            {
                await repository.AddPlantAsync(plant);
            }
        }

        public Task DeleteAsync(string catalogNumber)
        {
            if (string.IsNullOrWhiteSpace(catalogNumber))
            {
                throw new ArgumentException("Catalog number cannot be empty.");
            }

            return repository.DeletePlantAsync(catalogNumber);
        }

        public async Task<IEnumerable<Plant>> GetAllAsync()
        {
            var plants = await repository.GetAllPlantsAsync();

            if (!plants.Any())
            {
                throw new KeyNotFoundException("No plant found.");
            }

            return plants;
        }

        public async Task<Plant> GetSpecificAsync(string catalogNumber)
        {
            if (string.IsNullOrWhiteSpace(catalogNumber))
            {
                throw new ArgumentException("Catalog number cannot be empty.");
            }

            var plant = await repository.GetPlantByCatalogNumberAsync(catalogNumber);

            if (plant == null)
            {
                throw new KeyNotFoundException($"No plant found with catalog number: {catalogNumber}");
            }

            return plant;
        }

        public async Task<IEnumerable<Plant>> SearchByFoodTypeAsync(string foodType)
        {
            if (string.IsNullOrWhiteSpace(foodType))
            {
                throw new ArgumentException("Food type cannot be empty.");
            }

            var plants = await repository.SearchPlantsByFoodType(foodType);

            if (plants == null || !plants.Any())
            {
                throw new KeyNotFoundException("No plant found with the given food type.");
            }

            return plants;
        }

        public async Task UpdateAsync(Plant plant)
        {
            if (!IsValid(plant))
            {
                throw new ValidationException("Invalid plant!");
            }

            await repository.UpdatePlantAsync(plant);
        }

        private bool IsValid(Plant plant)
        {
            if (plant == null)
            {
                return false;
            }

            var validateResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(plant);

            if (!Validator.TryValidateObject(plant, validationContext, validateResults, true))
            {
                foreach (var validationResult in validateResults)
                {
                    Console.WriteLine($"Validation Error: {validationResult.ErrorMessage}");
                }
                return false;
            }

            return true;
        }
    }
}
