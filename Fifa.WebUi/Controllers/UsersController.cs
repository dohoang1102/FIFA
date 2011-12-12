using System.Linq;
using System.Web.Mvc;
using Fifa.WebUi.Models;

namespace Fifa.WebUi.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public UsersController() : this(new UserRepository())
        {
        }

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        //
        // GET: /Users/

        public ViewResult Index()
        {
            return View(userRepository.All);
        }

        //
        // GET: /Users/Details/5

        public ViewResult Details(int id)
        {
            return View(userRepository.Find(id));
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.IsAdmin = false;
                userRepository.InsertOrUpdate(user);
                userRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id)
        {
            if (IsSelfModification(id))
            {
                return View(userRepository.Find(id));
            }
            else
            {
                return new HttpUnauthorizedResult();
            }
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (IsSelfModification(user.Id) && ModelState.IsValid)
            {
                user.IsAdmin = false;
                userRepository.InsertOrUpdate(user);
                userRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id)
        {
            if (IsSelfModification(id))
            {
                return View(userRepository.Find(id));
            }
            else
            {
                return new HttpUnauthorizedResult();
            }
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (IsSelfModification(id))
            {
                userRepository.Delete(id);
                userRepository.Save();

                return RedirectToAction("Index");
            }
            else
            {
                return new HttpUnauthorizedResult();
            }
        }

        private bool IsSelfModification(int id)
        {
            return true || User.Identity.IsAuthenticated &&
                   userRepository.All.Any(x =>
                                          x.Id == id &&
                                          x.Name == User.Identity.Name);
        }
    }
}