using DAL_TGDD.Interfaces;
using DataAccessLayer;
using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TGDD
{
    public class HoaDonNhapRepository : IHoaDonNhapRepository
    {
        private IDatabaseHelper _dbHelper;
        public HoaDonNhapRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public HoaDonNhapModel GetDatabyID(string MaHDNhap)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadonnhap_get_by_id",
                     "@MaHDNhap", MaHDNhap);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonNhapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonnhap_create",
                "@MaHDNhap", model.MaHDNhap,
                "@MaCTHDNhap", model.MaCTHDNhap,
                "@MaNV", model.MaNV,
                "@MaNPP", model.MaNPP,
                "@NgayNhap", model.NgayNhap,
                "@TongTien", model.TongTien,
                "@list_json_chitiethoadonnhap", model.list_json_chitiethoadonnhap != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonnhap) : null);
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
        public bool Update(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonnhap_update",
               "@MaHDNhap", model.MaHDNhap,
                "@MaNV", model.MaNV,
                "@MaNPP", model.MaNPP,
                "@NgayNhap", model.NgayNhap,
                "@TongTien", model.TongTien,
                "@list_json_chitiethoadonnhap", model.list_json_chitiethoadonnhap != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonnhap) : null);
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

        public bool Delete(string MaHDNhap)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonnhap_delete",
                "@MaHDNhap", MaHDNhap);
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
        public List<HoaDonNhapModel> Search(int pageIndex, int pageSize, out long total, string ma_hoa_don, string ma_NV, string ma_NPP)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadonnhap_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ma_hoa_don", ma_hoa_don,
                    "@ma_NV", ma_NV,
                    "@ma_NPP", ma_NPP);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HoaDonNhapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

