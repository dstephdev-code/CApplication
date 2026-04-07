using CApplication.Models;
using CApplication.Utils;
using System.Text.Json;

namespace CApplication.Repositories
{
    internal class JsonStudentRepository : IStudentRepository
    {
        private readonly string _filePath;

        internal JsonStudentRepository(string filePath, string fileName)
        {
            try
            { 
                UtilMethods.ValidateFilePath(filePath, fileName); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                throw;
            }
            _filePath = Path.Combine(filePath, fileName);
        }

        private readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            IgnoreReadOnlyProperties = true
        };
        public async Task<List<Student>> LoadAsync()
        {
            try
            {
                string json = await File.ReadAllTextAsync(_filePath);
                return JsonSerializer.Deserialize<List<Student>>(json, JsonOptions) ?? [];
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файл не найден: {ex.Message}");
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                throw;
            }
        }
        public async Task SaveAsync(List<Student> students)
        {
            try
            {
                if (!Directory.Exists(_filePath[.._filePath.LastIndexOf(Path.DirectorySeparatorChar)]))
                    Directory.CreateDirectory(_filePath[.._filePath.LastIndexOf(Path.DirectorySeparatorChar)]);

                string json = JsonSerializer.Serialize<List<Student>>(students, JsonOptions);
                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Нет прав доступа: {ex.Message}");
                throw;
            }            
        }
    }
}
