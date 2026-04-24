namespace CApplication.Utils
{
    public static class UtilMethods
    {
        public static void ValidateFilePath(string filePath, string fileName)
        {
            System.Diagnostics.Debug.WriteLine($"Валидация пути: {filePath}/{fileName}");

            string baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Configuration.DATA_PATH);
            string fullPath = Path.GetFullPath(Path.Combine(filePath, fileName));
            string fullBasePath = Path.GetFullPath(baseDirectory);

            if (!fullPath.StartsWith(fullBasePath, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException($"Доступ запрещён: {fullPath}");

            if (Path.GetExtension(fileName) != ".json")
                throw new ArgumentException($"Разрешены только JSON файлы");
        }
    }
}
