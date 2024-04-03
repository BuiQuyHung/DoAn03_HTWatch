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

CREATE PROCEDURE [dbo].[sp_hoadonban_create]
    @MaNV NVARCHAR(50), 
    @MaKH NVARCHAR(250),
    @NgayBan DATETIME,
    @TongTien DECIMAL(18, 0), 
    @list_json_chitiethdb NVARCHAR(MAX)
AS
BEGIN
    DECLARE @MaHDBan INT;

    INSERT INTO HoaDonBan
        (MaNV, 
         MaKH,
         NgayBan,
         TongTien
        )
    VALUES
        (@MaNV, 
         @MaKH,
         @NgayBan,
         @TongTien
        );

    SET @MaHDBan = (SELECT SCOPE_IDENTITY());

    IF (@list_json_chitiethdb IS NOT NULL)
    BEGIN
        INSERT INTO ChiTietHDBan
            (MaHDBan, 
             MaSP,
             SoLuong,
             DonGia,
             ThanhTien
            )
        SELECT  
            @MaHDBan,
            JSON_VALUE(chitiethdb.value, '$.MaSP'),
            JSON_VALUE(chitiethdb.value, '$.SoLuong'), 
            JSON_VALUE(chitiethdb.value, '$.DonGia'),
            JSON_VALUE(chitiethdb.value, '$.ThanhTien')
        FROM 
            OPENJSON(@list_json_chitiethdb) AS chitiethdb;
    END;

    SELECT '';
END;
GO
