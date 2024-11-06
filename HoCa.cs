using System.Collections.Generic;
using WebApplication1.Models;

namespace KoiCareSystem.Repositories.Models
{
    public partial class HoCa
    {
        public int MaHo { get; set; } // Mã định danh của hồ
        public string TenHo { get; set; } = null!; // Tên của hồ
        public string? HinhAnh { get; set; } // Đường dẫn hình ảnh của hồ
        public decimal? KichThuoc { get; set; } // Kích thước của hồ
        public decimal? DoSau { get; set; } // Độ sâu của hồ
        public decimal? TheTich { get; set; } // Thể tích của hồ
        public int? SoLuongOngThoatNuoc { get; set; } // Số lượng ống thoát nước
        public decimal? CongSuatMayBom { get; set; } // Công suất máy bơm

        // Danh sách các con cá trong hồ này
        public virtual List<CaKoi> CaKoiList { get; set; } = new List<CaKoi>();
    }
}
