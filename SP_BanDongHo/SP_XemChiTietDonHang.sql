-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE sp_XemChiTietDonHang
    @MaDonHang INT
AS
BEGIN
    SELECT 
        d.MaDonHang, 
        d.TenKH, 
        d.NgayTao, 
        d.Email, 
        d.SDT, 
        d.DiaChi, 
        d.ThanhTien,
        c.MaChiTietDonHang, 
        c.MaSP, 
        c.GiaSP, 
        c.SoLuong, 
        c.TongTien AS TongTienSP
    FROM DonHang d
    INNER JOIN ChiTietDonHang c ON d.MaDonHang = c.MaDonHang
    WHERE d.MaDonHang = @MaDonHang;
END
EXEC sp_XemChiTietDonHang @MaDonHang = 1;
