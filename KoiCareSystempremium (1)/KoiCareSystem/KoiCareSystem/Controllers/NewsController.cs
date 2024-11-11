using Microsoft.AspNetCore.Mvc;

namespace KoiCareSystem.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
