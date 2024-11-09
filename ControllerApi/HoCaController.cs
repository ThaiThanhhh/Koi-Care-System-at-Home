using KoiCareSystem.CSDL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KoiCareSystem.ControllerApi
{
    [Route("HoCa")]
    [ApiController]
    public class HoCaController : ControllerBase
    {
        private readonly KoiCareSystemContext _dbc;

        public HoCaController(KoiCareSystemContext db)
        {
            _dbc = db;
        }

        // GET: api/HoCa/List
        [HttpGet("List")]
        public IActionResult GetList()
        {
            var hoCas = _dbc.HoCas.ToList();
            return Ok(new { data = hoCas });
        }

        // POST: api/HoCa/Insert
        [HttpPost("Insert")]
        public IActionResult InsertHoCa([FromBody] HoCa hoCa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Validate the model before saving
            }

            _dbc.HoCas.Add(hoCa);
            _dbc.SaveChanges();
            return CreatedAtAction(nameof(GetList), new { id = hoCa.HoId }, hoCa);  // Return created object with ID
        }

        // PUT: api/HoCa/Update/5
        [HttpPut("Update/{id}")]
        public IActionResult UpdateHoCa(int id, [FromBody] HoCa hoCa)
        {
            var existingHoCa = _dbc.HoCas.FirstOrDefault(x => x.HoId == id); // Find by primary key
            if (existingHoCa == null)
            {
                return NotFound(new { message = "HoCa not found" });
            }

            existingHoCa.TenHo = hoCa.TenHo;
            existingHoCa.KichThuoc = hoCa.KichThuoc;
            existingHoCa.DoSau = hoCa.DoSau;
            existingHoCa.TheTich = hoCa.TheTich;
            existingHoCa.SoLuongOngThoatNuoc = hoCa.SoLuongOngThoatNuoc;
            existingHoCa.CongSuatMayBom = hoCa.CongSuatMayBom;

            _dbc.HoCas.Update(existingHoCa);
            _dbc.SaveChanges();
            return Ok(existingHoCa);
        }

        // DELETE: api/HoCa/Delete/5
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteHoCa(int id)
        {
            var hoCa = _dbc.HoCas.FirstOrDefault(x => x.HoId == id); // Find by primary key
            if (hoCa == null)
            {
                return NotFound(new { message = "HoCa not found" });
            }

            _dbc.HoCas.Remove(hoCa);
            _dbc.SaveChanges();
            return NoContent();  // Indicate successful deletion
        }
    }
}
