-- Xóa bảng LichSuPhatTrienCa nếu đã tồn tại
IF OBJECT_ID('LichSuPhatTrienCa', 'U') IS NOT NULL
    DROP TABLE LichSuPhatTrienCa;

-- Tạo bảng LichSuPhatTrienCa với tên cột bằng tiếng Việt
CREATE TABLE LichSuPhatTrienCa (
    MaLich INT PRIMARY KEY IDENTITY(1,1),
    MaCa INT,
    NgayGhiNhan DATE,
    KichThuoc DECIMAL(10, 2),
    CanNang DECIMAL(10, 2),
    FOREIGN KEY (MaCa) REFERENCES CaKoi(MaCa) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Thêm dữ liệu mẫu vào bảng LichSuPhatTrienCa
INSERT INTO LichSuPhatTrienCa (MaCa, NgayGhiNhan, KichThuoc, CanNang) VALUES
(1, '2024-01-01', 26.5, 1.9),
(2, '2024-01-01', 30.5, 2.2),
(3, '2024-01-01', 21.0, 1.3);
