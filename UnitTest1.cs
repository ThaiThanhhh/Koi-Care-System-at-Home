using KoiCareSystem.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        public bool ThemHo(Ho ho)
        {
            if (ho.Capacity <= 0)
            {
                return false; // Thất bại nếu dung tích không hợp lệ
            }
            return true; // Thành công nếu dung tích hợp lệ
        }

        public bool ThemThongSoNuoc(ThongSoNuoc thongSo)
        {
            if (thongSo.pH < 0 || thongSo.pH > 9)
            {
                return false; // Thất bại nếu pH không hợp lệ
            }
            return true; // Thành công nếu pH hợp lệ
        }

        public double TinhToanLuongThucAn(Koi koi)
        {
            if (koi.Weight <= 0)
            {
                return 0; // Thất bại nếu trọng lượng không hợp lệ
            }
            return koi.Weight * 0.02; // Giả sử 2% trọng lượng cơ thể
        }

        public double TinhToanLuongMuoi(Ho ho)
        {
            if (ho.Capacity <= 0)
            {
                return 0; // Thất bại nếu dung tích không hợp lệ
            }
            return ho.Capacity * 3.0 / 1000; // Giả sử 3g muối/lít
        }

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

    public class ThongSoNuoc
    {
        public int Temperature { get; set; }
        public double pH { get; set; }
        public int O2 { get; set; }
        public double NO2 { get; set; }
    }

    public class Ho
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }

    public class Koi
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Breed { get; set; }
    }
}
