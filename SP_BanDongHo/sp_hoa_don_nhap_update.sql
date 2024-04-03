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

CREATE PROCEDURE [dbo].[sp_hoa_don_nhap_update]
(@MaHoaDonNhap INT, 
 @MaNhanVien NVARCHAR(50), 
 @MaNhaPhanPhoi NVARCHAR(50),
 @list_json_chitiethoadonnhap NVARCHAR(MAX)
)
AS
    BEGIN
		UPDATE HoaDonNhap
		SET
			MaNV  = @MaNhanVien ,
			MaNPP = @MaNhaPhanPhoi
		WHERE MaHDNhap = @MaHoaDonNhap;
		
		IF(@list_json_chitiethoadonnhap IS NOT NULL) 
		BEGIN
			 -- Insert data to temp table 
		   SELECT
			  JSON_VALUE(p.value, '$.maCTHDNhap') as MaCTHDNhap,
			  JSON_VALUE(p.value, '$.maHDNhap') as MaHDNhap,
			  JSON_VALUE(p.value, '$.maSP') as MaSP,
			  JSON_VALUE(p.value, '$.soLuong') as SoLuong,
			  JSON_VALUE(p.value, '$.donGia') as DonGia,
			  JSON_VALUE(p.value, '$.thanhTien') as ThanhTien
			  INTO #Results 
		   FROM OPENJSON(@list_json_chitiethoadonnhap) AS p;
		 
			
			-- Update data to table with STATUS = 2
			  UPDATE ChiTietHDNhap
			  SET
				 SoLuong = #Results.SoLuong,
				 DonGia = #Results.DonGia,
				 ThanhTien = #Results.ThanhTien
			  FROM #Results 
			  WHERE  ChiTietHDNhap.MaCTHDNhap = #Results.MaCTHDNhap ;
		END;
    END;
GO