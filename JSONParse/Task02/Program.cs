using System.Text.Json;
using Task01.Modules;
using Newtonsoft.Json;

internal class Program
{
    //Парсинг JSON из файла с Newtonsoft.Json
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


            Person person = JsonConvert.DeserializeObject<Person>(json)!;

            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Country: {person.Address?.Country}");
            Console.WriteLine($"City: {person.Address?.City}");
            Console.WriteLine($"Skills: {(person.Skills != null ? string.Join(", ", person.Skills) : "No skills")}");
        }
        catch (Newtonsoft.Json.JsonException ex)
        {
            Console.WriteLine($"Ошибка в формате JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}