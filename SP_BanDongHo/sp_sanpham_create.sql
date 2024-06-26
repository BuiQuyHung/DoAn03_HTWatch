USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_sanpham_create]    Script Date: 06/05/2024 8:31:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sanpham_create](
    @TenSP NVARCHAR(50),
    @MaDanhMuc INT,
    @GiaSP INT,
    @SoLuong INT,
    @Mota NVARCHAR(MAX),
    @HinhAnh NVARCHAR(200) -- Tham số cho hình ảnh
)
AS
BEGIN
    INSERT INTO SanPham(TenSP, MaDanhMuc, HinhAnh, GiaSP, SoLuong, Mota)
    VALUES (@TenSP, @MaDanhMuc, @HinhAnh, @GiaSP, @SoLuong, @Mota);
END;

