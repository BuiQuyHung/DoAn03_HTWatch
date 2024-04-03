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

CREATE PROCEDURE [dbo].[sp_sanpham_delete]
    @MaSP INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Xóa chi tiết hóa đơn bán của sản phẩm
    DELETE FROM ChiTietHDBan WHERE MaSP IN (SELECT MaSP FROM SanPham WHERE MaSP = @MaSP);

    -- Xóa chi tiết hóa đơn nhập của sản phẩm
    DELETE FROM ChiTietHDNhap WHERE MaSP IN (SELECT MaSP FROM SanPham WHERE MaSP = @MaSP);

    -- Xóa sản phẩm từ bảng Menu
    DELETE FROM Menu WHERE MaMenu IN (SELECT MaMenu FROM SanPham WHERE MaSP = @MaSP);

    -- Xóa sản phẩm
    DELETE FROM SanPham WHERE MaSP = @MaSP;
END;
