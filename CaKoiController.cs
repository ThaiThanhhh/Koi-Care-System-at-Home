using Microsoft.AspNetCore.Mvc;
using KoiCareSystem.Repositories.Models;
using System.Collections.Generic;
using System.Linq;

namespace KoiCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaKoiController : ControllerBase
    {
        public static List<CaKoi> caKois = new List<CaKoi>();

        // Lấy danh sách tất cả cá Koi
        [HttpGet]
        public IActionResult LayTatCa()
        {
            return Ok(caKois);
        }

        // Lấy thông tin cá Koi theo ID
        [HttpGet("{id}")]
        public IActionResult LayTheoId(int id)
        {
            var caKoi = caKois.SingleOrDefault(c => c.MaCa == id);
            if (caKoi == null)
            {
                return NotFound();
            }
            return Ok(caKoi);
        }

        // Thêm mới một cá Koi vào hồ
        [HttpPost]
        public IActionResult TaoMoi(CaKoi caKoi)
        {
            caKoi.MaCa = caKois.Count > 0 ? caKois.Max(c => c.MaCa) + 1 : 1;
            caKois.Add(caKoi);
            return Ok(new
            {
                ThanhCong = true,
                DuLieu = caKoi
            });
        }

        // Cập nhật thông tin cá Koi
        [HttpPut("{id}")]
        public IActionResult CapNhat(int id, CaKoi caKoiCapNhat)
        {
            var caKoi = caKois.SingleOrDefault(c => c.MaCa == id);
            if (caKoi == null)
            {
                return NotFound();
            }

            caKoi.TenCa = caKoiCapNhat.TenCa;
            caKoi.HinhAnh = caKoiCapNhat.HinhAnh;
            caKoi.KieuDang = caKoiCapNhat.KieuDang;
            caKoi.Tuoi = caKoiCapNhat.Tuoi;
            caKoi.KichThuoc = caKoiCapNhat.KichThuoc;
            caKoi.CanNang = caKoiCapNhat.CanNang;
            caKoi.GioiTinh = caKoiCapNhat.GioiTinh;
            caKoi.GiongCa = caKoiCapNhat.GiongCa;
            caKoi.XuatXu = caKoiCapNhat.XuatXu;
            caKoi.Gia = caKoiCapNhat.Gia;
            caKoi.MaHo = caKoiCapNhat.MaHo; // Cập nhật hồ mà cá đang ở

            return Ok(new
            {
                ThanhCong = true,
                DuLieu = caKoi
            });
        }

        // Xóa cá Koi theo ID
        [HttpDelete("{id}")]
        public IActionResult Xoa(int id)
        {
            var caKoi = caKois.SingleOrDefault(c => c.MaCa == id);
            if (caKoi == null)
            {
                return NotFound();
            }

            caKois.Remove(caKoi);
            return Ok(new
            {
                ThanhCong = true,
                ThongBao = "Cá Koi đã được xóa thành công"
            });
        }
    }
}
