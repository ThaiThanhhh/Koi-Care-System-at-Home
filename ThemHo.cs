namespace KoiCareSystem
{
    public class KoiCareSystem
    {
        public bool ThemHo(Ho ho)
        {
            if (ho.Capacity <= 0)
            {
                return false; // Thất bại nếu dung tích không hợp lệ
            }
            return true; // Thành công nếu dung tích hợp lệ
        }
    }

    public class Ho
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
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
        public void TestThemHo_ThanhCong()
        {
            var ho = new Ho { Name = "Ho Lon", Capacity = 5000 };
            var result = _koiCareSystem.ThemHo(ho);
            Assert.IsTrue(result, "Thêm hồ thành công.");
        }

        [TestMethod]
        public void TestThemHo_ThatBai_DungTichKhongHopLe()
        {
            var ho = new Ho { Name = "Ho Nho", Capacity = -100 };
            var result = _koiCareSystem.ThemHo(ho);
            Assert.IsFalse(result, "Thêm hồ thất bại do dung tích không hợp lệ.");
        }
    }
}