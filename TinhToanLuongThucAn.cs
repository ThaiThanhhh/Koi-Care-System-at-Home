namespace KoiCareSystem
{
    public class KoiCareSystem
    {
        public double TinhToanLuongThucAn(Koi koi)
        {
            if (koi.Weight <= 0)
            {
                return 0; // Thất bại nếu trọng lượng không hợp lệ
            }
            return koi.Weight * 0.02; // Giả sử 2% trọng lượng cơ thể
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
        public void TestTinhToanLuongThucAn_ThanhCong()
        {
            var koi = new Koi { Weight = 2.0 }; // 2kg
            var expectedAmount = 0.04; // Giả sử 2% khối lượng cơ thể
            var result = _koiCareSystem.TinhToanLuongThucAn(koi);
            Assert.AreEqual(expectedAmount, result, 0.001, "Tính toán lượng thức ăn thành công.");
        }

        [TestMethod]
        public void TestTinhToanLuongThucAn_ThatBai_TrongLuongAm()
        {
            var koi = new Koi { Weight = -1.0 };
            var result = _koiCareSystem.TinhToanLuongThucAn(koi);
            Assert.AreEqual(0, result, "Tính toán lượng thức ăn thất bại do trọng lượng không hợp lệ.");
        }
    }
}