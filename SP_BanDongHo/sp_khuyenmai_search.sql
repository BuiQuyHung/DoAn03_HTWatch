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

CREATE PROCEDURE [dbo].[sp_khuyenmai_search]
(
    @page_index INT, 
    @page_size INT,
    @ma_khuyenmai INT,
    @ten_khuyenmai NVARCHAR(50)
)
AS
BEGIN
    DECLARE @RecordCount BIGINT;

    IF (@page_size <> 0)
    BEGIN
        SET NOCOUNT ON;

        SELECT 
            (ROW_NUMBER() OVER(ORDER BY MaKhuyenMai ASC)) AS RowNumber, 
            km.MaKhuyenMai,
            km.MaSP,
            km.KhuyenMai,
            km.NgayBatDau,
            km.NgayKetThuc
        INTO #Results1
        FROM KhuyenMai AS km
        WHERE (@ma_khuyenmai = -1 OR km.MaKhuyenMai = @ma_khuyenmai)
              OR (@ten_khuyenmai = '' OR km.KhuyenMai LIKE N'%' + @ten_khuyenmai + '%');
                   
        SELECT @RecordCount = COUNT(*)
        FROM #Results1;

        SELECT 
            *,
            @RecordCount AS RecordCount
        FROM #Results1
        WHERE ROWNUMBER BETWEEN (@page_index - 1) * @page_size + 1 AND ((@page_index - 1) * @page_size + 1) + @page_size - 1
            OR @page_index = -1;

        DROP TABLE #Results1; 
    END
    ELSE
    BEGIN
        SET NOCOUNT ON;

        SELECT 
            (ROW_NUMBER() OVER(ORDER BY MaKhuyenMai ASC)) AS RowNumber, 
            km.MaKhuyenMai,
            km.MaSP,
            km.KhuyenMai,
            km.NgayBatDau,
            km.NgayKetThuc
        INTO #Results2
        FROM KhuyenMai AS km
        WHERE (@ma_khuyenmai = -1 OR km.MaKhuyenMai = @ma_khuyenmai)
              OR (@ten_khuyenmai = '' OR km.KhuyenMai LIKE N'%' + @ten_khuyenmai + '%');
                   
        SELECT @RecordCount = COUNT(*)
        FROM #Results2;

        SELECT 
            *,
            @RecordCount AS RecordCount
        FROM #Results2;

        DROP TABLE #Results2; 
    END;
END;
