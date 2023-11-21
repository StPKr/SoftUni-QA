using _00._Demo1;

Dog puppy = new Dog()
{
    Name = "Sparky",
    Breed = "Corgi",
    Age = 3
};

Dog friend = new Dog();
friend.Name = "Ivan";
friend.Breed = "Unknown";
friend.Age = 3;

Dog dog = new Dog();

Dog dog2 = new Dog("John", "Shiba Inu");

Dog dog3 = new Dog("Bibi", "Golden Retriever", 5);


Console.WriteLine(puppy.Name);
Console.WriteLine(puppy.Age);

Console.WriteLine(dog.Name);
Console.WriteLine(dog.Age);

Console.WriteLine(dog2.Name);
Console.WriteLine(dog2.Age);

Console.WriteLine(dog3.Name);
Console.WriteLine(dog3.Age);