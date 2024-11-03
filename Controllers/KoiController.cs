using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using KoiCareSystem.Models;

public class KoiController : Controller
{
    private readonly List<Koi> koiList = new List<Koi>(); // Ví dụ dữ liệu danh sách

    public IActionResult Index()
    {
        return View(koiList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Koi koi)
    {
        koiList.Add(koi); // Thêm cá Koi vào danh sách
        return RedirectToAction("Index");
    }
}