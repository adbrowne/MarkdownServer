namespace MarkPadServer.PageStore
{
    using System.Collections.Generic;

    using MarkdownDeep;

    public class MarkDownPageStore : IPageStore
    {
        private readonly IPageStore pageStore;

        static readonly Markdown Markdown = new Markdown();
        public MarkDownPageStore(IPageStore pageStore)
        {
            this.pageStore = pageStore;
        }

        public IEnumerable<string> ListPages()
        {
            return pageStore.ListPages();
        }

        public void Add(string name, string fileContent)
        {
            pageStore.Add(name, fileContent);
        }

        public string GetPageContent(string name)
        {
            return Markdown.Transform(this.pageStore.GetPageContent(name));
        }
    }
}