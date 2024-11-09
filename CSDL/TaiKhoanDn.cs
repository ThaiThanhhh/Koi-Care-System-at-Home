using System.ComponentModel.DataAnnotations;

namespace KoiCareSystem.CSDL
{
    public class TaiKhoanDn
    {
        [Key] // This attribute indicates that this property is the primary key
        public int TaiKhoanId { get; set; } // Primary key

        [Required] // Ensures that this field is required
        [StringLength(50)] // Limits the length of the username
        public string Taikhoan { get; set; } // Username

        [Required] // Ensures that this field is required
        [StringLength(50)] // Limits the length of the password
        public string Matkhau { get; set; } // Password
    }
}
