using System.Web.Mvc;

using Fifa.Core.Models;
using Fifa.Core.Services;

namespace Fifa.WebUi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHistoryService _historyService;

        public UserController(IUserService userService, IHistoryService historyService)
        {
            _userService = userService;
            _historyService = historyService;
        }

        public ActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        public ActionResult Create()
        {
            var user = _userService.CreateUser();
            return View("Edit", user);
        }

        public ActionResult Edit(int id)
        {
            var user = _userService.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.SaveUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            var user = _userService.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.DeleteUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult History(int id)
        {
            var history = _historyService.GetUserHistory(id);
            return View(history);
        }
    }
}
