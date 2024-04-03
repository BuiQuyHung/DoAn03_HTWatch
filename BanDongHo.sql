CREATE DATABASE BanDongHo
USE BanDongHo
GO	

CREATE TABLE DanhMucSanPham
(
  MaDanhMuc INT IDENTITY(1,1) NOT NULL,
  TenDanhMuc NVARCHAR(50) NOT NULL,
  CONSTRAINT PK_DanhMucSanPham PRIMARY KEY (MaDanhMuc)
)
CREATE TABLE KhachHang
(
  MaKH INT IDENTITY(1,1) NOT NULL,
  TenKH NVARCHAR(50),
  DiaChi NVARCHAR(50),
  DienThoai NVARCHAR(50),
  CONSTRAINT PK_KhachHang PRIMARY KEY (MaKH)
)
CREATE TABLE SanPham
(
  MaSP INT IDENTITY(1,1) NOT NULL,
  TenSP NVARCHAR(50) NOT NULL,
  MaDanhMuc INT,
  HinhAnh NVARCHAR(200),
  GiaSP INT,
  SoLuong INT NOT NULL,
  MaMenu INT NOT NULL ,
  Mota NVARCHAR(200),
  CONSTRAINT PK_SanPham PRIMARY KEY (MaSP),
  CONSTRAINT FK_SanPham_DanhMucSanPham FOREIGN KEY (MaDanhMuc) REFERENCES DanhMucSanPham(MaDanhMuc)
)
CREATE TABLE NhanVien
(
  MaNV INT IDENTITY(1,1) NOT NULL,
  TenNV NVARCHAR(50) NOT NULL,
  GioiTinh NVARCHAR(10) NOT NULL,
  DiaChi NVARCHAR(50) NOT NULL,
  DienThoai NVARCHAR(50) NOT NULL,
  NgaySinh DATE,
  CONSTRAINT PK_NhanVien PRIMARY KEY (MaNV)
)
CREATE TABLE HoaDonBan
(
  MaHDBan INT IDENTITY(1,1) NOT NULL,
  NgayBan DATE,
  MaNV INT,
  MaKH INT,
  TongTien DECIMAL(18, 0),
  CONSTRAINT PK_HoaDonBan PRIMARY KEY (MaHDBan),
  CONSTRAINT FK_HoaDonBan_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
  CONSTRAINT FK_HoaDonBan_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
)
CREATE TABLE ChiTietHDBan
(
  MaCTHDBan INT IDENTITY(1,1) NOT NULL,
  MaHDBan INT,
  MaSP INT,
  SoLuong INT ,
  DonGia FLOAT ,
  ThanhTien FLOAT ,
  CONSTRAINT PK_ChiTietHDBan PRIMARY KEY (MaCTHDBan),
  CONSTRAINT FK_ChiTietHDBan_HoaDonBan FOREIGN KEY (MaHDBan) REFERENCES HoaDonBan(MaHDBan),
  CONSTRAINT FK_ChiTietHDBan_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
CREATE TABLE NhaPhanPhoi
(
  MaNPP INT IDENTITY(1,1) NOT NULL,
  TenNPP NVARCHAR(50) NOT NULL,
  DiaChi NVARCHAR(50) NOT NULL,
  DienThoai NVARCHAR(50) NOT NULL,
  CONSTRAINT PK_NhaPhanPhoi PRIMARY KEY (MaNPP)
)
CREATE TABLE HoaDonNhap
(
  MaHDNhap INT IDENTITY(1,1) NOT NULL,
  NgayNhap DATE,
  MaNV INT,
  MaNPP INT,
  TongTien DECIMAL(18, 0),
  CONSTRAINT PK_HoaDonNhap PRIMARY KEY (MaHDNhap),
  CONSTRAINT FK_HoaDonNhap_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
  CONSTRAINT FK_HoaDonNhap_NhaPhanPhoi FOREIGN KEY (MaNPP) REFERENCES NhaPhanPhoi(MaNPP)
)
CREATE TABLE ChiTietHDNhap
(
  MaCTHDNhap INT IDENTITY(1,1) NOT NULL,
  MaHDNhap INT,
  MaSP INT,
  SoLuong INT ,
  DonGia FLOAT ,
  ThanhTien FLOAT ,
  CONSTRAINT PK_ChiTietHDNhap PRIMARY KEY (MaCTHDNhap),
  CONSTRAINT FK_ChiTietHDNhap_HoaDonNhap FOREIGN KEY (MaHDNhap) REFERENCES HoaDonNhap(MaHDNhap),
  CONSTRAINT FK_ChiTietHDNhap_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
CREATE TABLE NguoiDung
(
  UserID NVARCHAR(50),
  Pass NVARCHAR(50) NOT NULL,
  Per INT NOT NULL,
  CONSTRAINT PK_NguoiDung PRIMARY KEY (UserID),	
)
CREATE TABLE TinTuc (
    MaTinTuc INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TieuDe NVARCHAR(250),
    NoiDung NVARCHAR(MAX),
    ThoiGianDang DATETIME,
    UserID NVARCHAR(50),
    FOREIGN KEY (UserID) REFERENCES NguoiDung(UserID)
)
CREATE TABLE KhuyenMai (
	MaKhuyenMai INT IDENTITY(1,1) PRIMARY KEY,
    MaSP INT,
    KhuyenMai FLOAT,
    NgayBatDau DATE,
    NgayKetThuc DATE,
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
CREATE TABLE ChiTietAnh (
	MaCTA INT IDENTITY(1,1) PRIMARY KEY,
    MaSP INT,
    Anh VARCHAR(500),
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
CREATE TABLE Menu (
	MaMenu INT IDENTITY(1,1) PRIMARY KEY,
    TenMenu NVARCHAR(50),
    Cap INT,
	MaMenuCha INT,
	FOREIGN KEY (MaMenu) REFERENCES SanPham(MaSP)
)

-- Chèn 10 danh mục hãng đồng hồ vào bảng DanhMucSanPham
INSERT INTO DanhMucSanPham (TenDanhMuc) VALUES ('Rolex');
INSERT INTO DanhMucSanPham (TenDanhMuc) VALUES ('Omega');
INSERT INTO DanhMucSanPham (TenDanhMuc) VALUES ('Tag Heuer');
INSERT INTO DanhMucSanPham (TenDanhMuc) VALUES ('Seiko');
INSERT INTO DanhMucSanPham (TenDanhMuc) VALUES ('Casio');
INSERT INTO DanhMucSanPham (TenDanhMuc) VALUES ('Apple');
INSERT INTO DanhMucSanPham (TenDanhMuc) VALUES ('Citizen');
INSERT INTO DanhMucSanPham (TenDanhMuc) VALUES ('Tissot');
INSERT INTO DanhMucSanPham (TenDanhMuc) VALUES ('Patek Philippe');
INSERT INTO DanhMucSanPham (TenDanhMuc) VALUES ('Fossil');

-- Chèn 10 khách hàng vào bảng KhachHang
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES (N'Nguyễn Văn A', N'123 Đường ABC, Quận 1, TP.HCM', '0123456789');
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES (N'Trần Thị B', N'456 Đường XYZ, Quận 2, TP.HCM', '0987654321');
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES (N'Lê Văn C', N'789 Đường DEF, Quận 3, TP.HCM', '0369852147');
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES (N'Phạm Thị D', N'101 Đường GHI, Quận 4, TP.HCM', '0921384756');
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES (N'Hoàng Văn E', N'234 Đường KLM, Quận 5, TP.HCM', '0765432198');
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES (N'Đặng Thị F', N'567 Đường NOP, Quận 6, TP.HCM', '0857943216');
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES (N'Vũ Văn G', N'890 Đường QRS, Quận 7, TP.HCM', '0657483921');
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES (N'Ngô Thị H', N'123 Đường TUV, Quận 8, TP.HCM', '0432187659');
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES (N'Bùi Văn I', N'456 Đường WXY, Quận 9, TP.HCM', '0321895746');
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES (N'Trần Văn K', N'789 Đường ZAB, Quận 10, TP.HCM', '0976543218');

-- Chèn 10 nhân viên vào bảng NhanVien
INSERT INTO NhanVien (TenNV, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'Nguyễn Văn Nam', N'Nam', N'123 Đường ABC, Quận 1, TP.HCM', '0123456789', '1990-05-15');
INSERT INTO NhanVien (TenNV, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'Trần Thị Hương', N'Nữ', N'456 Đường XYZ, Quận 2, TP.HCM', '0987654321', '1985-10-25');
INSERT INTO NhanVien (TenNV, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'Lê Văn Đức', N'Nam', N'789 Đường DEF, Quận 3, TP.HCM', '0369852147', '1992-03-12');
INSERT INTO NhanVien (TenNV, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'Phạm Thị Lan', N'Nữ', N'101 Đường GHI, Quận 4, TP.HCM', '0921384756', '1988-07-08');
INSERT INTO NhanVien (TenNV, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'Hoàng Văn Hùng', N'Nam', N'234 Đường KLM, Quận 5, TP.HCM', '0765432198', '1995-11-30');
INSERT INTO NhanVien (TenNV, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'Đặng Thị Mai', N'Nữ', N'567 Đường NOP, Quận 6, TP.HCM', '0857943216', '1993-09-20');
INSERT INTO NhanVien (TenNV, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'Vũ Văn Tuấn', N'Nam', N'890 Đường QRS, Quận 7, TP.HCM', '0657483921', '1991-01-05');
INSERT INTO NhanVien (TenNV, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'Ngô Thị Lệ', N'Nữ', N'123 Đường TUV, Quận 8, TP.HCM', '0432187659', '1989-12-18');
INSERT INTO NhanVien (TenNV, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'Bùi Văn Thành', N'Nam', N'456 Đường WXY, Quận 9, TP.HCM', '0321895746', '1994-08-02');
INSERT INTO NhanVien (TenNV, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'Trần Thị Thảo', N'Nữ', N'789 Đường ZAB, Quận 10, TP.HCM', '0976543218', '1987-06-28');

-- Chèn 5 bản ghi người dùng vào bảng NguoiDung
INSERT INTO NguoiDung (UserID, Pass, Per)
VALUES
  ('Admin001', '123456', 1),
  ('Admin002', '123456', 1),
  ('NV003', '123456', 2),
  ('NV004', '123456', 2),
  ('NV005', '123456', 2);

-- Chèn 10 bản ghi tin tức đồng hồ vào bảng TinTuc
INSERT INTO TinTuc (TieuDe, NoiDung, ThoiGianDang, UserID) VALUES (N'Giới thiệu bộ sưu tập mới của Rolex', N'Rolex vừa ra mắt bộ sưu tập đồng hồ mới với các mẫu thiết kế độc đáo và sang trọng.', '2024-03-29 10:00:00', 'Admin001');
INSERT INTO TinTuc (TieuDe, NoiDung, ThoiGianDang, UserID) VALUES (N'Những xu hướng mới trong thế giới đồng hồ năm 2024', N'Năm 2024 đánh dấu sự phát triển mạnh mẽ của các xu hướng mới trong thế giới đồng hồ, từ đồng hồ thông minh đến đồng hồ cơ truyền thống.', '2024-03-28 09:30:00', 'Admin001');
INSERT INTO TinTuc (TieuDe, NoiDung, ThoiGianDang, UserID) VALUES (N'Casio ra mắt dòng đồng hồ chống nước mới', N'Casio vừa giới thiệu dòng đồng hồ chống nước mới với khả năng chịu nước đến độ sâu lên đến 200 mét.', '2024-03-27 14:15:00', 'Admin001');
INSERT INTO TinTuc (TieuDe, NoiDung, ThoiGianDang, UserID) VALUES (N'Omega trình làng phiên bản giới hạn đặc biệt', N'Omega vừa ra mắt phiên bản giới hạn đặc biệt của mẫu đồng hồ Seamaster với chỉ sản xuất 500 chiếc trên toàn thế giới.', '2024-03-26 11:45:00', 'Admin001');
INSERT INTO TinTuc (TieuDe, NoiDung, ThoiGianDang, UserID) VALUES (N'Apple Watch Series 8 sẽ có màn hình mở rộng', N'Thông tin rò rỉ cho biết Apple sẽ trang bị màn hình mở rộng hơn cho dòng đồng hồ thông minh Series 8 sắp tới.', '2024-03-25 16:20:00', 'Admin001');
INSERT INTO TinTuc (TieuDe, NoiDung, ThoiGianDang, UserID) VALUES (N'Đồng hồ Patek Philippe - Biểu tượng của sang trọng', N'Patek Philippe tiếp tục khẳng định vị thế của mình trong thế giới đồng hồ với những mẫu thiết kế độc đáo và sang trọng.', '2024-03-24 13:10:00', 'Admin001');
INSERT INTO TinTuc (TieuDe, NoiDung, ThoiGianDang, UserID) VALUES (N'Bí mật từ bên trong nhà máy đồng hồ Rolex', N'Một cái nhìn sâu hơn vào quy trình sản xuất của nhà máy đồng hồ Rolex - nơi nơi ra đời những chiếc đồng hồ nổi tiếng trên thế giới.', '2024-03-23 08:00:00', 'Admin001');
INSERT INTO TinTuc (TieuDe, NoiDung, ThoiGianDang, UserID) VALUES (N'Seiko tung ra bộ sưu tập đặc biệt kỷ niệm 140 năm thành lập', N'Seiko vừa ra mắt bộ sưu tập đặc biệt để kỷ niệm 140 năm thành lập của hãng, gồm các mẫu đồng hồ độc đáo.', '2024-03-22 09:45:00', 'Admin001');
INSERT INTO TinTuc (TieuDe, NoiDung, ThoiGianDang, UserID) VALUES (N'Những tính năng mới trên đồng hồ thông minh Samsung Galaxy Watch 5', N'Samsung Galaxy Watch 5 sẽ có một loạt tính năng mới như đo nhiệt độ cơ thể và theo dõi chất lượng giấc ngủ.', '2024-03-21 12:30:00', 'Admin001');
INSERT INTO TinTuc (TieuDe, NoiDung, ThoiGianDang, UserID) VALUES (N'Cách chăm sóc đồng hồ cơ để nó luôn hoạt động tốt', N'Một số mẹo nhỏ giúp bạn chăm sóc đồng hồ cơ của mình để nó luôn hoạt động tốt và bền bỉ.', '2024-03-20 15:00:00', 'Admin001');

-- Chèn 5 bản ghi Menu
INSERT INTO Menu (TenMenu, Cap, MaMenuCha) VALUES (N'Đồng hồ nam', 1, NULL);
INSERT INTO Menu (TenMenu, Cap, MaMenuCha) VALUES (N'Đồng hồ nữ', 1, NULL);
INSERT INTO Menu (TenMenu, Cap, MaMenuCha) VALUES (N'Đồng hồ thể thao', 1, NULL);
INSERT INTO Menu (TenMenu, Cap, MaMenuCha) VALUES (N'Đồng hồ cơ', 1, NULL);
INSERT INTO Menu (TenMenu, Cap, MaMenuCha) VALUES (N'Đồng hồ thông minh', 1, NULL);

-- Chèn 20 bản ghi vào bảng SanPham kết hợp từ các dữ liệu đã cung cấp
INSERT INTO SanPham (TenSP, MaDanhMuc, HinhAnh, GiaSP, SoLuong, MaMenu, Mota)
VALUES 
(N'Đồng hồ Rolex Nam 1', 1, 'rolex1.jpg', 1500, 10, 1, N'Đồng hồ nam chính hãng Rolex'),
(N'Đồng hồ Rolex Nam 2', 1, 'rolex2.jpg', 1600, 8, 1, N'Đồng hồ nam chính hãng Rolex'),
(N'Đồng hồ Omega Nam 1', 1, 'omega1.jpg', 1200, 15, 1, N'Đồng hồ nam chính hãng Omega'),
(N'Đồng hồ Omega Nam 2', 1, 'omega2.jpg', 1300, 12, 1, N'Đồng hồ nam chính hãng Omega'),
(N'Đồng hồ Rolex Nam 3', 1, 'rolex1.jpg', 1500, 10, 1, N'Đồng hồ nam chính hãng Rolex'),
(N'Đồng hồ Rolex Nam 4', 1, 'rolex2.jpg', 1600, 8, 1, N'Đồng hồ nam chính hãng Rolex'),
(N'Đồng hồ Omega Nam 3', 1, 'omega1.jpg', 1200, 15, 1, N'Đồng hồ nam chính hãng Omega'),
(N'Đồng hồ Omega Nam 4', 1, 'omega2.jpg', 1300, 12, 1, N'Đồng hồ nam chính hãng Omega'),
(N'Đồng hồ Rolex Nam 5', 1, 'rolex1.jpg', 1500, 10, 1, N'Đồng hồ nam chính hãng Rolex'),
(N'Đồng hồ Rolex Nam 6', 1, 'rolex2.jpg', 1600, 8, 1, N'Đồng hồ nam chính hãng Rolex'),
(N'Đồng hồ Omega Nam 5', 1, 'omega1.jpg', 1200, 15, 1, N'Đồng hồ nam chính hãng Omega'),
(N'Đồng hồ Omega Nam 6', 1, 'omega2.jpg', 1300, 12, 1, N'Đồng hồ nam chính hãng Omega'),
(N'Đồng hồ Rolex Nam 7', 1, 'rolex1.jpg', 1500, 10, 1, N'Đồng hồ nam chính hãng Rolex'),
(N'Đồng hồ Rolex Nam 8', 1, 'rolex2.jpg', 1600, 8, 1, N'Đồng hồ nam chính hãng Rolex'),
(N'Đồng hồ Omega Nam 7', 1, 'omega1.jpg', 1200, 15, 1, N'Đồng hồ nam chính hãng Omega'),
(N'Đồng hồ Omega Nam 8', 1, 'omega2.jpg', 1300, 12, 1, N'Đồng hồ nam chính hãng Omega'),
(N'Đồng hồ Rolex Nam 9', 1, 'rolex1.jpg', 1500, 10, 1, N'Đồng hồ nam chính hãng Rolex'),
(N'Đồng hồ Rolex Nam 10', 1, 'rolex2.jpg', 1600, 8, 1, N'Đồng hồ nam chính hãng Rolex'),
(N'Đồng hồ Omega Nam 9', 1, 'omega1.jpg', 1200, 15, 1, N'Đồng hồ nam chính hãng Omega'),
(N'Đồng hồ Omega Nam 10', 1, 'omega2.jpg', 1300, 12, 1, N'Đồng hồ nam chính hãng Omega');

-- Chèn 10 bản ghi vào bảng KhuyenMai với mã sản phẩm như đã cho trong bảng SanPham
INSERT INTO KhuyenMai (MaSP, KhuyenMai, NgayBatDau, NgayKetThuc) VALUES (1, 0.1, '2024-04-01', '2024-04-07');
INSERT INTO KhuyenMai (MaSP, KhuyenMai, NgayBatDau, NgayKetThuc) VALUES (2, 0.15, '2024-04-03', '2024-04-10');
INSERT INTO KhuyenMai (MaSP, KhuyenMai, NgayBatDau, NgayKetThuc) VALUES (3, 0.2, '2024-04-05', '2024-04-12');
INSERT INTO KhuyenMai (MaSP, KhuyenMai, NgayBatDau, NgayKetThuc) VALUES (4, 0.1, '2024-04-02', '2024-04-09');
INSERT INTO KhuyenMai (MaSP, KhuyenMai, NgayBatDau, NgayKetThuc) VALUES (5, 0.2, '2024-04-04', '2024-04-11');
INSERT INTO KhuyenMai (MaSP, KhuyenMai, NgayBatDau, NgayKetThuc) VALUES (6, 0.1, '2024-04-01', '2024-04-07');
INSERT INTO KhuyenMai (MaSP, KhuyenMai, NgayBatDau, NgayKetThuc) VALUES (7, 0.15, '2024-04-03', '2024-04-10');
INSERT INTO KhuyenMai (MaSP, KhuyenMai, NgayBatDau, NgayKetThuc) VALUES (8, 0.2, '2024-04-05', '2024-04-12');
INSERT INTO KhuyenMai (MaSP, KhuyenMai, NgayBatDau, NgayKetThuc) VALUES (9, 0.1, '2024-04-02', '2024-04-09');
INSERT INTO KhuyenMai (MaSP, KhuyenMai, NgayBatDau, NgayKetThuc) VALUES (10, 0.2, '2024-04-04', '2024-04-11');

-- Chèn 10 bản ghi vào bảng NhaPhanPhoi
INSERT INTO NhaPhanPhoi (TenNPP, DiaChi, DienThoai) VALUES (N'Công ty TNHH Đồng Hồ Phong', N'123 Đường ABC, Quận 1, TP.HCM', '0123456789');
INSERT INTO NhaPhanPhoi (TenNPP, DiaChi, DienThoai) VALUES (N'Công ty Cổ Phần Đồng Hồ Ánh Sáng', N'456 Đường XYZ, Quận 2, TP.HCM', '0987654321');
INSERT INTO NhaPhanPhoi (TenNPP, DiaChi, DienThoai) VALUES (N'Cửa hàng Đồng Hồ Minh Châu', N'789 Đường DEF, Quận 3, TP.HCM', '0369852147');
INSERT INTO NhaPhanPhoi (TenNPP, DiaChi, DienThoai) VALUES (N'Cửa hàng Đồng Hồ Tuấn Anh', N'101 Đường GHI, Quận 4, TP.HCM', '0921384756');
INSERT INTO NhaPhanPhoi (TenNPP, DiaChi, DienThoai) VALUES (N'Công ty TNHH Đồng Hồ Đức An', N'234 Đường KLM, Quận 5, TP.HCM', '0765432198');
INSERT INTO NhaPhanPhoi (TenNPP, DiaChi, DienThoai) VALUES (N'Công ty Cổ Phần Đồng Hồ Hoàng Gia', N'567 Đường NOP, Quận 6, TP.HCM', '0857943216');
INSERT INTO NhaPhanPhoi (TenNPP, DiaChi, DienThoai) VALUES (N'Cửa hàng Đồng Hồ Anh Khoa', N'890 Đường QRS, Quận 7, TP.HCM', '0657483921');
INSERT INTO NhaPhanPhoi (TenNPP, DiaChi, DienThoai) VALUES (N'Công ty TNHH Đồng Hồ Tâm Minh', N'123 Đường TUV, Quận 8, TP.HCM', '0432187659');
INSERT INTO NhaPhanPhoi (TenNPP, DiaChi, DienThoai) VALUES (N'Cửa hàng Đồng Hồ Long Thành', N'456 Đường WXY, Quận 9, TP.HCM', '0321895746');
INSERT INTO NhaPhanPhoi (TenNPP, DiaChi, DienThoai) VALUES (N'Công ty TNHH Đồng Hồ Thành Đạt', N'789 Đường ZAB, Quận 10, TP.HCM', '0976543218');


-- Thêm dữ liệu vào bảng HoaDonBan
INSERT INTO HoaDonBan (NgayBan, MaNV, MaKH, TongTien)
VALUES ('2024-04-01', 1, 1, 1500000);

-- Lấy mã hóa đơn vừa thêm
DECLARE @MaHoaDonBan INT = SCOPE_IDENTITY();

-- Thêm dữ liệu vào bảng ChiTietHDBan
INSERT INTO ChiTietHDBan (MaHDBan, MaSP, SoLuong, DonGia, ThanhTien)
VALUES 
    (@MaHoaDonBan, 1, 2, 500000, 1000000), -- Chi tiết sản phẩm 1
    (@MaHoaDonBan, 2, 1, 600000, 600000);   -- Chi tiết sản phẩm 2

-- Thêm bản ghi thứ 2 đến bản ghi thứ 10
DECLARE @i INT = 2;
WHILE @i <= 10
BEGIN
    -- Thêm dữ liệu vào bảng HoaDonBan
    INSERT INTO HoaDonBan (NgayBan, MaNV, MaKH, TongTien)
    VALUES (DATEADD(DAY, @i, '2024-04-01'), 1, 1, 1500000 + (@i * 100000));

    -- Lấy mã hóa đơn vừa thêm
    DECLARE @MaHoaDonBan INT = SCOPE_IDENTITY();

    -- Thêm dữ liệu vào bảng ChiTietHDBan
    INSERT INTO ChiTietHDBan (MaHDBan, MaSP, SoLuong, DonGia, ThanhTien)
    VALUES 
        (@MaHoaDonBan, 1, 2, 500000, 1000000 + (@i * 100000)), -- Chi tiết sản phẩm 1
        (@MaHoaDonBan, 2, 1, 600000, 600000 + (@i * 100000));   -- Chi tiết sản phẩm 2

    SET @i = @i + 1;
END;

-- Thêm dữ liệu vào bảng HoaDonNhap
INSERT INTO HoaDonNhap (NgayNhap, MaNV, MaNPP, TongTien)
VALUES ('2024-04-01', 1, 1, 1500000);

-- Lấy mã hóa đơn vừa thêm
DECLARE @MaHoaDonNhap INT = SCOPE_IDENTITY();

-- Thêm dữ liệu vào bảng ChiTietHDBan
INSERT INTO ChiTietHDNhap (MaHDNhap, MaSP, SoLuong, DonGia, ThanhTien)
VALUES 
    (@MaHoaDonNhap, 1, 2, 500000, 1000000), -- Chi tiết sản phẩm 1
    (@MaHoaDonNhap, 2, 1, 600000, 600000);   -- Chi tiết sản phẩm 2
-- Thêm bản ghi thứ 2 đến bản ghi thứ 10
DECLARE @i INT = 2;
WHILE @i <= 10
BEGIN
    -- Thêm dữ liệu vào bảng HoaDonNhap
    INSERT INTO HoaDonNhap (NgayNhap, MaNV, MaNPP, TongTien)
    VALUES (DATEADD(DAY, @i, '2024-04-01'), 1, 1, 1500000 + (@i * 100000));

    -- Lấy mã hóa đơn vừa thêm
    DECLARE @MaHoaDonNhap INT = SCOPE_IDENTITY();

    -- Thêm dữ liệu vào bảng ChiTietHDNhap
    INSERT INTO ChiTietHDNhap (MaHDNhap, MaSP, SoLuong, DonGia, ThanhTien)
    VALUES 
        (@MaHoaDonNhap, 1, 2, 500000, 1000000 + (@i * 100000)), -- Chi tiết sản phẩm 1
        (@MaHoaDonNhap, 2, 1, 600000, 600000 + (@i * 100000));   -- Chi tiết sản phẩm 2

    SET @i = @i + 1;
END;
