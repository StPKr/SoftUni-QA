using System.Reflection;
using System.Text.Json;
using JsonParser.Models;

namespace JsonParser
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseSpecies();
        }

        

        // Parses and displays species data
        private static void ParseSpecies()
        {
            string jsonFilePath = Path.Combine("Datasets", "Species.json");
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                List<Species>? species = JsonSerializer.Deserialize<List<Species>>(json);
                DisplaySpecies(species);
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }



        // Displays the list of species
        private static void DisplaySpecies(List<Species>? species)
        {
            if (species == null)
            {
                Console.WriteLine("No species data found or data is not in the expected format.");
                return;
            }

            Console.WriteLine("Animals:");
            int speciesNumber = 1;
            foreach (var animal in species)
            {
                Console.WriteLine($"Animal #{speciesNumber}");
                Console.WriteLine($"ID: {animal.SpeciesId} Name: {animal.SpeciesName}");
                Console.WriteLine($"Habitat: {animal.Habitat}, Lifespan: {animal.Lifespan}");
                string habits = string.Join(", ", animal.Habits.Diet);
                Console.WriteLine($"Diet: {habits}, Migration: {animal.Habits.Migration}");

                speciesNumber++;
            }
        }

        // Handles errors that occur during JSON parsing
        private static void HandleError(Exception e)
        {
            if (e is JsonException)
            {
                Console.WriteLine($"JSON Parsing Error: {e.Message}");
            }
            else
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
            }
        }
    }
}