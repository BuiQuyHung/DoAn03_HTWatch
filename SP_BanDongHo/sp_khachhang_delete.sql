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


CREATE PROCEDURE [dbo].[sp_khachhang_delete]
    @MaKH INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Lấy danh sách hóa đơn bán của khách hàng
    DECLARE @ListHoaDonBan TABLE (MaHDBan INT);

    INSERT INTO @ListHoaDonBan (MaHDBan)
    SELECT MaHDBan FROM HoaDonBan WHERE MaKH = @MaKH;

    -- Xóa chi tiết hóa đơn bán của các hóa đơn thuộc khách hàng
    DELETE FROM ChiTietHDBan WHERE MaHDBan IN (SELECT MaHDBan FROM @ListHoaDonBan);

    -- Xóa hóa đơn bán của khách hàng
    DELETE FROM HoaDonBan WHERE MaKH = @MaKH;

    -- Xóa khách hàng
    DELETE FROM KhachHang WHERE MaKH= @MaKH;
END;