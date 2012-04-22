namespace MarkPadServer.PageStore
{
    using System.Collections.Generic;

    public interface IPageStore
    {
        IEnumerable<string> ListPages();

        void Add(string name, string fileContent);

        string GetPageContent(string name);
    }
}