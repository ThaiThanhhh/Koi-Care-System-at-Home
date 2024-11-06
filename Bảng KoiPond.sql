DROP TABLE HoCa;

CREATE TABLE HoCa (
    HoID INT PRIMARY KEY IDENTITY(1,1),
    TenHo VARCHAR(100) NOT NULL,
    HinhAnh VARCHAR(255),
    KichThuoc DECIMAL(10, 2),
    DoSau DECIMAL(10, 2),
    TheTich DECIMAL(10, 2),
    SoLuongOngThoatNuoc INT,
    CongSuatMayBom DECIMAL(10, 2)
);

INSERT INTO HoCa (TenHo, HinhAnh, KichThuoc, DoSau, TheTich, SoLuongOngThoatNuoc, CongSuatMayBom) VALUES
('Hồ A', 'imageA.jpg', 15.5, 1.2, 18.6, 2, 1.5),
('Hồ B', 'imageB.jpg', 12.3, 1.0, 12.3, 1, 1.0),
('Hồ C', 'imageC.jpg', 20.0, 1.5, 30.0, 3, 2.0);
