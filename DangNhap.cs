namespace KoiCareSystem
{
    public class KoiCareSystem
    {
        public bool DangNhap(string username, string password)
        {
            if (username == "admin" && password == "password123")
            {
                return true; // Đăng nhập thành công nếu thông tin chính xác
            }
            return false; // Đăng nhập thất bại nếu thông tin không chính xác
        }
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
        public void TestDangNhap_ThanhCong()
        {
            var result = _koiCareSystem.DangNhap("admin", "password123");
            Assert.IsTrue(result, "Đăng nhập thành công với thông tin chính xác.");
        }

        [TestMethod]
        public void TestDangNhap_ThatBai_SaiThongTin()
        {
            var result = _koiCareSystem.DangNhap("user", "wrongpassword");
            Assert.IsFalse(result, "Đăng nhập thất bại do thông tin không chính xác.");
        }
    }
}