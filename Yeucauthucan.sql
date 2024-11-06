-- Xóa bảng YeuCauThucAn nếu đã tồn tại
IF OBJECT_ID('YeuCauThucAn', 'U') IS NOT NULL
    DROP TABLE YeuCauThucAn;

-- Tạo bảng YeuCauThucAn với các cột bằng tiếng Việt
CREATE TABLE YeuCauThucAn (
    MaYeuCau INT PRIMARY KEY IDENTITY(1,1),
    MaCa INT,
    GiaiDoanPhatTrien VARCHAR(50),
    LuongThucAn DECIMAL(5, 2),
    FOREIGN KEY (MaCa) REFERENCES CaKoi(MaCa) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Thêm dữ liệu mẫu vào bảng YeuCauThucAn
INSERT INTO YeuCauThucAn (MaCa, GiaiDoanPhatTrien, LuongThucAn) VALUES
(1, 'Ấu trùng', 50.00),
(2, 'Trưởng thành', 100.00),
(3, 'Ấu trùng', 45.00);
