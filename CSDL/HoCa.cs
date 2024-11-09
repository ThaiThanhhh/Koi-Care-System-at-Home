using System;
using System.Collections.Generic;

namespace KoiCareSystem.CSDL;

public partial class HoCa
{
    public int HoId { get; set; }

    public string TenHo { get; set; } = null!;

    public string? HinhAnh { get; set; }

    public decimal? KichThuoc { get; set; }

    public decimal? DoSau { get; set; }

    public decimal? TheTich { get; set; }

    public int? SoLuongOngThoatNuoc { get; set; }

    public decimal? CongSuatMayBom { get; set; }
}
