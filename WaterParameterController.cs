using Microsoft.AspNetCore.Mvc;
using KoiCareSystem.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KoiCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterParametersController : ControllerBase
    {
        [HttpGet("{hoId}")]
        public IActionResult LayThongSoNuoc(int hoId)
        {
            var hoCa = HoCaController.hoCas.SingleOrDefault(h => h.HoId == hoId);
            if (hoCa == null)
            {
                return NotFound();
            }
            return Ok(hoCa.WaterParametersList);
        }

        [HttpPost("{hoId}")]
        public IActionResult ThemThongSoNuoc(int hoId, WaterParameters waterParameters)
        {
            var hoCa = HoCaController.hoCas.SingleOrDefault(h => h.HoId == hoId);
            if (hoCa == null)
            {
                return NotFound();
            }

            waterParameters.Id = Guid.NewGuid();
            hoCa.WaterParametersList.Add(waterParameters);

            return Ok(new
            {
                ThanhCong = true,
                DuLieu = waterParameters
            });
        }

        [HttpPut("{hoId}/{paramId}")]
        public IActionResult CapNhatThongSoNuoc(int hoId, Guid paramId, WaterParameters capNhatThongSo)
        {
            var hoCa = HoCaController.hoCas.SingleOrDefault(h => h.HoId == hoId);
            if (hoCa == null)
            {
                return NotFound();
            }

            var waterParameter = hoCa.WaterParametersList.SingleOrDefault(wp => wp.Id == paramId);
            if (waterParameter == null)
            {
                return NotFound();
            }

            waterParameter.Temperature = capNhatThongSo.Temperature;
            waterParameter.Salt = capNhatThongSo.Salt;
            waterParameter.PH = capNhatThongSo.PH;
            waterParameter.O2 = capNhatThongSo.O2;
            waterParameter.NO2 = capNhatThongSo.NO2;
            waterParameter.NO3 = capNhatThongSo.NO3;
            waterParameter.PO4 = capNhatThongSo.PO4;

            return Ok(new
            {
                ThanhCong = true,
                DuLieu = waterParameter
            });
        }

        [HttpDelete("{hoId}/{paramId}")]
        public IActionResult XoaThongSoNuoc(int hoId, Guid paramId)
        {
            var hoCa = HoCaController.hoCas.SingleOrDefault(h => h.HoId == hoId);
            if (hoCa == null)
            {
                return NotFound();
            }

            var waterParameter = hoCa.WaterParametersList.SingleOrDefault(wp => wp.Id == paramId);
            if (waterParameter == null)
            {
                return NotFound();
            }

            hoCa.WaterParametersList.Remove(waterParameter);
            return Ok(new
            {
                ThanhCong = true,
                ThongBao = "Thông số nước đã được xóa thành công"
            });
        }
    }
}
