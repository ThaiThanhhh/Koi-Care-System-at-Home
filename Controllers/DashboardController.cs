using Microsoft.AspNetCore.Mvc;

namespace KoiCareSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
