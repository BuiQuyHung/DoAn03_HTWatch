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
CREATE PROCEDURE <Procedure_Name, sysname, ProcedureName> 
	-- Add the parameters for the stored procedure here
	<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
END
GO

CREATE PROCEDURE sp_BaoCaoDoanhThu
    @Ngay DATE = NULL,
    @Thang INT = NULL,
    @Nam INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        SanPham.MaSP AS MaSanPham,
        SanPham.TenSP AS TenSanPham,
        KhachHang.TenKH AS TenKhachHang,
        NhanVien.TenNV AS TenNhanVien,
        SUM(ChiTietHDBan.ThanhTien) AS DoanhThu
    FROM 
        ChiTietHDBan
    INNER JOIN 
        HoaDonBan ON ChiTietHDBan.MaHDBan = HoaDonBan.MaHDBan
    INNER JOIN 
        SanPham ON ChiTietHDBan.MaSP = SanPham.MaSP
    INNER JOIN 
        KhachHang ON HoaDonBan.MaKH = KhachHang.MaKH
    INNER JOIN 
        NhanVien ON HoaDonBan.MaNV = NhanVien.MaNV
    WHERE 
        (@Ngay IS NULL OR CONVERT(DATE, HoaDonBan.NgayBan) = @Ngay)
        AND (@Thang IS NULL OR MONTH(HoaDonBan.NgayBan) = @Thang)
        AND (@Nam IS NULL OR YEAR(HoaDonBan.NgayBan) = @Nam)
    GROUP BY 
        SanPham.MaSP,
        SanPham.TenSP,
        KhachHang.TenKH,
        NhanVien.TenNV
    ORDER BY 
        SanPham.MaSP;
END;

EXEC sp_BaoCaoDoanhThu @Ngay = '2023-01-01';
EXEC sp_BaoCaoDoanhThu @Nam = 2023;
EXEC sp_BaoCaoDoanhThu @Thang = '1';