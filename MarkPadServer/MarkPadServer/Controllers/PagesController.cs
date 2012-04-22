using System.Web.Mvc;

namespace MarkPadServer.Controllers
{
    using MarkPadServer.PageStore;

    public class PagesController : Controller
    {
        private readonly IPageStore pageStore;

        public PagesController(IPageStore pageStore)
        {
            this.pageStore = pageStore;
        }

        public ActionResult ViewPage(string name)
        {
            /* var markdown = new Markdown();
            using(var textStream = System.IO.File.OpenText(Server.MapPath("~/MdPages/" + name + ".md")))
            {
                var htmlResult = markdown.Transform(textStream.ReadToEnd());
                return View(htmlResult);
            } */
            var content = pageStore.GetPageContent(name);
            return this.View((object)content);
        }
    }
}
