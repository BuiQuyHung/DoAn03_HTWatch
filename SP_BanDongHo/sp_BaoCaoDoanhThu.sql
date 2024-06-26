USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_BaoCaoDoanhThu]    Script Date: 06/05/2024 9:29:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_BaoCaoDoanhThu]
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
                ROW_NUMBER() OVER (ORDER BY SUM(DH.ThanhTien) DESC) AS RowNumber,
                DH.MaDonHang,
                DH.TenKH,
                DH.Email,
                DH.SDT,
                DH.DiaChi,
                DH.NgayTao,
                SUM(DH.ThanhTien) AS ThanhTien
            FROM
                DonHang DH
            WHERE
                DH.NgayTao BETWEEN @NgayBatDau AND @NgayKetThuc
            GROUP BY
                DH.MaDonHang, DH.TenKH, DH.Email, DH.SDT, DH.DiaChi, DH.NgayTao, DH.ThanhTien
        )
        SELECT 
            *,
            (SELECT COUNT(*) FROM Results) AS RecordCount
        FROM Results
        WHERE RowNumber BETWEEN (@page_index - 1) * @page_size + 1 AND (@page_index - 1) * @page_size + @page_size;
    END
END;
