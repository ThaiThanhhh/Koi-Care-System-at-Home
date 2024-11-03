using Microsoft.AspNetCore.Mvc;

namespace KoiCareSystem.Controllers
{
    public class AquariumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
