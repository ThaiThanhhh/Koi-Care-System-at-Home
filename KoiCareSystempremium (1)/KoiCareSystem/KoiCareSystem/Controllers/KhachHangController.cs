using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KoiCareSystem.Models;
using System;
using System.Linq;
namespace KoiCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        public static List<KhachHang> khachhangs = new List<KhachHang>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(khachhangs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var khachhang = khachhangs.SingleOrDefault(kh => kh.MaKH == Guid.Parse(id));
                if (khachhang == null)
                {
                    return NotFound();
                }
                return Ok(khachhang);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(KhachHangVM khachHangVM)
        {
            var khachhang = new KhachHang
            {
                MaKH = Guid.NewGuid(),
                Name = khachHangVM.Name,
                PassWord = khachHangVM.PassWord,
            };
            khachhangs.Add(khachhang);
            return Ok(new
            {
                Sussecc = true,
                Data = khachhang

            });
        }
    }
}