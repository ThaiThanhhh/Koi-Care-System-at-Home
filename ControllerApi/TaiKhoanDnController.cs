using KoiCareSystem.CSDL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KoiCareSystem.ControllerApi
{
    [Route("TaiKhoan")]
    [ApiController]
    public class TaiKhoanDnController : ControllerBase
    {
        private readonly KoiCareSystemContext _dbc;

        public TaiKhoanDnController(KoiCareSystemContext db)
        {
            _dbc = db;
        }

        [HttpGet("List")]
        public IActionResult GetList()
        {
            try
            {
                // Get all accounts from the database
                var accounts = _dbc.TaiKhoanDns.ToList();

                if (accounts == null || accounts.Count == 0)
                {
                    return NotFound(new { message = "No accounts found" });
                }

                return Ok(new { data = accounts });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, innerException = ex.InnerException?.Message });
            }
        }


        [HttpPost("Insert")]
        public IActionResult InsertTaiKhoan(string taikhoan, string matkhau)
        {
            try
            {
                var tk = new TaiKhoanDn
                {
                    Taikhoan = taikhoan,
                    Matkhau = matkhau
                };
                _dbc.TaiKhoanDns.Add(tk);
                _dbc.SaveChanges();
                return CreatedAtAction(nameof(GetList), new { id = tk.TaiKhoanId }, tk); // Return created object with ID
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, innerException = ex.InnerException?.Message }); // Return error message
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateTaiKhoan(int taiKhoanId, string taikhoan, string matkhau)
        {
            try
            {
                var tk = _dbc.TaiKhoanDns.FirstOrDefault(x => x.TaiKhoanId == taiKhoanId); // Find by primary key
                if (tk == null)
                {
                    return NotFound(new { message = "Tai khoan not found" });
                }

                tk.Taikhoan = taikhoan;
                tk.Matkhau = matkhau;
                _dbc.TaiKhoanDns.Update(tk);
                _dbc.SaveChanges();
                return Ok(tk);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, innerException = ex.InnerException?.Message }); // Return error message
            }
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteTaiKhoan(int taiKhoanId)
        {
            try
            {
                var tk = _dbc.TaiKhoanDns.FirstOrDefault(x => x.TaiKhoanId == taiKhoanId); // Find by primary key
                if (tk == null)
                {
                    return NotFound(new { message = "Tai khoan not found" });
                }

                _dbc.TaiKhoanDns.Remove(tk);
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
