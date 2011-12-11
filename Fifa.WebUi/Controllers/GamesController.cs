using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fifa.WebUi.Models;

namespace Fifa.WebUi.Controllers
{   
    public class GamesController : Controller
    {
		private readonly IGameRepository gameRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public GamesController() : this(new GameRepository())
        {
        }

        public GamesController(IGameRepository gameRepository)
        {
			this.gameRepository = gameRepository;
        }

        //
        // GET: /Games/

        public ViewResult Index()
        {
            return View(gameRepository.All);
        }

        //
        // GET: /Games/Details/5

        public ViewResult Details(int id)
        {
            return View(gameRepository.Find(id));
        }

        //
        // GET: /Games/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Games/Create

        [HttpPost]
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid) {
                gameRepository.InsertOrUpdate(game);
                gameRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Games/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(gameRepository.Find(id));
        }

        //
        // POST: /Games/Edit/5

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid) {
                gameRepository.InsertOrUpdate(game);
                gameRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Games/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(gameRepository.Find(id));
        }

        //
        // POST: /Games/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            gameRepository.Delete(id);
            gameRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

