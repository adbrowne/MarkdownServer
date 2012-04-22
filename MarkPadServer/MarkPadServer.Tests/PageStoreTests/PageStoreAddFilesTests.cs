namespace MarkPadServer.Tests.PageStoreTests
{
    using MarkPadServer.Storage;

    using NUnit.Framework;

    [TestFixture]
    public class PageStoreAddFilesTests : PageStoreTestsBase
    {
        private PageStore pageStore;

        private const string TestFileContent = "file content";

        [SetUp]
        public void SetUp()
        {
            EnsureEmptyTestStore();

            this.pageStore = new PageStore(TestStoreName);
        }

        [TearDown]
        public void TearDown()
        {
            DeleteTestStore();
        }
 
        [Test]
        public void CanAddFile()
        {
            this.pageStore.Add("Page2", TestFileContent);

            var fileListAfterAdd = this.pageStore.GetPages();

            CollectionAssert.Contains(fileListAfterAdd, "Page2");
        }
        
        [Test]
        public void AddedFileHasCorrectContent()
        {
            this.pageStore.Add("Page2", TestFileContent);

            var content = this.pageStore.GetContent("Page2");

            Assert.AreEqual(TestFileContent, content);
        }
    }
}