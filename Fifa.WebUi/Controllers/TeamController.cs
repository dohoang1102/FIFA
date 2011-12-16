using System.Web.Mvc;

using Fifa.Core;
using Fifa.Core.Models;
using Fifa.Models;

namespace Fifa.WebUi.Controllers
{
    public class TeamController : Controller
    {
        public ActionResult Index()
        {
            var teams = TeamService.GetAllTeams();
            return View(teams);
        }

        public ActionResult Create()
        {
            var team = TeamService.CreateTeam();
            return View("Edit", team);
        } 

        public ActionResult Edit(int id)
        {
            var team = TeamService.GetTeam(id);
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                if (TeamService.SaveTeam(team))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(team);
        }

        public ActionResult Delete(int id)
        {
            var team = TeamService.GetTeam(id);
            return View(team);
        }

        [HttpPost]
        public ActionResult Delete(Team team)
        {
            if (ModelState.IsValid)
            {
                if (TeamService.DeleteTeam(team))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(team);
        }
    }
}