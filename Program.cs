using CApplication.Repositories;

namespace CApplication
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //IStudentRepository repository = new TestDataStudentRepository();
            JsonStudentRepository repository = new(Configuration.DATA_PATH, Configuration.STUDENTS_DATAFILE_NAME);
            var students = await repository.LoadAsync();
            if (students.Count == 0)
            {
                Console.WriteLine("Студенты не найдены.");
            } else
            {
                Console.WriteLine($"Загружено студентов: {students.Count}");
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Name}: {student.AverageGrade:F2}");
                }
                await repository.SaveAsync(students);
                Console.WriteLine($@"Данные сохранены в {Configuration.DATA_PATH}/{Configuration.STUDENTS_DATAFILE_NAME}");
            }

            Console.Write("Нажмите любую кнопку для закрытия...");
            Console.ReadKey();
        }
    }
}