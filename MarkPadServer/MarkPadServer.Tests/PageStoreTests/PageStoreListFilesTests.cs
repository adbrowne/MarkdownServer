namespace MarkPadServer.Tests.PageStoreTests
{
    using System.Collections.Generic;
    using System.Linq;

    using MarkPadServer.Storage;

    using NUnit.Framework;

    [TestFixture]
    public class PageStoreListFilesTests : PageStoreTestsBase
    {
        private PageStore pageStore;

        private IEnumerable<string> files;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            EnsureEmptyTestStore();

            SetupPageStoreFile("NotAPage.txt");
            SetupPageStoreFile("Page1.md");

            this.pageStore = new PageStore(TestStoreName);
            this.files = this.pageStore.GetPages();
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