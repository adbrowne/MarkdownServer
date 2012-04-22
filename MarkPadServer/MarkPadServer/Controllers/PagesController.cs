using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkdownDeep;
using System.IO;

namespace MarkPadServer.Controllers
{
    public class PagesController : Controller
    {
        public ActionResult View(string name)
        {
            Markdown markdown = new Markdown();
            using(var textStream = System.IO.File.OpenText(Server.MapPath("~/MdPages/" + name + ".md")))
            {
                var htmlResult = markdown.Transform(textStream.ReadToEnd());
                return Content(htmlResult);
            }
        }
    }
}
