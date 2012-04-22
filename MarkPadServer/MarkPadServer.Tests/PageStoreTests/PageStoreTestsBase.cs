namespace MarkPadServer.Tests.PageStoreTests
{
    using System.IO;

    public class PageStoreTestsBase
    {
        protected const string TestStoreName = @".\PageStore";
        const string TestFileLocation = @".\TestFiles";
        
        protected static void DeleteTestStore()
        {
            if (Directory.Exists(TestStoreName))
            {
                Directory.Delete(TestStoreName, true);
            }
        }

        protected static void EnsureEmptyTestStore()
        {
            DeleteTestStore();
            Directory.CreateDirectory(TestStoreName);
        }

        protected static void SetupPageStoreFile(string fileName)
        {
            File.Copy(Path.Combine(TestFileLocation, fileName), Path.Combine(TestStoreName,fileName));
        }
    }
}