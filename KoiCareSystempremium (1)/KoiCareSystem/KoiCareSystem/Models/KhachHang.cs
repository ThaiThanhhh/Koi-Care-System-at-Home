namespace KoiCareSystem.Models
{
    public class KhachHangVM
    {
        public string Name { get; set; }
        public string PassWord { get; set; }
    }
    public class KhachHang : KhachHangVM
    {
        public Guid MaKH { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }

    }
}