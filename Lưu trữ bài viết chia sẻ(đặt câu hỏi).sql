-- Xóa bảng TinTucBlog nếu đã tồn tại
IF OBJECT_ID('TinTucBlog', 'U') IS NOT NULL
    DROP TABLE TinTucBlog;

-- Tạo bảng TinTucBlog với các cột bằng tiếng Việt
CREATE TABLE TinTucBlog (
    MaBaiViet INT PRIMARY KEY IDENTITY(1,1),
    TieuDe VARCHAR(255),
    NoiDung TEXT,
    NgayDang DATE
);

-- Thêm dữ liệu mẫu vào bảng TinTucBlog
INSERT INTO TinTucBlog (TieuDe, NoiDung, NgayDang) VALUES
(N'Cách chăm sóc cá Koi vào mùa đông', N'Hướng dẫn chi tiết...', '2024-01-05'),
(N'Cách điều chỉnh pH cho hồ cá Koi', N'Giới thiệu các phương pháp...', '2024-01-06'),
(N'Các giống cá Koi phổ biến', N'Danh sách các giống...', '2024-01-07');
