using Demo_Project;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
//using System.Text.Json;

//WeatherForeceast weatherForecast = new WeatherForeceast()
//{
//    Date = DateTime.Now,
//    TemperatureC = 32,
//    Summary = "New Random Test Summary"
//};

//string weatherForeacastJSON = JsonSerializer.Serialize(weatherForecast);
//Console.WriteLine(weatherForeacastJSON); 

//WeatherForeceast weatherForecast = new WeatherForeceast()
//{
//    Date = DateTime.Now,
//    TemperatureC = 32,
//    Summary = "New Random Test Summary"
//};


//DefaultContractResolver contractResolver =
// new DefaultContractResolver()
// {
//     NamingStrategy = new SnakeCaseNamingStrategy()
// };
//var serialized = JsonConvert.SerializeObject(weatherForecast,
// new JsonSerializerSettings()
// {
//     ContractResolver = contractResolver,
//     Formatting = Formatting.Indented
// });
//Console.WriteLine(serialized);




//string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory) + "/../../../weatherForecast.json");

//var weatherForecaastObject = JsonSerializer.Deserialize<List<WeatherForeceast>>(jsonString);



//string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory) + "/../../../People.json");

//var person = new
//{
//    FirstName = string.Empty,
//    LastName = string.Empty,
//    JobTitle = string.Empty,
//};

//var weatherForecaastObject = JsonConvert.DeserializeAnonymousType(jsonString, person);

//string jsonString = File.ReadAllText(Path.Combine
//    (Environment.CurrentDirectory) + "/../../../weatherForecast.json");

//var person = JObject.Parse(jsonString);
//Console.WriteLine(person["firstName"]);

var json = JObject.Parse(@"{'products': [
 {'name': 'Fruits', 'products': ['apple', 'banana']},
 {'name': 'Vegetables', 'products': ['cucumber']}]}");
var products = json["products"].Select(t =>
 string.Format("{0} ({1})",
 t["name"],
 string.Join(", ", t["products"])
));
{ }