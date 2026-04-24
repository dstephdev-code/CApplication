using System.Text.Json.Serialization;

namespace CApplication.Models
{
    public class Student
    {
        public string Name { get; }
        public IReadOnlyList<int> Grades { get; }
        [JsonIgnore]
        public double AverageGrade => Grades.Average();

        [JsonConstructor]
        public Student(string name, IReadOnlyList<int> grades)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            ArgumentNullException.ThrowIfNull(grades);

            var gradesArray = grades.ToArray();

            if (gradesArray.Length == 0)
                throw new ArgumentException("Grades cannot be empty", nameof(grades));

            if (gradesArray.Any(g => g < 0 || g > 100))
                throw new ArgumentException("Grades must be between 0 and 100", nameof(grades));

            Name = name;
            Grades = gradesArray;
        }
    }
}
