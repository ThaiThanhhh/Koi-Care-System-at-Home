-- Xóa bảng DonHangSanPham nếu đã tồn tại
IF OBJECT_ID('DonHangSanPham', 'U') IS NOT NULL
    DROP TABLE DonHangSanPham;

-- Tạo bảng DonHangSanPham với các cột bằng tiếng Việt
CREATE TABLE DonHangSanPham (
    MaDonHang INT PRIMARY KEY IDENTITY(1,1),
    TenSanPham VARCHAR(100),
    LoaiSanPham VARCHAR(50),
    SoLuong INT,
    MaHo INT,
    FOREIGN KEY (MaHo) REFERENCES HoCaKoi(MaHo) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Thêm dữ liệu mẫu vào bảng DonHangSanPham
INSERT INTO DonHangSanPham (TenSanPham, LoaiSanPham, SoLuong, MaHo) VALUES
('Chất điều hòa nước', 'Cải thiện nước', 3, 1),
('Muối điều trị', 'Điều trị sức khỏe', 2, 2),
('Bộ lọc làm sạch', 'Cải thiện nước', 1, 3);
