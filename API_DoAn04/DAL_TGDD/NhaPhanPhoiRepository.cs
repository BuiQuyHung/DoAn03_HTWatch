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
    public class NhaPhanPhoiRepository : INhaPhanPhoiRepository
    {
        private IDatabaseHelper _dbHelper;
        public NhaPhanPhoiRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public IEnumerable<NhaPhanPhoiModel> GetAllData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nhaphanphoi_GetAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaPhanPhoiModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public NhaPhanPhoiModel GetDatabyID(string MaNPP)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nhaphanphoi_get_by_id",
                     "@MaNPP", MaNPP);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaPhanPhoiModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(NhaPhanPhoiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhaphanphoi_create",
                "@TenNPP", model.TenNPP,
                "@DiaChi", model.DiaChi,
                "@DienThoai", model.DienThoai);
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
        public bool Update(NhaPhanPhoiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhaphanphoi_update",
                "@MaNPP", model.MaNPP,
                "@TenNPP", model.TenNPP,
                "@DiaChi", model.DiaChi,
                "@DienThoai", model.DienThoai);
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
        public bool Delete(string MaNPP)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhaphanphoi_delete",
                "@MaNPP", MaNPP
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
        public List<NhaPhanPhoiModel> Search(int pageIndex, int pageSize, out long total, string ma_npp, string ten_npp)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nhaphanphoi_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ma_nha_phan_phoi", ma_npp,
                    "@ten_nha_phan_phoi", ten_npp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NhaPhanPhoiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

