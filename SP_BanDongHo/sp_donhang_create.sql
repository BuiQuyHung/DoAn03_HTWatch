USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_donhang_create]    Script Date: 06/05/2024 3:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_donhang_create]
(@TenKhachHang   NVARCHAR(50), 
 @Email          NVARCHAR(50),
 @SoDienThoai    NVARCHAR(50),
 @DiaChi         NVARCHAR(50),
 @list_json_chitietdonhang NVARCHAR(MAX)
)
AS
    BEGIN
		DECLARE @MaDonHang INT;
		DECLARE @NgayTao DATETIME = GETDATE(); -- Lấy ngày hiện tại
        INSERT INTO DonHang
                (TenKH, 
                 Email,
				 SDT,
				 DiaChi,
				 NgayTao
                )
                VALUES
                (@TenKhachHang, 
                 @Email,
				 @SoDienThoai,
				 @DiaChi,
				 @NgayTao
                );

				SET @MaDonHang = (SELECT SCOPE_IDENTITY());
                IF(@list_json_chitietdonhang IS NOT NULL)
                    BEGIN
                        INSERT INTO ChiTietDonHang
						 (MaDonHang, 
						  MaSP,
                          SoLuong,
                          TongTien,
						  GiaSP
                        )
                    SELECT  @MaDonHang,
							JSON_VALUE(p.value, '$.maSP'),
                            JSON_VALUE(p.value, '$.soLuong'), 
                            JSON_VALUE(p.value, '$.tongTien'),
							JSON_VALUE(p.value, '$.giaSP')
                    FROM OPENJSON(@list_json_chitietdonhang) AS p;
                END;
        SELECT '';
    END;