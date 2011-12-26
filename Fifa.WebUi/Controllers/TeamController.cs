using System.Web.Mvc;

using Fifa.Core.Models;
using Fifa.Core.Services;

namespace Fifa.WebUi.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public ActionResult Index()
        {
            var teams = teamService.GetAllTeams();
            return View(teams);
        }

        public ActionResult Create()
        {
            var team = teamService.CreateTeam();
            return View("Edit", team);
        } 

        public ActionResult Edit(int id)
        {
            var team = teamService.GetTeam(id);
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                teamService.SaveTeam(team);
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public ActionResult Delete(int id)
        {
            var team = teamService.GetTeam(id);
            return View(team);
        }

        [HttpPost]
        public ActionResult Delete(Team team)
        {
            if (ModelState.IsValid)
            {
                teamService.DeleteTeam(team);
                return RedirectToAction("Index");
            }
            return View(team);
        }
    }
}