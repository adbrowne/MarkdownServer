namespace MarkPadServer.Tests.PageStoreTests
{
    using MarkPadServer.PageStore;

    using NUnit.Framework;

    [TestFixture]
    public class PageStoreAddFilesTests : PageStoreTestsBase
    {
        private FileSytemPageStore fileSytemPageStore;

        private const string TestFileContent = "file content";

        [SetUp]
        public void SetUp()
        {
            EnsureEmptyTestStore();

            this.fileSytemPageStore = new FileSytemPageStore(TestStoreName);
        }

        [TearDown]
        public void TearDown()
        {
            DeleteTestStore();
        }
 
        [Test]
        public void CanAddFile()
        {
            this.fileSytemPageStore.Add("Page2", TestFileContent);

            var fileListAfterAdd = this.fileSytemPageStore.ListPages();

            CollectionAssert.Contains(fileListAfterAdd, "Page2");
        }
        
        [Test]
        public void AddedFileHasCorrectContent()
        {
            this.fileSytemPageStore.Add("Page2", TestFileContent);

            var content = this.fileSytemPageStore.GetPageContent("Page2");

            Assert.AreEqual(TestFileContent, content);
        }
    }
}