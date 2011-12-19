using System.Web.Mvc;
using Fifa.Core;
using Fifa.Core.Models;

namespace Fifa.WebUi.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            var games = GameService.GetAllGames();
            return View(games);
        }

        public ActionResult Create()
        {
            var game = GameService.CreateGame();
            return View("Edit", game);
        }

        public ActionResult Edit(int id)
        {
            var team = GameService.GetTeam(id);
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                if (GameService.SaveGame(game))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(game);
        }

        public ActionResult Delete(int id)
        {
            var game = GameService.GetTeam(id);
            return View(game);
        }

        [HttpPost]
        public ActionResult Delete(Game game)
        {
            if (ModelState.IsValid)
            {
                if (GameService.DeleteGame(game))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(game);
        }
    }
}
