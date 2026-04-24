using CApplication.Models;
using System.Text.Json;

namespace CApplication.Tests
{
    public class StudentsClassValidation
    {
        [Fact]
        public void Constructor_ShouldCreateStudent_WhenDataIsValid()
        {
            var student = new Student("Alex", [80, 90]);

            Assert.Equal("Alex", student.Name);
            Assert.Equal(2, student.Grades.Count);
        }
        [Fact]
        public void Constructor_ShouldThrowException_WhenNameIsNull()
        {
            Assert.Throws<ArgumentException>(() => 
                new Student(null!, [80, 90])
            );
        }
        [Fact]
        public void Constructor_ShouldThrowException_WhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                new Student("", [80, 90])
            );
        }
        [Fact]
        public void Constructor_ShouldThrowException_WhenGradesAreNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Student("Alex", null!)
            );
        }
        [Fact]
        public void Constructor_ShouldThrowException_WhenGradesAreEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                new Student("Alex", [])
            );
        }
        [Fact]
        public void Constructor_ShouldThrowException_WhenGradesOutOfRange()
        {
            Assert.Throws<ArgumentException>(() =>
                new Student("Alex", [-1, 50, 101])
            );
        }
        [Fact]
        public void AverageGrade_ShouldBeCalculatedCorrectly()
        {
            var student = new Student("Alex", [80, 90]);

            Assert.Equal(85, student.AverageGrade);
        }
        [Fact]
        public void Grades_ShouldNotChange_WhenOriginalArrayModified()
        {
            var grades = new[] {80, 90};
            var student = new Student("Alex", grades);

            grades[0] = 70;

            Assert.Equal(80, student.Grades[0]);
        }
        [Fact]
        public void Serialization_ShouldWorkCorrectly()
        {
            var student = new Student("Alex", [80, 90]);

            var json = JsonSerializer.Serialize(student);
            var deserialized = JsonSerializer.Deserialize<Student>(json);

            Assert.Equal(student.Name, deserialized!.Name);
            Assert.Equal(student.AverageGrade, deserialized.AverageGrade);
        }

    }
}
