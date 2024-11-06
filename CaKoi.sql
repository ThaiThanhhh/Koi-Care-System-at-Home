-- Xóa bảng CaKoi nếu đã tồn tại
IF OBJECT_ID('CaKoi', 'U') IS NOT NULL
    DROP TABLE CaKoi;

-- Tạo bảng CaKoi với các cột đúng tên
CREATE TABLE CaKoi (
    MaCa INT PRIMARY KEY IDENTITY(1,1),
    TenCa VARCHAR(100) NOT NULL,
    HinhAnh VARCHAR(255),
    KieuDang VARCHAR(50),
    Tuoi INT,
    KichThuoc DECIMAL(10, 2),
    CanNang DECIMAL(10, 2),
    GioiTinh VARCHAR(10),
    GiongCa VARCHAR(100),
    XuatXu VARCHAR(100),
    Gia DECIMAL(10, 2),
    MaHo INT,
    FOREIGN KEY (MaHo) REFERENCES HoCaKoi(MaHo) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Thêm dữ liệu mẫu vào bảng CaKoi
INSERT INTO CaKoi (TenCa, HinhAnh, KieuDang, Tuoi, KichThuoc, CanNang, GioiTinh, GiongCa, XuatXu, Gia, MaHo) VALUES
('Cá Koi 1', 'koi1.jpg', 'Thon', 2, 25.5, 1.8, 'Đực', 'Sanke', 'Nhật Bản', 200.00, 1),
('Cá Koi 2', 'koi2.jpg', 'Tròn', 3, 30.0, 2.1, 'Cái', 'Showa', 'Nhật Bản', 250.00, 2),
('Cá Koi 3', 'koi3.jpg', 'Thon', 1, 20.0, 1.2, 'Đực', 'Kohaku', 'Nhật Bản', 180.00, 3);
