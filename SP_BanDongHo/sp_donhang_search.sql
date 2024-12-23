USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_donhang_search]    Script Date: 06/05/2024 3:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_donhang_search]
(
    @page        INT, 
    @pageSize    INT,
    @ma_don_hang INT,
    @ten_kh      NVARCHAR(50)
)
AS
BEGIN
    DECLARE @RecordCount BIGINT;

    IF (@pageSize <> 0)
    BEGIN
        SET NOCOUNT ON;

        SELECT 
            (ROW_NUMBER() OVER(ORDER BY MaDonHang ASC)) AS RowNumber, 
            dh.MaDonHang,
            dh.TenKH,
            dh.NgayTao,
            dh.Email,
            dh.SDT,
            dh.DiaChi,
            dh.ThanhTien
        INTO #Results1
        FROM DonHang AS dh
        WHERE (@ma_don_hang = -1 OR dh.MaDonHang = @ma_don_hang)
              OR (@ten_kh = '' OR dh.TenKH LIKE '%' + @ten_kh + '%');
                   
        SELECT @RecordCount = COUNT(*)
        FROM #Results1;

        SELECT 
            *,
            @RecordCount AS RecordCount
        FROM #Results1
        WHERE RowNumber BETWEEN (@page - 1) * @pageSize + 1 AND ((@page - 1) * @pageSize + 1) + @pageSize - 1
            OR @page = -1;

        DROP TABLE #Results1; 
    END
    ELSE
    BEGIN
        SET NOCOUNT ON;

        SELECT 
            (ROW_NUMBER() OVER(ORDER BY MaDonHang ASC)) AS RowNumber, 
            dh.MaDonHang,
            dh.TenKH,
            dh.NgayTao,
            dh.Email,
            dh.SDT,
            dh.DiaChi,
            dh.ThanhTien
        INTO #Results2
        FROM DonHang AS dh
        WHERE (@ma_don_hang = -1 OR dh.MaDonHang = @ma_don_hang)
              OR (@ten_kh = '' OR dh.TenKH LIKE '%' + @ten_kh + '%');
                   
        SELECT @RecordCount = COUNT(*)
        FROM #Results2;

        SELECT 
            *,
            @RecordCount AS RecordCount
        FROM #Results2;

        DROP TABLE #Results2; 
    END;
END;
