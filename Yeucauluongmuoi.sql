-- Xóa bảng YeuCauMuoi nếu đã tồn tại
IF OBJECT_ID('YeuCauMuoi', 'U') IS NOT NULL
    DROP TABLE YeuCauMuoi;

-- Tạo bảng YeuCauMuoi với các cột bằng tiếng Việt
CREATE TABLE YeuCauMuoi (
    MaYeuCau INT PRIMARY KEY IDENTITY(1,1),
    MaHo INT,
    LuongMuoi DECIMAL(5, 2),
    FOREIGN KEY (MaHo) REFERENCES HoCaKoi(MaHo) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Thêm dữ liệu mẫu vào bảng YeuCauMuoi
INSERT INTO YeuCauMuoi (MaHo, LuongMuoi) VALUES
(1, 0.5),
(2, 0.6),
(3, 0.55);
