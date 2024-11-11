using Microsoft.AspNetCore.Mvc;
using KoiCareSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using KoiCareSystem.Reponsitory;

public class AquariumController : Controller
{
    private readonly DataContext _context;

    public AquariumController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Hiển thị danh sách bể cá từ cơ sở dữ liệu
        var aquariumList = _context.Aquariums.ToList();
        return View(aquariumList);
    }

    public IActionResult Create()
    {
        // Hiển thị form thêm mới bể cá
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Aquarium aquarium)
    {
        if (ModelState.IsValid)
        {
            // Thêm bể cá vào cơ sở dữ liệu
            _context.Aquariums.Add(aquarium);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(aquarium);
    }

    public IActionResult Edit(int id)
    {
        // Tìm bể cá cần sửa từ cơ sở dữ liệu
        var aquarium = _context.Aquariums.FirstOrDefault(a => a.Id == id);
        if (aquarium == null) return NotFound();
        return View(aquarium);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Aquarium updatedAquarium)
    {
        if (ModelState.IsValid)
        {
            // Cập nhật thông tin bể cá trong cơ sở dữ liệu
            _context.Aquariums.Update(updatedAquarium);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(updatedAquarium);
    }

    public IActionResult Delete(int id)
    {
        // Tìm bể cá cần xóa từ cơ sở dữ liệu
        var aquarium = _context.Aquariums.FirstOrDefault(a => a.Id == id);
        if (aquarium == null) return NotFound();
        return View(aquarium);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        // Xóa bể cá khỏi cơ sở dữ liệu
        var aquarium = _context.Aquariums.FirstOrDefault(a => a.Id == id);
        if (aquarium != null)
        {
            _context.Aquariums.Remove(aquarium);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}
