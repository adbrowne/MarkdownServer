namespace MarkPadServer.Tests.PageStoreTests
{
    using System.Collections.Generic;
    using System.Linq;

    using MarkPadServer.PageStore;

    using NUnit.Framework;

    [TestFixture]
    public class PageStoreListFilesTests : PageStoreTestsBase
    {
        private FileSytemPageStore fileSytemPageStore;

        private IEnumerable<string> files;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            EnsureEmptyTestStore();

            SetupPageStoreFile("NotAPage.txt");
            SetupPageStoreFile("Page1.md");

            this.fileSytemPageStore = new FileSytemPageStore(TestStoreName);
            this.files = this.fileSytemPageStore.ListPages();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            DeleteTestStore();
        }

        [Test]
        public void WillOnlyListMdFiles()
        {
            Assert.That(this.files.Count(), Is.EqualTo(1));
        }
        
        [Test]
        public void ListsFileWithoutExtension()
        {
            Assert.That(this.files.First(), Is.EqualTo("Page1"));
        }

    }
}