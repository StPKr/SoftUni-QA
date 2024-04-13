using GardenConsoleAPI.Business.Contracts;
using GardenConsoleAPI.Data.Models;

namespace GardenConsoleAPI.Business
{
    public class Engine : IEngine
    {
        public async Task Run(IPlantsManager plantsManager)
        {
            bool exitRequested = false;
            while (!exitRequested)
            {
                Console.WriteLine($"{Environment.NewLine}Choose an option:");
                Console.WriteLine("1: Add Plant");
                Console.WriteLine("2: Delete Plant");
                Console.WriteLine("3: List All Plants");
                Console.WriteLine("4: Update Plant");
                Console.WriteLine("5: Find Plant by Food Type");
                Console.WriteLine("X: Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await AddPlant(plantsManager);
                        break;
                    case "2":
                        await DeletePlant(plantsManager);
                        break;
                    case "3":
                        await ListAllPlants(plantsManager);
                        break;
                    case "4":
                        await UpdatePlant(plantsManager);
                        break;
                    case "5":
                        await FindPlantByFoodType(plantsManager);
                        break;
                    case "X":
                    case "x":
                        exitRequested = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                static async Task AddPlant(IPlantsManager plantsManager)
                {
                    Console.WriteLine("Adding a new Plant:");

                    Console.Write("Enter Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Enter Plant Type: ");
                    var plantType = Console.ReadLine();

                    Console.Write("Enter Food Type: ");
                    var foodType = Console.ReadLine();


                    Console.Write("Enter Quantity: ");
                    var quantity = int.Parse(Console.ReadLine());

                    Console.Write("Is edible? (write 'yes' for edible or any other value for inedible): ");
                    var status = Console.ReadLine();

                    var isEdible = false;
                    if (status.ToLower() == "yes")
                    {
                        isEdible = true;
                    }
                    else
                    {
                        isEdible = false;
                    }


                    Console.Write("Enter Catalog Number: ");
                    var catalogNumber = Console.ReadLine();

                    var newPlant = new Plant
                    {
                        PlantType = plantType,
                        CatalogNumber = catalogNumber,
                        IsEdible = isEdible,
                        Name = name,
                        FoodType = foodType,
                        Quantity = quantity
                    };

                    await plantsManager.AddAsync(newPlant);
                    Console.WriteLine("Plant added successfully.");
                }

                static async Task DeletePlant(IPlantsManager plantsManager)
                {
                    Console.Write("Enter Catalog Number to delete Plant: ");
                    string catalogNumber = Console.ReadLine();
                    await plantsManager.DeleteAsync(catalogNumber);
                    Console.WriteLine("Plant deleted successfully.");
                }

                static async Task ListAllPlants(IPlantsManager plantsManager)
                {
                    var plants = await plantsManager.GetAllAsync();
                    if (plants.Any())
                    {
                        foreach (var plant in plants)
                        {
                            Console.WriteLine($"Catalog number: {plant.CatalogNumber}, Name: {plant.Name}, Quanity: {plant.Quantity}, Food type: {plant.FoodType}, Plant type: {plant.PlantType}, Edible: {(plant.IsEdible ? "yes" : "no")}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No such an plant.");
                    }
                }

                static async Task UpdatePlant(IPlantsManager plantsManager)
                {
                    Console.Write("Enter catalog number of the plant to update: ");
                    string catalogNumber = Console.ReadLine();
                    var plantToUpdate = await plantsManager.GetSpecificAsync(catalogNumber);
                    if (plantToUpdate == null)
                    {
                        Console.WriteLine("Plant not found.");
                        return;
                    }

                    Console.Write("Enter new Name (leave blank to keep current): ");
                    var name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        plantToUpdate.Name = name;
                    }

                    Console.Write("Enter new food type (leave blank to keep current): ");
                    var foodType = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(foodType))
                    {
                        plantToUpdate.FoodType = foodType;
                    }

                    Console.Write("Enter new Plant type (leave blank to keep current): ");
                    var plantType = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(plantType))
                    {
                        plantToUpdate.PlantType = plantType;
                    }

                    Console.Write("Enter new Quantity (leave blank to keep current): ");

                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        plantToUpdate.Quantity = quantity;
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity value! It will keep current value.");
                    }

                    Console.Write("Is Plant edible? (enter 'yes', 'no' or leave blank to keep current): ");
                    var status = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(status))
                    {
                        if (status.ToLower() == "yes")
                        {
                            plantToUpdate.IsEdible = true;
                        }
                        else if (status.ToLower() == "no")
                        {
                            plantToUpdate.IsEdible = false;
                        }

                    }

                    await plantsManager.UpdateAsync(plantToUpdate);
                    Console.WriteLine("Plant updated successfully.");
                }

                static async Task FindPlantByFoodType(IPlantsManager plantsManager)
                {
                    Console.Write("Enter Food type of the plant: ");
                    string foodType = Console.ReadLine();
                    var plants = await plantsManager.SearchByFoodTypeAsync(foodType);

                    if (plants.Any())
                    {
                        foreach (var plant in plants)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Name: {plant.Name}, Food type: {plant.FoodType}, Plant type: {plant.PlantType}");
                            Console.WriteLine($"--Quantity: {plant.Quantity}");
                            Console.WriteLine($"---Edible: {(plant.IsEdible ? "yes" : "no")}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No plant found with the given food type.");
                    }
                }
            }
        }
    }
}
