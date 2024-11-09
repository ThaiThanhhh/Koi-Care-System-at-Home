using System;
using System.Collections.Generic;

namespace KoiCareSystem.CSDL;

public partial class HoCaKoi
{
    public int MaHo { get; set; }

    public string TenHo { get; set; } = null!;

    public string? HinhAnh { get; set; }

    public decimal? KichThuoc { get; set; }

    public decimal? DoSau { get; set; }

    public decimal? TheTich { get; set; }

    public int? SoCongThoat { get; set; }

    public decimal? CongSuatMayBom { get; set; }

    //public virtual ICollection<CaKoi> CaKois { get; set; } = new List<CaKoi>();
}
