USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_sanpham_update]    Script Date: 08/05/2024 8:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_sanpham_update](
    @MaSP INT,
    @TenSP NVARCHAR(50),
    @MaDanhMuc INT,
    @GiaSP INT,
    @SoLuong INT,
    @Mota NVARCHAR(MAX),
    @HinhAnh NVARCHAR(200) -- Tham số cho hình ảnh
)
AS
BEGIN
    UPDATE SanPham 
    SET 
        TenSP = @TenSP,
        MaDanhMuc = @MaDanhMuc,
        GiaSP = @GiaSP,
        SoLuong = @SoLuong,
        Mota = @Mota,
        HinhAnh = @HinhAnh
    WHERE 
        MaSP = @MaSP; 
END;

