using KoiCareSystem.CSDL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KoiCareSystem.ControllerApi
{
    [Route("CaKoi")]
    [ApiController]
    public class CaKoiController : ControllerBase
    {
        private readonly KoiCareSystemContext _dbc;

        public CaKoiController(KoiCareSystemContext db)
        {
            _dbc = db;
        }

        // GET: api/CaKoi/List
        [HttpGet("List")]
        public IActionResult GetList()
        {
            var caKois = _dbc.CaKois.ToList();
            return Ok(new { data = caKois });
        }

        // GET: api/CaKoi/5
        [HttpGet("{id}")]
        public IActionResult GetCaKoi(int id)
        {
            var caKoi = _dbc.CaKois.FirstOrDefault(x => x.MaCa == id); // Find by primary key
            if (caKoi == null)
            {
                return NotFound(new { message = "CaKoi not found" });
            }

            return Ok(caKoi);
        }

        // POST: api/CaKoi/Insert
        [HttpPost("Insert")]
        public IActionResult InsertCaKoi([FromBody] CaKoi caKoi)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Validate the model before saving
                }

                _dbc.CaKois.Add(caKoi);
                _dbc.SaveChanges();
                return CreatedAtAction(nameof(GetCaKoi), new { id = caKoi.MaCa }, caKoi); // Return created object with ID
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, innerException = ex.InnerException?.Message }); // Return error message
            }
        }

        // PUT: api/CaKoi/Update/5
        [HttpPut("Update/{id}")]
        public IActionResult UpdateCaKoi(int id, [FromBody] CaKoi caKoi)
        {
            try
            {
                var existingCaKoi = _dbc.CaKois.FirstOrDefault(x => x.MaCa == id); // Find by primary key
                if (existingCaKoi == null)
                {
                    return NotFound(new { message = "CaKoi not found" });
                }

                // Update only the required properties
                existingCaKoi.TenCa = caKoi.TenCa;
                existingCaKoi.GioiTinh = caKoi.GioiTinh;
                existingCaKoi.GiongCa = caKoi.GiongCa;
                existingCaKoi.CanNang = caKoi.CanNang;
                existingCaKoi.KichThuoc = caKoi.KichThuoc;
                existingCaKoi.XuatXu = caKoi.XuatXu;

                _dbc.CaKois.Update(existingCaKoi);
                _dbc.SaveChanges();
                return Ok(existingCaKoi);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, innerException = ex.InnerException?.Message }); // Return error message
            }
        }

        // DELETE: api/CaKoi/Delete/5
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCaKoi(int id)
        {
            try
            {
                var caKoi = _dbc.CaKois.FirstOrDefault(x => x.MaCa == id); // Find by primary key
                if (caKoi == null)
                {
                    return NotFound(new { message = "CaKoi not found" });
                }

                _dbc.CaKois.Remove(caKoi);
                _dbc.SaveChanges();
                return NoContent(); // Indicate successful deletion
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, innerException = ex.InnerException?.Message }); // Return error message
            }
        }
    }
}
