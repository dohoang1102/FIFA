using System.Web.Mvc;
using Fifa.Core;
using Fifa.Core.Models;
using Fifa.Core.Services;

namespace Fifa.WebUi.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public ActionResult Index()
        {
            var games = gameService.GetAllGames();
            return View(games);
        }

        public ActionResult Create()
        {
            var game = gameService.CreateGame();
            return View("Edit", game);
        }

        public ActionResult Edit(int id)
        {
            var team = gameService.GetTeam(id);
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                gameService.SaveGame(game);
                return RedirectToAction("Index");
            }
            return View(game);
        }

        public ActionResult Delete(int id)
        {
            var game = gameService.GetTeam(id);
            return View(game);
        }

        [HttpPost]
        public ActionResult Delete(Game game)
        {
            if (ModelState.IsValid)
            {
                gameService.DeleteGame(game);
                return RedirectToAction("Index");
            }
            return View(game);
        }
    }
}
