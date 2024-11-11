using Microsoft.AspNetCore.Mvc;
using KoiCareSystem.Models;

namespace KoiCareSystem.Controllers
{
    public class FoodCalculatorController : Controller
    {
        // GET: FoodCalculator/Calculate
        public IActionResult Calculate()
        {
            return View();
        }

        // POST: FoodCalculator/Calculate
        [HttpPost]
        public IActionResult Calculate(double weight, double percentage)
        {
            double foodAmount = FoodCalculator.CalculateFoodAmount(weight, percentage);
            ViewBag.FoodAmount = foodAmount;
            ViewBag.Weight = weight;
            ViewBag.Percentage = percentage;
            return View();
        }
    }
}
