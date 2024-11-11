namespace KoiCareSystem
{
    public class KoiCareSystem
    {
        public bool ThemThongSoNuoc(ThongSoNuoc thongSo)
        {
            if (thongSo.pH < 0 || thongSo.pH > 9)
            {
                return false; // Thất bại nếu pH không hợp lệ
            }
            return true; // Thành công nếu pH hợp lệ
        }
    }

    public class ThongSoNuoc
    {
        public int Temperature { get; set; }
        public double pH { get; set; }
        public int O2 { get; set; }
        public double NO2 { get; set; }
    }
}

namespace KoiCareSystem.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KoiCareSystemTests
    {
        private KoiCareSystem _koiCareSystem;

        [TestInitialize]
        public void Setup()
        {
            _koiCareSystem = new KoiCareSystem(); // Tạo đối tượng KoiCareSystem để kiểm thử
        }

        [TestMethod]
        public void TestThemThongSoNuoc_ThanhCong()
        {
            var thongSo = new ThongSoNuoc { Temperature = 24, pH = 7.5, O2 = 8, NO2 = 0.02 };
            var result = _koiCareSystem.ThemThongSoNuoc(thongSo);
            Assert.IsTrue(result, "Thêm thông số nước thành công.");
        }

        [TestMethod]
        public void TestThemThongSoNuoc_ThatBai_pHKhongHopLe()
        {
            var thongSo = new ThongSoNuoc { Temperature = 24, pH = 10, O2 = 8, NO2 = 0.02 };
            var result = _koiCareSystem.ThemThongSoNuoc(thongSo);
            Assert.IsFalse(result, "Thêm thông số nước thất bại do pH không hợp lệ.");
        }
    }
}