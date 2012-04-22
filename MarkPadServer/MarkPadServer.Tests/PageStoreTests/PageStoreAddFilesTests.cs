namespace MarkPadServer.Tests.PageStoreTests
{
    using MarkPadServer.PageStore;

    using NUnit.Framework;

    [TestFixture]
    public class PageStoreAddFilesTests : PageStoreTestsBase
    {
        private FileSystemPageStore fileSystemPageStore;

        private const string TestFileContent = "file content";

        [SetUp]
        public void SetUp()
        {
            EnsureEmptyTestStore();

            this.fileSystemPageStore = new FileSystemPageStore(TestStoreName);
        }

        [TearDown]
        public void TearDown()
        {
            DeleteTestStore();
        }
 
        [Test]
        public void CanAddFile()
        {
            this.fileSystemPageStore.Add("Page2", TestFileContent);

            var fileListAfterAdd = this.fileSystemPageStore.ListPages();

            CollectionAssert.Contains(fileListAfterAdd, "Page2");
        }
        
        [Test]
        public void AddedFileHasCorrectContent()
        {
            this.fileSystemPageStore.Add("Page2", TestFileContent);

            var content = this.fileSystemPageStore.GetPageContent("Page2");

            Assert.AreEqual(TestFileContent, content);
        }
    }
}