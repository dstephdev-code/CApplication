using CApplication.Repositories;
using CApplication.Models;
using System.Text.Json;

namespace CApplication.Tests
{
    public class JsonStudentRepositoryTests : IDisposable
    {
        private readonly string _testDir;

        public JsonStudentRepositoryTests()
        {
            _testDir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                Configuration.DATA_PATH,
                "TestFiles",
                Guid.NewGuid().ToString()
            );

            Directory.CreateDirectory(_testDir);
        }

        public void Dispose()
        {
            if (Directory.Exists(_testDir))
                Directory.Delete(_testDir, recursive: true);
        }

        private string CreateTempJsonFile(string content)
        {
            var fileName = $"{Guid.NewGuid()}.json";
            var fullPath = Path.Combine(_testDir, fileName);

            File.WriteAllText(fullPath, content);

            return fileName;
        }

        [Fact]
        public async Task LoadAsync_ShouldReturnStudents_WhenJsonValid()
        {
            var json = """
                [
                    { "name": "Alex", "grades": [80, 90] }
                ]
                """;

            var fileName = CreateTempJsonFile(json);

            var repo = new JsonStudentRepository(_testDir, fileName);

            var students = await repo.LoadAsync();

            Assert.Single(students);
            Assert.Equal("Alex", students[0].Name);
            Assert.Equal(85, students[0].AverageGrade);
        }

        [Fact]
        public async Task LoadAsync_ShouldThrowException_WhenFileDoesNotExist()
        {
            var repo = new JsonStudentRepository(_testDir, $"{Guid.NewGuid()}.json");

            await Assert.ThrowsAsync<FileNotFoundException>(() => repo.LoadAsync());
        }

        [Fact]
        public async Task LoadAsync_ShouldThrowException_WhenJsonIsInvalid()
        {
            var fileName = CreateTempJsonFile("invalid json");

            var repo = new JsonStudentRepository(_testDir, fileName);

            await Assert.ThrowsAsync<JsonException>(() => repo.LoadAsync());
        }

        [Fact]
        public async Task SaveAsync_ShouldCreateFile()
        {
            var fileName = $"{Guid.NewGuid()}.json";
            var fullPath = Path.Combine(_testDir, fileName);
            var repo = new JsonStudentRepository(_testDir, fileName);

            var students = new List<Student>
            {
                new("Alex", [80, 90])
            };

            await repo.SaveAsync(students);

            Assert.True(File.Exists(fullPath));
        }

        [Fact]
        public async Task SaveAndLoad_ShouldPreserveData()
        {
            var fileName = $"{Guid.NewGuid()}.json";
            var repo = new JsonStudentRepository(_testDir, fileName);

            var students = new List<Student>
            {
                new("Alex", [80, 90])
            };

            await repo.SaveAsync(students);
            var loaded = await repo.LoadAsync();

            Assert.Single(loaded);
            Assert.Equal("Alex", loaded[0].Name);
            Assert.Equal(85, loaded[0].AverageGrade);
        }

        [Fact]
        public async Task SaveAsync_ShouldThrowException_IfStudentsAreNull()
        {
            var fileName = $"{Guid.NewGuid()}.json";
            var repo = new JsonStudentRepository(_testDir, fileName);

            await Assert.ThrowsAsync<ArgumentNullException>(() => repo.SaveAsync(null!));
        }
    }
}
