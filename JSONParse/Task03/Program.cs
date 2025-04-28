using System.Text.Json;

//Динамический парсинг JSON из файла (без классов)
internal class Program
{
    private static void Main(string[] args)
    {
        string? fileName = "person.json";
        string? rootDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName!;
        string? filePath = Path.Combine(rootDirectory, "Source", fileName);

        string? json = File.ReadAllText(filePath);

        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        string name = root.GetProperty("name").GetString()!;
        int age = root.GetProperty("age").GetInt32()!;
        string country = root.GetProperty("address").GetProperty("country").GetString()!;
        string city = root.GetProperty("address").GetProperty("city").GetString()!;
        var skills = root.GetProperty("skills").EnumerateArray().Select(s => s.GetString()).ToList()!;

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Country: {country}");
        Console.WriteLine($"City: {city}");
        Console.WriteLine($"Skills: {string.Join(", ", skills)}");
    }
}