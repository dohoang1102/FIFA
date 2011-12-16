using System.Web.Mvc;

namespace Fifa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the Binary FIFA website!";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
