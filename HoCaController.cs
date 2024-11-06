using Microsoft.AspNetCore.Mvc;
using KoiCareSystem.Repositories.Models;
using System.Collections.Generic;
using System.Linq;

namespace KoiCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoCaController : ControllerBase
    {
        public static List<HoCa> hoCas = new List<HoCa>();

        // Lấy danh sách tất cả hồ
        [HttpGet]
        public IActionResult LayTatCa()
        {
            return Ok(hoCas);
        }

        // Lấy thông tin hồ theo ID, bao gồm danh sách cá Koi trong hồ
        [HttpGet("{id}")]
        public IActionResult LayTheoId(int id)
        {
            var hoCa = hoCas.SingleOrDefault(h => h.MaHo == id);
            if (hoCa == null)
            {
                return NotFound();
            }
            return Ok(hoCa);
        }

        // Thêm mới một hồ
        [HttpPost]
        public IActionResult TaoMoi(HoCa hoCa)
        {
            hoCa.MaHo = hoCas.Count > 0 ? hoCas.Max(h => h.MaHo) + 1 : 1;
            hoCas.Add(hoCa);
            return Ok(new
            {
                ThanhCong = true,
                DuLieu = hoCa
            });
        }

        // Cập nhật thông tin hồ
        [HttpPut("{id}")]
        public IActionResult CapNhat(int id, HoCa hoCaCapNhat)
        {
            var hoCa = hoCas.SingleOrDefault(h => h.MaHo == id);
            if (hoCa == null)
            {
                return NotFound();
            }

            hoCa.TenHo = hoCaCapNhat.TenHo;
            hoCa.HinhAnh = hoCaCapNhat.HinhAnh;
            hoCa.KichThuoc = hoCaCapNhat.KichThuoc;
            hoCa.DoSau = hoCaCapNhat.DoSau;
            hoCa.TheTich = hoCaCapNhat.TheTich;
            hoCa.SoLuongOngThoatNuoc = hoCaCapNhat.SoLuongOngThoatNuoc;
            hoCa.CongSuatMayBom = hoCaCapNhat.CongSuatMayBom;

            return Ok(new
            {
                ThanhCong = true,
                DuLieu = hoCa
            });
        }

        // Xóa hồ theo ID
        [HttpDelete("{id}")]
        public IActionResult Xoa(int id)
        {
            var hoCa = hoCas.SingleOrDefault(h => h.MaHo == id);
            if (hoCa == null)
            {
                return NotFound();
            }

            hoCas.Remove(hoCa);
            return Ok(new
            {
                ThanhCong = true,
                ThongBao = "Hồ đã được xóa thành công"
            });
        }
    }
}
