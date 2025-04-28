using System.Text.Json;
using Task01.Modules;

internal class Program
{
    //Парсинг JSON из файла с System.Text.Json
    private static void Main(string[] args)
    {
        string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName!;
        string filePath = Path.Combine(projectRoot, "Source", "person.json");
        Console.WriteLine($"Ищем файл по пути: {filePath}");

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл person.json не найден!");
                return;
            }

            string? json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true 
            };

            Person person = JsonSerializer.Deserialize<Person>(json, options)!;

            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Country: {person.Address?.Country}");
            Console.WriteLine($"City: {person.Address?.City}");
            Console.WriteLine($"Skills: {(person.Skills != null ? string.Join(", ", person.Skills) : "No skills")}");
        }
        catch(JsonException ex)
        {
            Console.WriteLine($"Ошибка в формате JSON: {ex.Message}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}