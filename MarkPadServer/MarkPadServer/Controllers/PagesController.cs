using System.Web.Mvc;
using MarkdownDeep;

namespace MarkPadServer.Controllers
{
    public class PagesController : Controller
    {
        public ActionResult ViewPage(string name)
        {
            var markdown = new Markdown();
            using(var textStream = System.IO.File.OpenText(Server.MapPath("~/MdPages/" + name + ".md")))
            {
                var htmlResult = markdown.Transform(textStream.ReadToEnd());
                return Content(htmlResult);
            }
        }
    }
}
