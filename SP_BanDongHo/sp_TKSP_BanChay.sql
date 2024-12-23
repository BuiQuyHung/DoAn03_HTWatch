USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_ThongKeSanPhamBanChay]    Script Date: 24/04/2024 9:33:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_TKSP_BanChay]
    @NgayBatDau DATE = NULL,
    @NgayKetThuc DATE = NULL,
    @page_index INT,
    @page_size INT -- Số bản ghi trên mỗi trang mặc định
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @RecordCount BIGINT;

    IF @NgayBatDau IS NOT NULL AND @NgayKetThuc IS NOT NULL
    BEGIN
        WITH Results AS (
            SELECT 
                ROW_NUMBER() OVER (ORDER BY SUM(CTDH.SoLuong) DESC) AS RowNumber,
                CTDH.MaSP,
                SP.TenSP,
                SUM(CTDH.SoLuong) AS SoLuongBan
            FROM
                ChiTietDonHang CTDH
            INNER JOIN
                SanPham SP ON CTDH.MaSP = SP.MaSP
            INNER JOIN
                DonHang DH ON CTDH.MaDonHang = DH.MaDonHang
            WHERE
                DH.NgayTao BETWEEN @NgayBatDau AND @NgayKetThuc
            GROUP BY
                CTDH.MaSP, SP.TenSP
        )
        SELECT 
            *,
            (SELECT COUNT(*) FROM Results) AS RecordCount
        FROM Results
        WHERE RowNumber BETWEEN (@page_index - 1) * @page_size + 1 AND (@page_index - 1) * @page_size + @page_size;
    END
END;
