USE [BanDongHo]
GO
/****** Object:  StoredProcedure [dbo].[sp_khuyenmai_get_by_id]    Script Date: 05/04/2024 4:23:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_khuyenmai_get_by_id]
    @MaKhuyenMai INT
AS
BEGIN
    SELECT *
    FROM KhuyenMai
    WHERE MaKhuyenMai = @MaKhuyenMai;
END;
