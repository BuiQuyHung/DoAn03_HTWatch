USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_nguoidung_search]    Script Date: 04/04/2024 4:14:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_nguoidung_search]
(
    @page_index INT, 
    @page_size INT,
    @user_id NVARCHAR(50),
    @per INT
)
AS
BEGIN
    DECLARE @RecordCount BIGINT;

    IF (@page_size <> 0)
    BEGIN
        SET NOCOUNT ON;

        SELECT 
            (ROW_NUMBER() OVER(ORDER BY UserID ASC)) AS RowNumber, 
            nd.UserID,
            nd.Pass,
            nd.Per
        INTO #Results1
        FROM NguoiDung AS nd
        WHERE (@user_id = '' OR nd.UserID = @user_id)
              OR (@per = '' OR nd.per LIKE N'%' + @per + '%');
                   
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
            (ROW_NUMBER() OVER(ORDER BY UserID ASC)) AS RowNumber, 
            nd.UserID,
            nd.Pass,
            nd.Per
        INTO #Results2
        FROM NguoiDung AS nd
        WHERE (@user_id = '' OR nd.UserID = @user_id)
              OR (@per = '' OR nd.per LIKE N'%' + @per + '%');
                   
        SELECT @RecordCount = COUNT(*)
        FROM #Results2;

        SELECT 
            *,
            @RecordCount AS RecordCount
        FROM #Results2;

        DROP TABLE #Results2; 
    END;
END;