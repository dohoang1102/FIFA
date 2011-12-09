using System.Web.Mvc;

using Fifa.Core;

namespace Fifa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserService service = new UserService();
            service.LoadUsers();
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
