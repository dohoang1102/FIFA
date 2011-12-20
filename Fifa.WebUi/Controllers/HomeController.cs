using System.Web.Mvc;

namespace Fifa.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Log()
        {
            return View((object)System.IO.File.ReadAllText(Server.MapPath("~/fifa.log")));
        }
    }
}
