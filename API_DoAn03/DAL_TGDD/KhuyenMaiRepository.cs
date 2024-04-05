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
    public class  KhuyenMaiRepository : IKhuyenMaiRepository
    {
        private IDatabaseHelper _dbHelper;
        public KhuyenMaiRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public KhuyenMaiModel GetDatabyID(string MaKhuyenMai)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khuyenmai_get_by_id",
                     "@MaKhuyenMai", MaKhuyenMai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhuyenMaiModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(KhuyenMaiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khuyenmai_create",
                "@MaSP", model.MaSP,
                "@KhuyenMai", model.KhuyenMai,
                "@NgayBatDau", model.NgayBatDau,
                "@NgayKetThuc", model.NgayKetThuc);
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
        public bool Update(KhuyenMaiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khuyenmai_update",
                "@MaKhuyenMai", model.MaKhuyenMai,
                "@MaSP", model.MaSP,
                "@KhuyenMai", model.KhuyenMai,
                "@NgayBatDau", model.NgayBatDau,
                "@NgayKetThuc", model.NgayKetThuc);
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
        public bool Delete(string MaKhuyenMai)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khuyenmai_delete",
                "@MaKhuyenMai", MaKhuyenMai
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
        public List<KhuyenMaiModel> Search(int pageIndex, int pageSize, out long total, string ma_khuyenmai, string ten_khuyenmai)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khuyenmai_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ma_khuyenmai", ma_khuyenmai,
                    "@ten_khuyenmai", ten_khuyenmai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<KhuyenMaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

