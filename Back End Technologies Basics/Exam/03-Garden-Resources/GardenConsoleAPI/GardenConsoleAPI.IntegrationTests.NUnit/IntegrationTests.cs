using GardenConsoleAPI.Business;
using GardenConsoleAPI.Business.Contracts;
using GardenConsoleAPI.Data.Models;
using GardenConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace GardenConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestPlantsDbContext dbContext;
        private IPlantsManager plantsManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestPlantsDbContext();
            this.plantsManager = new PlantsManager(new PlantsRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddPlantAsync_ShouldAddNewPlant()
        {
            // Arrange
            var firstPlant = new Plant()
            {
                CatalogNumber = "01HP01PRFC6E",
                Name = "Tomato",
                PlantType = "Creepers",
                FoodType = "Fruit",
                Quantity = 200,
                IsEdible = true
            };
            // Act
            await plantsManager.AddAsync(firstPlant);
            // Assert
            var dbPlants = await dbContext.Plants.FirstOrDefaultAsync(p => p.CatalogNumber == firstPlant.CatalogNumber);

            Assert.NotNull(dbPlants);
            Assert.AreEqual(firstPlant.Name, dbPlants.Name);
            Assert.AreEqual(firstPlant.PlantType, dbPlants.PlantType);
            Assert.AreEqual(firstPlant.FoodType, dbPlants.FoodType);
            Assert.AreEqual(firstPlant.Quantity, dbPlants.Quantity);
            Assert.AreEqual(firstPlant.IsEdible, dbPlants.IsEdible);
            Assert.AreEqual(firstPlant.CatalogNumber, dbPlants.CatalogNumber);
        }

        //Negative test
        [Test]
        public async Task AddPlantAsync_TryToAddPlantWithInvalidCredentials_ShouldThrowException()
        {
            // Arrange
            var firstPlant = new Plant()
            {
                CatalogNumber = "9999",
                Name = "Tomato",
                PlantType = "Creepers",
                FoodType = "Fruit",
                Quantity = 200,
                IsEdible = true
            };
            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(async () => await plantsManager.AddAsync(firstPlant));

            var actual = await dbContext.Plants.FirstOrDefaultAsync(c => c.CatalogNumber == firstPlant.CatalogNumber);

            Assert.IsNull(actual);
            Assert.That(ex?.Message, Is.EqualTo("Invalid plant!"));

        }

        [Test]
        public async Task DeletePlantAsync_WithValidCatalogNumber_ShouldRemovePlantFromDb()
        {
            // Arrange
            var firstPlant = new Plant()
            {
                CatalogNumber = "01HP01PRFC6E",
                Name = "Tomato",
                PlantType = "Creepers",
                FoodType = "Fruit",
                Quantity = 200,
                IsEdible = true
            };
            await plantsManager.AddAsync(firstPlant);

            // Get data from db and assert.

            // Act
            await plantsManager.DeleteAsync(firstPlant.CatalogNumber);

            // Assert
            var plantInDb = await dbContext.Plants.FirstOrDefaultAsync(x => x.CatalogNumber == firstPlant.CatalogNumber);

            Assert.IsNull(plantInDb);
        }

        [Test]
        public async Task DeletePlantAsync_TryToDeleteWithNullOrWhiteSpaceCatalogNumber_ShouldThrowException()
        {
            var exception = Assert.ThrowsAsync<ArgumentException>(() => plantsManager.DeleteAsync(null));
            var exception2 = Assert.ThrowsAsync<ArgumentException>(() => plantsManager.DeleteAsync(" "));

            Assert.That(exception.Message, Is.EqualTo("Catalog number cannot be empty."));
            Assert.That(exception2.Message, Is.EqualTo("Catalog number cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenPlantsExist_ShouldReturnAllPlants()
        {
            // Arrange
            var newPlant = new Plant()
            {
                CatalogNumber = "01HP01PRFC6E",
                Name = "Tomato",
                PlantType = "Creepers",
                FoodType = "Fruit",
                Quantity = 200,
                IsEdible = true
            };
            await plantsManager.AddAsync(newPlant);

            var secondNewPlant = new Plant()
            {
                CatalogNumber = "01HP01PRFDBK",
                Name = "Cucumber",
                PlantType = "Creepers",
                FoodType = "Vegetable",
                Quantity = 234,
                IsEdible = true
            };
            await plantsManager.AddAsync(secondNewPlant);
            // Act
            var result = await plantsManager.GetAllAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));

            var firstPlant = result.First();
            Assert.AreEqual(firstPlant.Name, newPlant.Name);
            Assert.AreEqual(firstPlant.PlantType, newPlant.PlantType);
            Assert.AreEqual(firstPlant.FoodType, newPlant.FoodType);
            Assert.AreEqual(firstPlant.Quantity, newPlant.Quantity);
            Assert.AreEqual(firstPlant.IsEdible, newPlant.IsEdible);
            Assert.AreEqual(firstPlant.CatalogNumber, newPlant.CatalogNumber);

            var secondPlant = result.Skip(1).First();
            Assert.AreEqual(secondPlant.Name, secondNewPlant.Name);
            Assert.AreEqual(secondPlant.PlantType, secondNewPlant.PlantType);
            Assert.AreEqual(secondPlant.FoodType, secondNewPlant.FoodType);
            Assert.AreEqual(secondPlant.Quantity, secondNewPlant.Quantity);
            Assert.AreEqual(secondPlant.IsEdible, secondNewPlant.IsEdible);
            Assert.AreEqual(secondPlant.CatalogNumber, secondNewPlant.CatalogNumber);
        }

        [Test]
        public async Task GetAllAsync_WhenNoPlantsExist_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var expection = Assert.ThrowsAsync<KeyNotFoundException>(() => plantsManager.GetAllAsync());

            Assert.That(expection.Message, Is.EqualTo("No plant found."));
        }

        [Test]
        public async Task SearchByFoodTypeAsync_WithExistingFoodType_ShouldReturnMatchingPlants()
        {
            // Arrange
            var newPlant = new Plant()
            {
                CatalogNumber = "01HP01PRFC6E",
                Name = "Tomato",
                PlantType = "Creepers",
                FoodType = "Fruit",
                Quantity = 200,
                IsEdible = true
            };
            await plantsManager.AddAsync(newPlant);

            var secondNewPlant = new Plant()
            {
                CatalogNumber = "01HP01PRFDBK",
                Name = "Cucumber",
                PlantType = "Creepers",
                FoodType = "Vegetable",
                Quantity = 234,
                IsEdible = true
            };
            await plantsManager.AddAsync(secondNewPlant);
            // Act
            var result = await plantsManager.SearchByFoodTypeAsync("Fruit");

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1));
            var firstPlant = result.First();
            Assert.AreEqual(firstPlant.Name, newPlant.Name);
            Assert.AreEqual(firstPlant.PlantType, newPlant.PlantType);
            Assert.AreEqual(firstPlant.FoodType, newPlant.FoodType);
            Assert.AreEqual(firstPlant.Quantity, newPlant.Quantity);
            Assert.AreEqual(firstPlant.IsEdible, newPlant.IsEdible);
            Assert.AreEqual(firstPlant.CatalogNumber, newPlant.CatalogNumber);
        }

        [Test]
        public async Task SearchByFoodTypeAsync_WithNonExistingFoodType_ShouldThrowKeyNotFoundException()
        {
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => plantsManager.SearchByFoodTypeAsync("NON_EXISTING_TYPE"));

            Assert.That(exception.Message, Is.EqualTo("No plant found with the given food type."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidCatalogNumber_ShouldReturnPlant()
        {
            var newPlant = new Plant()
            {
                CatalogNumber = "01HP01PRFC6E",
                Name = "Tomato",
                PlantType = "Creepers",
                FoodType = "Fruit",
                Quantity = 200,
                IsEdible = true
            };
            await plantsManager.AddAsync(newPlant);

            var secondNewPlant = new Plant()
            {
                CatalogNumber = "01HP01PRFDBK",
                Name = "Cucumber",
                PlantType = "Creepers",
                FoodType = "Vegetable",
                Quantity = 234,
                IsEdible = true
            };
            await plantsManager.AddAsync(secondNewPlant);
            // Act
            var result = await plantsManager.GetSpecificAsync("01HP01PRFDBK");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(result.Name, secondNewPlant.Name);
            Assert.AreEqual(result.PlantType, secondNewPlant.PlantType);
            Assert.AreEqual(result.FoodType, secondNewPlant.FoodType);
            Assert.AreEqual(result.Quantity, secondNewPlant.Quantity);
            Assert.AreEqual(result.IsEdible, secondNewPlant.IsEdible);
            Assert.AreEqual(result.CatalogNumber, secondNewPlant.CatalogNumber);
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidCatalogNumber_ShouldThrowKeyNotFoundException()
        {
            const string invalidCN = "NON_VALID_CN";

            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => plantsManager.GetSpecificAsync(invalidCN));

            Assert.That(exception.Message, Is.EqualTo($"No plant found with catalog number: {invalidCN}"));
        }

        [Test]
        public async Task UpdateAsync_WithValidPlant_ShouldUpdatePlant()
        {
            // Arrange
            var newPlant = new Plant()
            {
                CatalogNumber = "01HP01PRFC6E",
                Name = "Tomato",
                PlantType = "Creepers",
                FoodType = "Fruit",
                Quantity = 200,
                IsEdible = true
            };
            await plantsManager.AddAsync(newPlant);

            var secondNewPlant = new Plant()
            {
                CatalogNumber = "01HP01PRFDBK",
                Name = "Cucumber",
                PlantType = "Creepers",
                FoodType = "Vegetable",
                Quantity = 234,
                IsEdible = true
            };
            await plantsManager.AddAsync(secondNewPlant);

            var modPlant = newPlant;
            modPlant.Name = "UPDATED!";

            // Act
            await plantsManager.UpdateAsync(modPlant);

            // Assert
            var itemInDb = await dbContext.Plants.FirstOrDefaultAsync(x => x.CatalogNumber == modPlant.CatalogNumber);

            Assert.NotNull(itemInDb);
            Assert.AreEqual(itemInDb.Name, modPlant.Name);
            Assert.AreEqual(itemInDb.PlantType, modPlant.PlantType);
            Assert.AreEqual(itemInDb.FoodType, modPlant.FoodType);
            Assert.AreEqual(itemInDb.Quantity, modPlant.Quantity);
            Assert.AreEqual(itemInDb.IsEdible, modPlant.IsEdible);
            Assert.AreEqual(itemInDb.CatalogNumber, modPlant.CatalogNumber);

        }

        [Test]
        public async Task UpdateAsync_WithInvalidPlant_ShouldThrowValidationException()
        {
            var exception = Assert.ThrowsAsync<ValidationException>(() => plantsManager.UpdateAsync(new Plant()));

            Assert.That(exception.Message, Is.EqualTo("Invalid plant!"));
        }
    }
}
