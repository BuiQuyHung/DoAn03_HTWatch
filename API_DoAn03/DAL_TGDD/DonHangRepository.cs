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
    public class DonHangRepository : IDonHangRepository
    {
        private IDatabaseHelper _dbHelper;
        public DonHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public DonHangModel GetDatabyID(string MaDonHang)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_donhang_get_by_id",
                     "@MaDonHang", MaDonHang);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(DonHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_donhang_create",
                "@TenKhachHang", model.TenKH,
                "@Email", model.Email,
                "@SoDienThoai", model.SDT,
                "@DiaChi", model.DiaChi,
                "@list_json_chitietdonhang", model.list_json_chitietdonhang != null ? MessageConvert.SerializeObject(model.list_json_chitietdonhang) : null);
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
        public bool Update(DonHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_donhang_update",
                "@MaDonHang", model.MaDonHang,
                "@TenKhachHang", model.TenKH,
                "@Email", model.Email,
                "@SoDienThoai", model.SDT,
                "@DiaChi", model.DiaChi,
                "@list_json_chitietdonhang", model.list_json_chitietdonhang != null ? MessageConvert.SerializeObject(model.list_json_chitietdonhang) : null);
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

        public bool Delete(string MaDonHang)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_donhang_delete",
                "@MaDonHang", MaDonHang);
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
        public List<DonHangModel> Search(int page, int pageSize, out long total, string ma_don_hang, string ten_khach_hang)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_donhang_search",
                    "@page", page,
                    "@pageSize", pageSize,
                    "@ma_don_hang", ma_don_hang,
                    "@ten_kh", ten_khach_hang);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DonHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

