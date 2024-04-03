USE [BanDongHo]
GO

/****** Object:  StoredProcedure [dbo].[sp_khachhang_create]    Script Date: 29/03/2024 9:36:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_khachhang_create](
    @TenKH NVARCHAR(50),
    @DiaChi NVARCHAR(50),
    @DienThoai NVARCHAR(50)
)
AS
BEGIN
    INSERT INTO KhachHang(TenKH, DiaChi, DienThoai)
    VALUES (@TenKH, @DiaChi, @DienThoai);
END;
GO


