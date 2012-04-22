namespace MarkPadServer.Tests
{
    using MarkPadServer.PageStore;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class MarkpadPageStoreTests
    {
        [Test]
        public void GetPageContentTransforms()
        {
            var pageStore = Substitute.For<IPageStore>();
            const string TestPageName = "TestPage";
            pageStore.GetPageContent(TestPageName).Returns("test content");
            var markdownPageStore = new MarkDownPageStore(pageStore);

            var content = markdownPageStore.GetPageContent(TestPageName);

            Assert.That(content, Is.EqualTo("<p>test content</p>\n"));
        }
    }
}