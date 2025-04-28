using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

internal class Program
{
    //Динамический парсинг JSON из файла(без классов) Через Newtonsoft.Json
    private static void Main(string[] args)
    {

        var fileName = "person.json";
        var fileRootDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent?.Parent?.FullName;
        var filePath = Path.Combine(fileRootDirectory!, "Source", fileName);

        var json = File.ReadAllText(filePath);

        JObject obj = JObject.Parse(json);
        var name = (string)obj["name"]!;
        var age = (int)obj["age"]!;
        var country = (string)obj["address"]!["country"]!;
        var city = (string)obj["address"]!["city"]!;
        JArray skills = (JArray)obj["skills"]!;

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Country: {country}");
        Console.WriteLine($"City: {city}");
        Console.WriteLine($"Skills: {string.Join(", ",skills)}");
    }

}