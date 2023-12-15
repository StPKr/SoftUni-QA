using System;

using Animals.Models;

Console.WriteLine("Uncomment Code");
Animal cat = new Cat("Peter", "Whiskas");
Animal dog = new Dog("George", "Meat");

Console.WriteLine(cat.ExplainSelf());
Console.WriteLine(dog.ExplainSelf());
