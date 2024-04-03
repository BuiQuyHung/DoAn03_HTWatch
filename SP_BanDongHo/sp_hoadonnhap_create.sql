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

CREATE PROCEDURE [dbo].[sp_hoadonnhap_create]
    @MaNV NVARCHAR(50), 
    @MaNPP NVARCHAR(250),
    @NgayNhap DATETIME,
    @TongTien DECIMAL(18, 0), 
    @list_json_chitiethdn NVARCHAR(MAX)
AS
BEGIN
    DECLARE @MaHDNhap INT;

    INSERT INTO HoaDonNhap
        (MaNV, 
         MaNPP,
         NgayNhap,
         TongTien
        )
    VALUES
        (@MaNV, 
         @MaNPP,
         @NgayNhap,
         @TongTien
        );

    SET @MaHDNhap = (SELECT SCOPE_IDENTITY());

    IF (@list_json_chitiethdn IS NOT NULL)
    BEGIN
        INSERT INTO ChiTietHDNhap
            (MaHDNhap, 
             MaSP,
             SoLuong,
             DonGia,
             ThanhTien
            )
        SELECT  
            @MaHDNhap,
            JSON_VALUE(chitiethdn.value, '$.MaSP'),
            JSON_VALUE(chitiethdn.value, '$.SoLuong'), 
            JSON_VALUE(chitiethdn.value, '$.DonGia'),
            JSON_VALUE(chitiethdn.value, '$.ThanhTien')
        FROM 
            OPENJSON(@list_json_chitiethdn) AS chitiethdn;
    END;

    SELECT '';
END;
GO
