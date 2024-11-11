namespace KoiCareSystem
{
    public class KoiCareSystem
    {
        public double TinhToanLuongMuoi(Ho ho)
        {
            if (ho.Capacity <= 0)
            {
                return 0; // Thất bại nếu dung tích không hợp lệ
            }
            return ho.Capacity * 3.0 / 1000; // Giả sử 3g muối/lít
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
        public void TestTinhToanLuongMuoi_ThanhCong()
        {
            var ho = new Ho { Capacity = 1000 }; // 1000 lít
            var expectedAmount = 3.0; // Giả sử 3g/lít
            var result = _koiCareSystem.TinhToanLuongMuoi(ho);
            Assert.AreEqual(expectedAmount, result, 0.001, "Tính toán lượng muối thành công.");
        }

        [TestMethod]
        public void TestTinhToanLuongMuoi_ThatBai_DungTichAm()
        {
            var ho = new Ho { Capacity = -500 };
            var result = _koiCareSystem.TinhToanLuongMuoi(ho);
            Assert.AreEqual(0, result, "Tính toán lượng muối thất bại do dung tích không hợp lệ.");
        }
    }
}