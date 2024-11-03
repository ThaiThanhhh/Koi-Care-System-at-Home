using Microsoft.AspNetCore.Mvc;

namespace KoiCareSystem.Controllers
{
    public class RecommendationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
