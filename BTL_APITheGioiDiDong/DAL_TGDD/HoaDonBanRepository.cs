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
    public class HoaDonBanRepository : IHoaDonBanRepository
    {
        private IDatabaseHelper _dbHelper;
        public HoaDonBanRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public HoaDonBanModel GetDatabyID(string MaHDBan)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadonban_get_by_id",
                     "@MaHDBan", MaHDBan);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonBanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(HoaDonBanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonban_create",
                "@MaHDBan", model.MaHDBan,
                "@MaCTHDBan", model.MaCTHDBan,
                "@MaNV", model.MaNV,
                "@MaKH", model.MaKH,
                "@NgayBan", model.NgayBan,
                "@TongTien", model.TongTien,
                "@list_json_chitiethoadonban", model.list_json_chitiethoadonban != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonban) : null);
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
        public bool Update(HoaDonBanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonban_update",
               "@MaHDBan", model.MaHDBan,
                "@MaNV", model.MaNV,
                "@MaKH", model.MaKH,
                "@NgayBan", model.NgayBan,
                "@TongTien", model.TongTien,
                "@list_json_chitiethoadonban", model.list_json_chitiethoadonban != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonban) : null);
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

        public bool Delete(string MaHDBan)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonban_delete",
                "@MaHDBan", MaHDBan);
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
        public List<HoaDonBanModel> Search(int pageIndex, int pageSize, out long total, string ma_hoa_don, string ma_NV, string ma_KH)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadonban_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ma_hoa_don", ma_hoa_don,
                    "@ma_NV", ma_NV,
                    "@ma_KH", ma_KH);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HoaDonBanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

