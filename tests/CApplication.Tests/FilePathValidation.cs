using CApplication.Utils;

namespace CApplication.Tests
{
    public class FilePathValidation
    {
        [Fact]
        public void ValidateFilePath_InvalidPath_ThrowsException()
        {
            string invalidPath = "../../sensitive";

            Assert.Throws<InvalidOperationException>(
                () => UtilMethods.ValidateFilePath(invalidPath, "file.json")
            );
        }

        [Fact]
        public void ValidateFilePath_ValidPath_DoesNotThrow()
        {
            string validPath = Configuration.DATA_PATH;

            UtilMethods.ValidateFilePath(validPath, "test.json");
        }

        [Fact]
        public void ValidateFilePath_InvalidExtension_ThrowsException()
        {
            string filePath = Configuration.DATA_PATH;

            Assert.Throws<InvalidOperationException>(
                () => UtilMethods.ValidateFilePath(filePath, "file.txt")
            );
        }
    }
}