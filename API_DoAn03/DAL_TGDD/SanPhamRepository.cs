using DAL_TGDD.Interfaces;
using DataAccessLayer;
using Model;
using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TGDD
{
    public class  SanPhamRepository : ISanPhamRepository
    {
        private IDatabaseHelper _dbHelper;
        public SanPhamRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public SanPhamModel GetDatabyID(string MaSP)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_get_by_id",
                     "@MaSP", MaSP);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<SanPhamModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetNewestProducts8");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public SanPhamModel GetData()
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetNewestProducts8"
        //             );
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        return dt.ConvertToB<SanPhamModel>();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public bool Create(SanPhamModel2 model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sanpham_create",
                "@TenSP", model.TenSP,
                "@MaDanhMuc", model.MaDanhMuc,
                "@HinhAnh", model.HinhAnh,
                "@GiaSP", model.GiaSP,
                "@SoLuong", model.SoLuong,
                "@MoTa", model.MoTa);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(SanPhamModel2 model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sanpham_update",
                "@MaSP", model.MaSP,
              "@TenSP", model.TenSP,
                "@MaDanhMuc", model.MaDanhMuc,
                "@HinhAnh", model.HinhAnh,
                "@GiaSP", model.GiaSP,
                "@SoLuong", model.SoLuong,
                "@MoTa", model.MoTa);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(string MaSP)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sanpham_delete",
                "@MaSP", MaSP
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string ma_san_pham, string ten_san_pham)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ma_san_pham", ma_san_pham,
                    "@ten_san_pham", ten_san_pham);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> Search1(int pageIndex, int pageSize, out long total, string ma_danh_muc)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_search1",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@MaDanhMuc", ma_danh_muc);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ThongKeSanPhamTonKhoModel> ThongKeSanPhamTonKho(int pageIndex, int pageSize, out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_TKSP_TonKho",
                    "@page_index", pageIndex,
                    "@page_size", pageSize);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ThongKeSanPhamTonKhoModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ThongKeSanPhamBanChayModel> ThongKeSanPhamBanChay(int pageIndex, int pageSize, out long total, DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_TKSP_BanChay",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@NgayBatDau", NgayBatDau,
                    "@NgayKetThuc", NgayKetThuc);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (int)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ThongKeSanPhamBanChayModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BaoCaoDoanhThuModel> BaoCaoDoanhThu(int pageIndex, int pageSize, out long total, DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_BaoCaoDoanhThu",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@NgayBatDau", NgayBatDau,
                    "@NgayKetThuc", NgayKetThuc);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (int)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<BaoCaoDoanhThuModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BaoCaoDoanhThuTheoNamModel> BaoCaoDoanhThuTheoNam(int Nam)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_BaoCaoDoanhThu",
                       "@Nam", Nam);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BaoCaoDoanhThuTheoNamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

