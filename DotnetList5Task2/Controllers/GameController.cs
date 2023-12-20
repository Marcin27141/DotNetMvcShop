using DotnetList5Task2.Models;
using DotnetList5Task2.Models.Game;
using Microsoft.AspNetCore.Mvc;

namespace DotnetList5Task2.Controllers
{
    public class GameController : Controller
    {
        private const string SUCCESS_MESSAGE = "SUCCESS_MESSAGE";
        private const string ERROR_MESSAGE = "ERROR_MESSAGE";
        private static Random _random = new Random();
        private const int _guessingCeiling = 10;

        public IActionResult Index()
        {
            return View();
        }

        [Route("Set,{ceiling}")]
        public IActionResult SetCeiling(int ceiling)
        {
            if (ceiling > 0)
            {
                //_guessingCeiling = ceiling;
                HttpContext.Session.SetInt32("ceiling", ceiling);
                TempData[SUCCESS_MESSAGE] = "New guessing range was set";
            }
            else
                TempData[ERROR_MESSAGE] = "Range must be greater than 0";

            return RedirectToAction(nameof(Index));
        }

        [Route("Draw")]
        public IActionResult DrawRandom()
        {
            var ceiling = HttpContext.Session.GetInt32("ceiling") ?? _guessingCeiling;
            var secretNumber = _random.Next(0, ceiling);

            HttpContext.Session.SetInt32("secret", secretNumber);
            HttpContext.Session.SetInt32("nrOfGuesses", 0);

            TempData[SUCCESS_MESSAGE] = "New secret number was generated";
            return RedirectToAction(nameof(Index));
        }

        [Route("Guess/{guess1},{guess2}")]
        public IActionResult GuessNumber(int guess1, int guess2)
        {
            var secret = HttpContext.Session.GetInt32("secret");
            var nrOfGuesses = HttpContext.Session.GetInt32("nrOfGuesses");

            if (secret.HasValue && nrOfGuesses.HasValue)
            {
                nrOfGuesses++;
                HttpContext.Session.SetInt32("nrOfGuesses", nrOfGuesses.Value);

                var model = new GameViewModel
                {
                    GuessesTaken = nrOfGuesses.Value,
                    SuccessfullyGuessed = guess1 == secret || guess2 == secret,
                    MoreOrLess = GetMoreOrLess(guess1, guess2, secret.Value)
                };
                return View(model);
            }
            else return RedirectToAction(nameof(Index));
            
        }

        private int GetMoreOrLess(int guess1, int guess2, int secret)
        {
            if (guess1 < secret && guess2 < secret)
                return -1;
            else if (guess1 > secret && guess2 > secret)
                return 1;
            else return 0;
        }
    }
}
