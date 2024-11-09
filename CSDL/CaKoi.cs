using System;
using System.Collections.Generic;

namespace KoiCareSystem.CSDL;

public partial class CaKoi
{
    public int MaCa { get; set; }

    public string TenCa { get; set; } = null!;

    public string? HinhAnh { get; set; }

    public string? KieuDang { get; set; }

    public int? Tuoi { get; set; }

    public decimal? KichThuoc { get; set; }

    public decimal? CanNang { get; set; }

    public string? GioiTinh { get; set; }

    public string? GiongCa { get; set; }

    public string? XuatXu { get; set; }

    public decimal? Gia { get; set; }

    public int? MaHo { get; set; }

    public virtual HoCaKoi? MaHoNavigation { get; set; }
}
