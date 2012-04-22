namespace MarkPadServer.Tests.PageStoreTests
{
    using System.IO;

    using MarkPadServer.PageStore;

    using NUnit.Framework;

    [TestFixture]
    public class PageStoreFailureTests
    {
        [Test]
        public void WillThrowDirectoryNotFoundIfLocationDoesNotExist()
        {
            Assert.Throws<DirectoryNotFoundException>(() => new FileSystemPageStore(@"not existant directory name"));
        }
    }
}