using DotnetList5Task2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotnetList5Task2.Controllers
{
    public class Lab4Controller : Controller
    {
        public IActionResult MultiplicationTable()
        {
            return View();
        }

        public IActionResult Canvas()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}