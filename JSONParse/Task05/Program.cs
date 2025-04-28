using System.Text.Json;
using Task05.Models;

//Парсинг массива JSON из файла
internal class Program
{
    private static void Main(string[] args)
    {
        var fileName = "person.json";
        var fileRootDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent?.Parent?.FullName;
        var filePath = Path.Combine(fileRootDirectory!, "Source", fileName);
        Console.WriteLine($"Ищем файл по пути: {filePath}");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        
        try
        {
            var json = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(json))
            {
                Console.WriteLine("Файл пуст или не найден");
                return;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true  
            };

            var persons = JsonSerializer.Deserialize<Person[]>(json, options);

            if (persons == null || persons.Length == 0)
            {
                Console.WriteLine("Нет данных для вывода");
                return;
            }

            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Id}: {p.Name}");
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}