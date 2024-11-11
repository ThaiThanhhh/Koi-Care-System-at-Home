using Microsoft.AspNetCore.Mvc;
using KoiCareSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.Reponsitory;

namespace KoiCareSystem.Controllers
{
    public class KoiController : Controller
    {
        private readonly DataContext _context;

        public KoiController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Hiển thị danh sách cá Koi từ cơ sở dữ liệu
            var koiList = await _context.Kois.ToListAsync();
            return View(koiList);
        }

        public IActionResult Create()
        {
            // Hiển thị form thêm mới cá Koi
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Koi koi)
        {
            if (ModelState.IsValid)
            {
                // Thêm cá Koi vào cơ sở dữ liệu
                _context.Kois.Add(koi);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(koi);
        }

        public async Task<IActionResult> Edit(int id)
        {
            // Tìm cá Koi cần sửa từ cơ sở dữ liệu
            var koi = await _context.Kois.FindAsync(id);
            if (koi == null) return NotFound();
            return View(koi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Koi updatedKoi)
        {
            if (ModelState.IsValid)
            {
                // Cập nhật thông tin cá Koi trong cơ sở dữ liệu
                _context.Kois.Update(updatedKoi);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(updatedKoi);
        }

        public async Task<IActionResult> Delete(int id)
        {
            // Tìm cá Koi cần xóa từ cơ sở dữ liệu
            var koi = await _context.Kois.FindAsync(id);
            if (koi == null) return NotFound();
            return View(koi);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Xóa cá Koi khỏi cơ sở dữ liệu
            var koi = await _context.Kois.FindAsync(id);
            if (koi != null)
            {
                _context.Kois.Remove(koi);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
