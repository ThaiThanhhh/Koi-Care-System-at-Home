using System;

namespace KoiCareSystem.Repositories.Models
{
    public class WaterParameters
    {
        public Guid Id { get; set; } // Mã định danh cho thông số nước
        public float Temperature { get; set; } // Nhiệt độ (độ C)
        public float Salt { get; set; } // Nồng độ muối (‰ hoặc ppt)
        public float PH { get; set; } // pH của nước
        public float O2 { get; set; } // Hàm lượng Oxy hòa tan (mg/L)
        public float NO2 { get; set; } // Hàm lượng Nitrite (mg/L)
        public float NO3 { get; set; } // Hàm lượng Nitrate (mg/L)
        public float PO4 { get; set; } // Hàm lượng Phosphate (mg/L)

        // Liên kết tới hồ cá (nếu cần thiết để tham chiếu)
        public int HoCaId { get; set; }
    }
}
