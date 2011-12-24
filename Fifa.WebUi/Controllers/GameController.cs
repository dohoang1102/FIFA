using System.Linq;
using System.Web.Mvc;
using Fifa.Core.Helpers;
using Fifa.Core.Models;
using Fifa.Core.Services;
using Fifa.WebUi.ViewModels.Game;

namespace Fifa.WebUi.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IUserService _userService;
        private readonly IStatsService _statsService;

        public GameController(IGameService gameService, IUserService userService, IStatsService statsService)
        {
            _gameService = gameService;
            _userService = userService;
            _statsService = statsService;
        }

        public ActionResult Index()
        {
            var games = _gameService.GetAllGames();
            return View(games);
        }

        public ActionResult Create()
        {
            var game = _gameService.CreateGame();
            return View("Edit", game);
        }

        public ActionResult Edit(int id)
        {
            var team = _gameService.GetTeam(id);
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                _gameService.SaveGame(game);
                return RedirectToAction("Index");
            }
            return View(game);
        }

        public ActionResult Delete(int id)
        {
            var game = _gameService.GetTeam(id);
            return View(game);
        }

        [HttpPost]
        public ActionResult Delete(Game game)
        {
            if (ModelState.IsValid)
            {
                _gameService.DeleteGame(game);
                return RedirectToAction("Index");
            }
            return View(game);
        }

        public ActionResult Forecast()
        {
            var userService = DependencyResolver.Current.GetService<IUserService>();

            var vm = new ForecastViewModel
            {
                AvailablePlayers = userService.GetAllUsers().OrderBy(user => user.Name).Select(
                    user => new SelectListItem { Text = user.Name, Value = user.Id.ToString() })
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Forecast(ForecastViewModel vm)
        {
            vm.AvailablePlayers = _userService.GetAllUsers().OrderBy(user => user.Name).Select(
                user => new SelectListItem { Text = user.Name, Value = user.Id.ToString() });
            
            var playerA = _userService.GetUser(vm.PlayerAId);
            var playerB = _userService.GetUser(vm.PlayerBId);

            vm.NamePlayerA = playerA.Name;
            vm.NamePlayerB = playerB.Name;

            vm.CurrentRatingPlayerA = (double)_statsService.GetUserStat(playerA.Id).Elo;
            vm.CurrentRatingPlayerB = (double)_statsService.GetUserStat(playerB.Id).Elo;

            var elo = new EloCalculator(vm.CurrentRatingPlayerA, vm.CurrentRatingPlayerB);
            vm.ChanceToWinPlayerA = elo.GetChanceToWinPlayerA() * 100;
            vm.ChanceToWinPlayerB = 100 - vm.ChanceToWinPlayerA;
            
            elo.WinGamePlayerA();
            vm.RatingPlayerAWinPlayerA = elo.RatingPlayerA;
            vm.RatingPlayerBWinPlayerA = elo.RatingPlayerB;

            elo = new EloCalculator(vm.CurrentRatingPlayerA, vm.CurrentRatingPlayerB);
            elo.WinGamePlayerB();
            vm.RatingPlayerAWinPlayerB = elo.RatingPlayerA;
            vm.RatingPlayerBWinPlayerB = elo.RatingPlayerB;

            elo = new EloCalculator(vm.CurrentRatingPlayerA, vm.CurrentRatingPlayerB);
            elo.DrawGame();
            vm.RatingPlayerADrawGame = elo.RatingPlayerA;
            vm.RatingPlayerBDrawGame = elo.RatingPlayerB;

            vm.Calculated = true;
            
            return View(vm);
        }
    }
}
