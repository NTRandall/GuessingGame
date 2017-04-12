using GuessingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuessingGame.Service;

namespace GuessingGame.Controllers
{
    public class GameController : Controller
    {
        private readonly IRandomNumberGenerator _rng;

        public GameController(IRandomNumberGenerator rng)
        {
            _rng = rng;
        }
        // GET: Game
        public ActionResult Index()
        {
            
            //TODO come up with a better random num generator
            Session["Answer"] = _rng.GetNext(1, 10);

            return View();
        }

        private bool GuessWasCorrect(int guess) =>
            guess == (int)Session["Answer"];
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GameModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Win = GuessWasCorrect(model.Guess);
            }

            return View(model);
        }

    }
}