using CApplication.Models;
using CApplication.Utils;
using System.Text.Json;

namespace CApplication.Repositories
{
    public class JsonStudentRepository : IStudentRepository
    {
        private readonly string _filePath;

        public JsonStudentRepository(string filePath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be empty", nameof(filePath));
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name cannot be empty", nameof(fileName));

            UtilMethods.ValidateFilePath(filePath, fileName);

            _filePath = Path.Combine(filePath, fileName);
        }

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        public async Task<List<Student>> LoadAsync()
        {
            string json = await File.ReadAllTextAsync(_filePath);

            var students = JsonSerializer.Deserialize<List<Student>>(json, JsonOptions);

            return students is null ? throw new InvalidOperationException("Failed to deserialize students") : students;
        }
        public async Task SaveAsync(List<Student> students)
        {
            ArgumentNullException.ThrowIfNull(students);

            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory!);

            string json = JsonSerializer.Serialize(students, JsonOptions);
            await File.WriteAllTextAsync(_filePath, json);           
        }
    }
}
