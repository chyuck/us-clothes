using System.Web.Mvc;

namespace USClothesWebSite.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return RedirectToAction("Index");
        }
    }
}
