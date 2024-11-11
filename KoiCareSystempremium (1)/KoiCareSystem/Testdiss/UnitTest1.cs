using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoiCareSystem;
using System.Collections.Generic;

namespace KoiCareSystem.Tests
{
    [TestClass]
    public class UserManagerTests
    {
        [TestMethod]
        public void TestThemKoi_ThanhCong()
        {
            // Arrange
            var userManager = new UserManager();
            var userName = "nguoimoi";
            var password = "Matkhau123";

            // Act
            var result = userManager.DangKyNguoiDung(userName, password);

            // Assert
            Assert.IsTrue(result, "Đăng ký người dùng thành công.");
        }

        [TestMethod]
        public void TestDangKyNguoiDung_ThatBai_TenNguoiDungTonTai()
        {
            // Arrange
            var userManager = new UserManager();
            var userName = "tontai"; // Giả định tên người dùng này đã tồn tại
            var password = "Matkhau123";

            // Đăng ký trước để tên người dùng tồn tại
            userManager.DangKyNguoiDung(userName, password);

            // Act
            var result = userManager.DangKyNguoiDung(userName, password);

            // Assert
            Assert.IsFalse(result, "Đăng ký thất bại do tên người dùng đã tồn tại.");
        }
    }

    public class UserManager
    {
        private readonly HashSet<string> existingUsers = new HashSet<string>();

        public bool DangKyNguoiDung(string userName, string password)
        {
            // Kiểm tra nếu tên người dùng đã tồn tại
            if (existingUsers.Contains(userName))
            {
                return false; // Đăng ký thất bại do tên người dùng đã tồn tại
            }

            // Thêm tên người dùng mới vào danh sách
            existingUsers.Add(userName);
            return true; // Đăng ký thành công
        }
    }
}
