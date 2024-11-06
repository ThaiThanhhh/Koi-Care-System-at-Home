using System;

namespace KoiCareSystem.Repositories.Models
{
    public partial class CaKoi
    {
        public int MaCa { get; set; } // Mã định danh của cá

        public string TenCa { get; set; } = null!; // Tên của cá

        public string? HinhAnh { get; set; } // Hình ảnh của cá

        public string? KieuDang { get; set; } // Kiểu dáng của cá

        public int? Tuoi { get; set; } // Tuổi của cá

        public decimal? KichThuoc { get; set; } // Kích thước của cá

        public decimal? CanNang { get; set; } // Cân nặng của cá

        public string? GioiTinh { get; set; } // Giới tính của cá

        public string? GiongCa { get; set; } // Giống cá

        public string? XuatXu { get; set; } // Xuất xứ của cá

        public decimal? Gia { get; set; } // Giá của cá

        public int? MaHo { get; set; } // Mã hồ mà cá đang ở (foreign key)

        // Thông tin về hồ mà cá đang ở
        public virtual HoCa? MaHoDangO { get; set; }
    }
}
