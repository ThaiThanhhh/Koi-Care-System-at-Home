namespace KoiCareSystem
{
    public class KoiCareSystem
    {
        public bool ThemKoi(Koi koi)
        {
            if (string.IsNullOrEmpty(koi.Name))
            {
                return false; // Thất bại nếu tên trống
            }
            return true; // Thành công nếu tên hợp lệ
        }
    }

    public class Koi
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Breed { get; set; }
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
        public void TestThemCa_ThanhCong()
        {
            var koi = new Koi { Name = "Koi D", Age = 1, Weight = 2.0, Breed = "Asagi" };
            var result = _koiCareSystem.ThemKoi(koi);
            Assert.IsTrue(result, "Thêm cá Koi thành công.");
        }

        [TestMethod]
        public void TestThemCa_ThatBai_KhongCoTen()
        {
            var koi = new Koi { Name = "", Age = 1, Weight = 2.0, Breed = "Asagi" };
            var result = _koiCareSystem.ThemKoi(koi);
            Assert.IsFalse(result, "Thêm cá Koi thất bại do không có tên.");
        }
    }
}