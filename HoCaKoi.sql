-- Xóa bảng HoCaKoi nếu đã tồn tại
IF OBJECT_ID('HoCaKoi', 'U') IS NOT NULL
    DROP TABLE HoCaKoi;

-- Tạo bảng HoCaKoi
CREATE TABLE HoCaKoi (
    MaHo INT PRIMARY KEY IDENTITY(1,1),
    TenHo VARCHAR(100) NOT NULL,
    HinhAnh VARCHAR(255),
    KichThuoc DECIMAL(10, 2),
    DoSau DECIMAL(10, 2),
    TheTich DECIMAL(10, 2),
    SoCongThoat INT,
    CongSuatMayBom DECIMAL(10, 2)
);

-- Thêm dữ liệu mẫu vào bảng HoCaKoi
INSERT INTO HoCaKoi (TenHo, HinhAnh, KichThuoc, DoSau, TheTich, SoCongThoat, CongSuatMayBom) VALUES
('Ho A', 'imageA.jpg', 15.5, 1.2, 18.6, 2, 1.5),
('Ho B', 'imageB.jpg', 12.3, 1.0, 12.3, 1, 1.0),
('Ho C', 'imageC.jpg', 20.0, 1.5, 30.0, 3, 2.0);
