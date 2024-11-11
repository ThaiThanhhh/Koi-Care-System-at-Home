using Microsoft.AspNetCore.Mvc;
using KoiCareSystem.Models;

namespace KoiCareSystem.Controllers
{
    public class SaltCalculatorController : Controller
    {
        // GET: SaltCalculator/Calculate
        public IActionResult Calculate()
        {
            return View();
        }

        // POST: SaltCalculator/Calculate
        [HttpPost]
        public IActionResult Calculate(double volume, double salinity)
        {
            double saltAmount = SaltCalculator.CalculateSaltAmount(volume, salinity);
            ViewBag.SaltAmount = saltAmount;
            ViewBag.Volume = volume;
            ViewBag.Salinity = salinity;
            return View();
        }
    }
}
