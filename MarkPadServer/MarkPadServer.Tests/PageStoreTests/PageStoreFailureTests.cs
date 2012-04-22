namespace MarkPadServer.Tests.PageStoreTests
{
    using System.IO;

    using MarkPadServer.Storage;

    using NUnit.Framework;

    [TestFixture]
    public class PageStoreFailureTests
    {
        [Test]
        public void WillThrowDirectoryNotFoundIfLocationDoesNotExist()
        {
            Assert.Throws<DirectoryNotFoundException>(() => new PageStore(@"not existant directory name"));
        }
    }
}