using CApplication.Models;

namespace CApplication.Repositories
{
    /// <summary>
    /// Интерфейс для работы с хранилищем студентов.
    /// </summary>
    internal interface IStudentRepository
    {
        /// <summary>
        /// Загружает список студентов асинхронно.
        /// </summary>
        /// <returns>Список студентов или пустой список.</returns>
        Task<List<Student>> LoadAsync();
        /// <summary>
        /// Сохраняет студентов асинхронно.
        /// </summary>
        /// <param name="students">Список студентов для сохранения.</param>
        Task SaveAsync(List<Student> students);
    }
}
