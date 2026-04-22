using CApplication.Utils;
using System.Diagnostics.CodeAnalysis;

namespace CApplication.Models
{
    internal class Student
    {
        public required string Name { get; set; }
        public required int[] Grades { get; set; }
        public float AverageGrade => UtilMethods.CalculateAverage(Grades);

        public Student()
        {
        }

        [SetsRequiredMembers]
        public Student(string _name, int[] _grades)
        {
            Name = _name;
            Grades = new int[_grades.Length];
            Array.Copy(_grades, Grades, _grades.Length);
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Grades?.Length > 0 && Grades.All(g => g >= 0 && g <= 100);
        }
    }
}
