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

CREATE PROCEDURE [dbo].[sp_hoa_don_nhap_search]
(
    @page_index    INT, 
    @page_size     INT,
    @ma_hoa_don    INT,
    @ma_nhan_vien  INT,
    @ma_nha_phan_phoi INT
)
AS
BEGIN
    DECLARE @RecordCount BIGINT;

    IF (@page_size <> 0)
    BEGIN
        SET NOCOUNT ON;

        SELECT 
            (ROW_NUMBER() OVER(ORDER BY MaHDNhap ASC)) AS RowNumber, 
            hdn.MaHDNhap,
            hdn.NgayNhap,
            hdn.MaNV AS MaNhanVien,
            hdn.MaNPP AS MaNhaPhanPhoi,
            hdn.TongTien,
            (
                SELECT c.*
                FROM ChiTietHDNhap AS c
                WHERE hdn.MaHDNhap = c.MaHDNhap FOR JSON PATH
            ) AS list_json_chitiethdn
        INTO #Results1
        FROM HoaDonNhap AS hdn
        WHERE (@ma_hoa_don = -1 OR hdn.MaHDNhap = @ma_hoa_don)
              OR (@ma_nhan_vien = -1 OR hdn.MaNV = @ma_nhan_vien)
              OR (@ma_nha_phan_phoi = -1 OR hdn.MaNPP = @ma_nha_phan_phoi);
                   
        SELECT @RecordCount = COUNT(*)
        FROM #Results1;

        SELECT 
            *,
            @RecordCount AS RecordCount
        FROM #Results1
        WHERE RowNumber BETWEEN (@page_index - 1) * @page_size + 1 AND ((@page_index - 1) * @page_size + 1) + @page_size - 1
            OR @page_index = -1;

        DROP TABLE #Results1; 
    END
    ELSE
    BEGIN
        SET NOCOUNT ON;

        SELECT 
            (ROW_NUMBER() OVER(ORDER BY MaHDNhap ASC)) AS RowNumber, 
            hdn.MaHDNhap,
            hdn.NgayNhap,
            hdn.MaNV AS MaNhanVien,
            hdn.MaNPP AS MaNhaPhanPhoi,
            hdn.TongTien,
            (
                SELECT c.*
                FROM ChiTietHDNhap AS c
                WHERE hdn.MaHDNhap = c.MaHDNhap FOR JSON PATH
            ) AS list_json_chitiethdn
        INTO #Results2
        FROM HoaDonNhap AS hdn
        WHERE (@ma_hoa_don = -1 OR hdn.MaHDNhap = @ma_hoa_don)
              OR (@ma_nhan_vien = -1 OR hdn.MaNV = @ma_nhan_vien)
              OR (@ma_nha_phan_phoi = -1 OR hdn.MaNPP = @ma_nha_phan_phoi);
                   
        SELECT @RecordCount = COUNT(*)
        FROM #Results2;

        SELECT 
            *,
            @RecordCount AS RecordCount
        FROM #Results2;

        DROP TABLE #Results2; 
    END;
END;
GO
