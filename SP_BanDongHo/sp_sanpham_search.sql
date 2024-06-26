USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_sanpham_search]    Script Date: 04/04/2024 3:19:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sanpham_search]
(
    @page_index  INT, 
    @page_size   INT,
    @ma_san_pham INT,
    @ten_san_pham NVARCHAR(50)
)
AS
BEGIN
    DECLARE @RecordCount BIGINT;

    IF (@page_size <> 0)
    BEGIN
        SET NOCOUNT ON;

        SELECT 
            (ROW_NUMBER() OVER(ORDER BY TenSP ASC)) AS RowNumber, 
            sp.MaSP,
            sp.TenSP,
            sp.MaDanhMuc,
			sp.HinhAnh,
			sp.GiaSP,
			sp.SoLuong,
			sp.MaMenu,
			sp.Mota
        INTO #Results1
        FROM SanPham AS sp
        WHERE (@ma_san_pham = -1 OR sp.MaSP = @ma_san_pham)
              OR (@ten_san_pham = '' OR sp.TenSP LIKE N'%' + @ten_san_pham + '%');
                   
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
            (ROW_NUMBER() OVER(ORDER BY TenSP ASC)) AS RowNumber, 
           sp.MaSP,
            sp.TenSP,
            sp.MaDanhMuc,
			sp.HinhAnh,
			sp.GiaSP,
			sp.SoLuong,
			sp.MaMenu,
			sp.Mota
        INTO #Results2
        FROM SanPham AS sp
        WHERE (@ma_san_pham = -1 OR  sp.MaSP = @ma_san_pham)
              OR (@ten_san_pham = '' OR sp.TenSP LIKE N'%' + @ten_san_pham + '%');
                   
        SELECT @RecordCount = COUNT(*)
        FROM #Results2;

        SELECT 
            *,
            @RecordCount AS RecordCount
        FROM #Results2;

        DROP TABLE #Results2; 
    END;
END;
