-- Xóa bảng ThongSoNuocHo nếu đã tồn tại
IF OBJECT_ID('ThongSoNuocHo', 'U') IS NOT NULL
    DROP TABLE ThongSoNuocHo;

-- Tạo bảng ThongSoNuocHo với các cột bằng tiếng Việt
CREATE TABLE ThongSoNuocHo (
    MaThongSo INT PRIMARY KEY IDENTITY(1,1),
    MaHo INT,
    NgayDo DATE,
    NhietDo DECIMAL(4, 2),
    DoMuoi DECIMAL(4, 2),
    PH DECIMAL(3, 2),
    Oxy DECIMAL(4, 2),
    Nitrit DECIMAL(4, 2),
    Nitrat DECIMAL(4, 2),
    Photphat DECIMAL(4, 2),
    FOREIGN KEY (MaHo) REFERENCES HoCaKoi(MaHo) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Thêm dữ liệu mẫu vào bảng ThongSoNuocHo
INSERT INTO ThongSoNuocHo (MaHo, NgayDo, NhietDo, DoMuoi, PH, Oxy, Nitrit, Nitrat, Photphat) VALUES
(1, '2024-01-02', 22.5, 0.5, 7.2, 5.5, 0.02, 0.05, 0.1),
(2, '2024-01-02', 23.0, 0.6, 7.0, 5.8, 0.03, 0.04, 0.12),
(3, '2024-01-02', 24.0, 0.55, 7.3, 5.6, 0.01, 0.06, 0.09);
