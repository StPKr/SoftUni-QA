using System.Reflection;

namespace _04._Vehicle_Catalogue
{
    public class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }


    }

    public class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public decimal PriceForABox { get; set; }
    }

    public class Catalog
    {

        public Catalog()
        {
            Cars = new List<Car>();
        }
        public List<Truck> Trucks { get; set; } = new List<Truck>(); // or with empty constructor as done for Cars
        public List<Car> Cars { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Catalog catalog = new Catalog();

            while (command != "end")
            {
                string[] data = command.Split("/");
                string type = data[0];
                string brand = data[1];
                string model = data[2];
                int value = int.Parse(data[3]);

                if (type == "Truck")
                {
                    Truck currentTruck = new Truck(brand, model, value);
                    catalog.Trucks.Add(currentTruck);
                }
                else
                {
                    Car currentCar = new Car(brand, model, value);
                    catalog.Cars.Add(currentCar);
                }

                command = Console.ReadLine();
            }

            if (catalog.Cars.Count > 0)
            {
                List<Car> orderedCars = catalog.Cars.OrderBy(x => x.Brand).ToList();
                Console.WriteLine("Cars:");
                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalog.Trucks.Any()) // same as .Count > 0
            {
                List<Truck> orderedTrucks = catalog.Trucks.OrderBy(x => x.Brand).ToList();
                Console.WriteLine("Trucks:");
                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }


        }
    }
}