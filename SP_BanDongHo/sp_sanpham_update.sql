USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_sanpham_update]    Script Date: 07/05/2024 9:14:24 AM ******/
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
		UPDATE SanPham set TenSP= @TenSP where MaSP = @MaSP; 
    END;
