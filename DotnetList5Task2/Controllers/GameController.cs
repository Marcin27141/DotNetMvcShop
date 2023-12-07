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
        private static int _guessingCeiling = 10;
        private static int secretNumber = 0;
        private static int _guessesTaken = 0;

        public IActionResult Index()
        {
            return View();
        }

        [Route("Set,{ceiling}")]
        public IActionResult SetCeiling(int ceiling)
        {
            if (ceiling > 0)
            {
                _guessingCeiling = ceiling;
                TempData[SUCCESS_MESSAGE] = "New guessing range was set";
            }
            else
                TempData[ERROR_MESSAGE] = "Range must be greater than 0";

            return RedirectToAction(nameof(Index));
        }

        [Route("Draw")]
        public IActionResult DrawRandom()
        {
            secretNumber = _random.Next(0, _guessingCeiling);
            _guessesTaken = 0;
            TempData[SUCCESS_MESSAGE] = "New secret number was generated";
            return RedirectToAction(nameof(Index));
        }

        [Route("Guess,{guess}")]
        public IActionResult GuessNumber(int guess)
        {
            _guessesTaken++;
            var model = new GameViewModel
            {
                GuessesTaken = _guessesTaken,
                SuccessfullyGuessed = guess == secretNumber,
                MoreOrLess = Math.Sign(guess - secretNumber)
            };
            return View(model);
        }
    }
}
