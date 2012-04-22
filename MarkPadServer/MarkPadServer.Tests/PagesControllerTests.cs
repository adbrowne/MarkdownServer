namespace MarkPadServer.Tests
{
    using System.Web.Mvc;

    using MarkPadServer.Controllers;
    using MarkPadServer.PageStore;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class PagesControllerTests
    {
        private PagesController pageController;

        private const string TestPageName = "testpage";

        private const string TestPageContent = "test page content";

        [SetUp]
        public void SetUp()
        {
            var pageStore = Substitute.For<IPageStore>();
            pageStore.GetPageContent(TestPageName).Returns(TestPageContent);
            this.pageController = new PagesController(pageStore);
        }

        [Test]
        public void ViewPageReturnsView()
        {
            var result = pageController.ViewPage(TestPageName);

            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void ViewPageReturnsContentToView()
        {
            var result = pageController.ViewPage(TestPageName) as ViewResult;

            Assert.That(result.Model, Is.EqualTo(TestPageContent));
        }
    }
}