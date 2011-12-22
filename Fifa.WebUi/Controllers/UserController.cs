using System.Web.Mvc;

using Fifa.Core;
using Fifa.Core.Models;
using Fifa.Core.Services;
using Fifa.Models;

namespace Fifa.WebUi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            var users = userService.GetAllUsers();
            return View(users);
        }

        public ActionResult Create()
        {
            var user = userService.CreateUser();
            return View("Edit", user);
        }

        public ActionResult Edit(int id)
        {
            var user = userService.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userService.SaveUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            var user = userService.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {
            if (ModelState.IsValid)
            {
                userService.DeleteUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
