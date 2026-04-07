namespace CApplication.Utils
{
    internal static class UtilMethods
    {
        internal static float CalculateAverage(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return (float)sum / array.Length;
        }
        internal static void ValidateFilePath(string filePath, string fileName)
        {
            System.Diagnostics.Debug.WriteLine($"Валидация пути: {filePath}/{fileName}");

            string baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Configuration.DATA_PATH);
            string fullPath = Path.GetFullPath(Path.Combine(filePath, fileName));
            string fullBasePath = Path.GetFullPath(baseDirectory);

            if (!fullPath.StartsWith(fullBasePath, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Доступ запрещён: {fullPath}");

            if (Path.GetExtension(fileName) != ".json")
                throw new InvalidOperationException($"Разрешены только JSON файлы");
        }
    }
}
