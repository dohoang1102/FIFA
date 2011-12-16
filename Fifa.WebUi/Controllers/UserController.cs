using System.Web.Mvc;

using Fifa.Core;
using Fifa.Models;

namespace Fifa.WebUi.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var users = UserService.GetAllUsers();
            return View(users);
        }

        public ActionResult Create()
        {
            var user = UserService.CreateUser();
            return View("Edit", user);
        }

        public ActionResult Edit(int id)
        {
            var user = UserService.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                if (UserService.SaveTeam(user))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            var user = UserService.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {
            if (ModelState.IsValid)
            {
                if (UserService.DeleteUser(user))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }
    }
}
