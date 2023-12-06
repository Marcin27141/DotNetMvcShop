using DotnetList5Task2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMvcTasks.Controllers
{
    public class ToolController : Controller
    {

        [Route("Tool/Solve/{a}/{b}/{c}")]
        public IActionResult Solve(int a, int b, int c)
        {
            if (a == 0) return RedirectToAction(nameof(ZeroError));

            double lowerResult = 0, higherResult = 0;
            QuadraticEquation equation = new(a, b, c);
            equation.Solve();
            var numberOfResults = equation.NumberOfSolutions;
            if (numberOfResults > 0)
            {
                lowerResult = equation.LowerSolution ?? 0;
                higherResult = equation.GreaterSolution ?? 0;
            }

            var model = new ToolViewModel
            {
                aCoefficient = a,
                bCoefficient = b,
                cCoefficient = c,
                NumberOfResults = numberOfResults,
                LowerResult = lowerResult,
                HigherResult = higherResult
            };

            return View(model);
        }

        public IActionResult ZeroError()
        {
            return View();
        }
    }

    

    class QuadraticEquation
    {
        private int aCoeff { get; set; }
        private int bCoeff { get; set; }
        private int cCoeff { get; set; }
        public int NumberOfSolutions { get; set; }
        public double? LowerSolution { get; set; } = null;
        public double? GreaterSolution { get; set; } = null;

        public QuadraticEquation(int a, int b, int c)
        {
            if (a == 0)
                throw new ArgumentException("Coefficient a can't be zero");

            aCoeff = a;
            bCoeff = b;
            cCoeff = c;
        }

        private double getDelta()
        {
            return Math.Pow(bCoeff, 2) - 4 * aCoeff * cCoeff;
        }

        private double getGreaterSolution(double delta)
        {
            return (-1 * bCoeff + Math.Sqrt(delta)) / (2 * aCoeff);
        }

        private double getLowerSolution(double delta)
        {
            return (-1 * bCoeff - Math.Sqrt(delta)) / (2 * aCoeff);
        }

        public void Solve()
        {
            double delta = getDelta();
            if (delta < 0)
                NumberOfSolutions = 0;
            else
            {
                GreaterSolution = getGreaterSolution(delta);
                if (Math.Round(delta, 5) == 0.00000)
                {
                    NumberOfSolutions = 1;
                    LowerSolution = GreaterSolution;
                } else
                {
                    NumberOfSolutions = 2;
                    LowerSolution = getLowerSolution(delta);
                }
            }           
        }
    }

}

