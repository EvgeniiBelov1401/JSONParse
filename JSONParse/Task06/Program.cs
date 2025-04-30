using System.Text.Json;
using System.Text.Json.Serialization;
using Task06.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var employees = new List<Employee>
        {
            new Employee()
            {
                Id = 1,
                Name = "Иван Иванов",
                Position = "Разработчик",
                HireDate = new DateOnly(2020, 5, 15),
                Salary = 150000,
                Skills = new List<string> { "C#", "SQL", "ASP.NET" },
                Contacts = new Dictionary<string, string>
                {
                    { "email", "ivan@company.com" },
                    { "phone", "+7 999 123-45-67" }
                },
                IsActive = true
            },
            new Employee()
            {
                Id = 2,
                Name = "Анна Анина",
                Position = "Тестировщик",
                HireDate = new DateOnly(2021, 3, 10),
                Salary = 120000,
                Skills = new List<string> { "QA", "Automation", "Selenium" },
                Contacts = new Dictionary<string, string>
                {
                    { "email", "anna@company.com" },
                    { "phone", "+7 987 654-32-10" }
                },
                IsActive = true
            }
        };

        var department = new Department()
        {
            Name = "IT-Отдел",
            Employees = employees,
            Budget = 5000000
        };

        var options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() }
        };

        string? jsonString = JsonSerializer.Serialize(department, options);

        string? fileName = $"SerializableFile_{DateTime.Now:yyyyMMdd_HHmm}.json";
        string? folderPath = Path.Combine(Directory.GetCurrentDirectory(), "JSONs");
        string? filePath = Path.Combine(folderPath, fileName);

        try
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Папка создана: {folderPath}");
            }
            else
            {
                Console.WriteLine($"Текущая папка: {folderPath}");
            }

            File.WriteAllText(filePath, jsonString);
            Console.WriteLine($"Файл записан в {filePath}");
    
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}