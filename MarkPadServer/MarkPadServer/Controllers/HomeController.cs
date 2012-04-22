using System.Web.Mvc;

namespace MarkPadServer.Controllers
{
    using MarkPadServer.PageStore;

    public class HomeController : Controller
    {
        private readonly IPageStore pageStore;

        public HomeController(IPageStore pageStore)
        {
            this.pageStore = pageStore;
        }

        public ActionResult Index()
        {
            return View(pageStore.ListPages());
        }
    }
}
