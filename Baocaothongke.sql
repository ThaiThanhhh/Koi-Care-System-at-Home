-- Xóa bảng BaoCaoThongKe nếu đã tồn tại
IF OBJECT_ID('BaoCaoThongKe', 'U') IS NOT NULL
    DROP TABLE BaoCaoThongKe;

-- Tạo bảng BaoCaoThongKe với các cột bằng tiếng Việt
CREATE TABLE BaoCaoThongKe (
    MaBaoCao INT PRIMARY KEY IDENTITY(1,1),
    LoaiBaoCao VARCHAR(50),
    NgayTao DATE,
    DuLieu NVARCHAR(MAX)  -- Lưu trữ dữ liệu JSON dưới dạng chuỗi văn bản
);

-- Thêm dữ liệu mẫu vào bảng BaoCaoThongKe
INSERT INTO BaoCaoThongKe (LoaiBaoCao, NgayTao, DuLieu) VALUES
('Thống kê tăng trưởng cá Koi', '2024-01-10', N'{"MaCa": 1, "TangTruong": "20%"}'),
('Tóm tắt chất lượng nước', '2024-01-10', N'{"MaHo": 2, "PH": 7.2}'),
('Báo cáo sử dụng muối', '2024-01-10', N'{"MaHo": 3, "LuongMuoi": 0.55}');
