USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_donhang_create]    Script Date: 18/04/2024 10:06:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_donhang_create]
(
    @TenKhachHang   NVARCHAR(50), 
    @NgayTao        DATETIME,
    @Email          NVARCHAR(50),
    @SoDienThoai    NVARCHAR(50),
    @DiaChi         NVARCHAR(50),
	@ThanhTien		DECIMAL,
    @list_json_chitietdonhang NVARCHAR(MAX)
)
AS
BEGIN
    DECLARE @MaDonHang INT;
    INSERT INTO DonHang
    (
        TenKH, 
        NgayTao,
        Email,
        SDT,
        DiaChi,
		ThanhTien
    )
    VALUES
    (
        @TenKhachHang, 
        @NgayTao, -- Thêm dấu phẩy ở đây
        @Email,
        @SoDienThoai,
        @DiaChi,
		@TenKhachHang
    );

    SET @MaDonHang = (SELECT SCOPE_IDENTITY());
    IF(@list_json_chitietdonhang IS NOT NULL)
    BEGIN
        INSERT INTO ChiTietDonHang
        (
            MaDonHang, 
            MaSP,
            GiaSP,
            SoLuong,
            TongTien
        )
        SELECT  
            @MaDonHang,
            JSON_VALUE(p.value, '$.maSP'),
            JSON_VALUE(p.value, '$.soLuong'), 
            JSON_VALUE(p.value, '$.tongTien'),
            JSON_VALUE(p.value, '$.giaSP')
        FROM OPENJSON(@list_json_chitietdonhang) AS p;
    END;
    SELECT '';
END; 
