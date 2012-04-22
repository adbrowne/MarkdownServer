namespace MarkPadServer.PageStore
{
    using MarkdownDeep;

    public class MarkDownPageStore
    {
        private readonly IPageStore pageStore;

        static readonly Markdown Markdown = new Markdown();
        public MarkDownPageStore(IPageStore pageStore)
        {
            this.pageStore = pageStore;
        }

        public string GetPageContent(string name)
        {
            return Markdown.Transform(this.pageStore.GetPageContent(name));
        }
    }
}