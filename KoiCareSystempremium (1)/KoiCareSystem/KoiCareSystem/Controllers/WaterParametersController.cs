using Microsoft.AspNetCore.Mvc;
using KoiCareSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using KoiCareSystem.Reponsitory;

namespace KoiCareSystem.Controllers
{
    public class WaterParametersController : Controller
    {
        private readonly DataContext _context;

        public WaterParametersController(DataContext context)
        {
            _context = context;
        }

        // GET: WaterParameters/Index
        public IActionResult Index()
        {
            // Lấy danh sách thông số nước từ cơ sở dữ liệu
            var waterParametersList = _context.WaterParameters.ToList();
            return View(waterParametersList);
        }

        // GET: WaterParameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WaterParameters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WaterParameter waterParameter)
        {
            if (ModelState.IsValid)
            {
                waterParameter.Timestamp = DateTime.Now;
                _context.WaterParameters.Add(waterParameter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(waterParameter);
        }

        // GET: WaterParameters/Edit/{id}
        public IActionResult Edit(int id)
        {
            var waterParameter = _context.WaterParameters.FirstOrDefault(wp => wp.Id == id);
            if (waterParameter == null)
                return NotFound();

            return View(waterParameter);
        }

        // POST: WaterParameters/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WaterParameter updatedWaterParameter)
        {
            if (ModelState.IsValid)
            {
                var waterParameter = _context.WaterParameters.FirstOrDefault(wp => wp.Id == updatedWaterParameter.Id);
                if (waterParameter == null)
                    return NotFound();

                // Cập nhật thông tin thông số nước
                waterParameter.Temperature = updatedWaterParameter.Temperature;
                waterParameter.Salt = updatedWaterParameter.Salt;
                waterParameter.PH = updatedWaterParameter.PH;
                waterParameter.Oxygen = updatedWaterParameter.Oxygen;
                waterParameter.Nitrit = updatedWaterParameter.Nitrit;
                waterParameter.Nitrat = updatedWaterParameter.Nitrat;
                waterParameter.Phosphat = updatedWaterParameter.Phosphat;
                waterParameter.Timestamp = DateTime.Now;

                _context.WaterParameters.Update(waterParameter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(updatedWaterParameter);
        }

        // GET: WaterParameters/Delete/{id}
        public IActionResult Delete(int id)
        {
            var waterParameter = _context.WaterParameters.FirstOrDefault(wp => wp.Id == id);
            if (waterParameter == null)
                return NotFound();

            return View(waterParameter);
        }

        // POST: WaterParameters/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterParameter = _context.WaterParameters.FirstOrDefault(wp => wp.Id == id);
            if (waterParameter != null)
            {
                _context.WaterParameters.Remove(waterParameter);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
