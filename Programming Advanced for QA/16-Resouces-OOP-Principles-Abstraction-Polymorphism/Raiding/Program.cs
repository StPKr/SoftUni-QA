using System;
using System.Collections.Generic;
using System.Linq;

using Raiding.Contracts;

Console.WriteLine("Uncomment Code");
// List<IHero> heroes = new();
//
// int n = int.Parse(Console.ReadLine()!);
// while (n > 0)
// {
//     try
//     {
//         heroes.Add(CreateHero());
//         n--;
//     }
//     catch (ArgumentException ex)
//     {
//         Console.WriteLine(ex.Message);
//     }
// }
//
// int bossPower = int.Parse(Console.ReadLine()!);
// int heroesPower = heroes.Sum(hero => hero.Power);
// heroes.ForEach(hero => Console.WriteLine(hero.CastAbility()));
// Console.WriteLine(heroesPower >= bossPower ? "Victory!" : "Defeat...");
//
// static IHero CreateHero()
// {
//     string name = Console.ReadLine()!;
//     string type = Console.ReadLine()!;
//
//      IHero hero = type switch
//      {
//          "Druid" => new Druid(name),
//          "Paladin" => new Paladin(name),
//          "Rogue" => new Rogue(name),
//          "Warrior" => new Warrior(name),
//          _ => throw new ArgumentException("Invalid hero!"),
//      };
//
//     return hero;
// }
