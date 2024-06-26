USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_ThongKeSanPhamTonKho]    Script Date: 24/04/2024 9:42:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TKSP_TonKho]
(
    @page_index  INT, 
    @page_size   INT
)
AS
BEGIN
    DECLARE @RecordCount BIGINT;

    IF (@page_size <> 0)
    BEGIN
        SET NOCOUNT ON;

        SELECT 
            (ROW_NUMBER() OVER(ORDER BY SanPham.MaSP DESC)) AS RowNumber, 
            SanPham.MaSP,
            SanPham.TenSP,
            SanPham.SoLuong AS SoLuongNhap,
            ISNULL(SUM(ChiTietDonHang.SoLuong), 0) AS SoLuongBan,
            (SanPham.SoLuong - ISNULL(SUM(ChiTietDonHang.SoLuong), 0)) AS SoLuongTonKho
        INTO #Results
        FROM 
            SanPham
        LEFT JOIN 
            ChiTietDonHang ON SanPham.MaSP = ChiTietDonHang.MaSP
        GROUP BY 
            SanPham.MaSP, SanPham.TenSP, SanPham.SoLuong
        ORDER BY 
            SoLuongTonKho DESC;

        SELECT @RecordCount = COUNT(*)
        FROM #Results;

        SELECT 
            *,
            @RecordCount AS RecordCount
        FROM #Results
        WHERE RowNumber BETWEEN (@page_index - 1) * @page_size + 1 AND ((@page_index - 1) * @page_size + 1) + @page_size - 1
            OR @page_index = -1;

        DROP TABLE #Results; 
    END
END;