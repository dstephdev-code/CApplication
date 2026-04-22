using CApplication.Models;

namespace CApplication.Repositories
{
    internal class TestDataStudentRepository : IStudentRepository
    {
        public Task<List<Student>> LoadAsync()
        {
            return Task.FromResult(new List<Student>
            {
                new("Sophia", new[] { 93, 87, 98, 95, 100 }),
                new("Nicolas", new[] { 80, 83, 82, 88, 85 }),
                new("Zahirah", new[] { 84, 96, 73, 85, 79 }),
                new("Jeong", new[] { 90, 92, 98, 100, 97 })
            });
        }

        public Task SaveAsync(List<Student> students) => Task.CompletedTask;
    }
}
