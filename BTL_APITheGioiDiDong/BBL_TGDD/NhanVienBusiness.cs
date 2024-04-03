using DAL_TGDD.Interfaces;
using Models_TGDD;
using BBL_TGDD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD
{
    public class NhanVienBusiness : INhanVienBusiness
    {
        private INhanVienRepository _res;
        public NhanVienBusiness(INhanVienRepository res)
        {
            _res = res;
        }
        public NhanVienModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(NhanVienModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhanVienModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaNV)
        {
            return _res.Delete(MaNV);
        }
        public List<NhanVienModel> Search(int pageIndex, int pageSize, out long total, string ten_NV, string dia_chi)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_NV, dia_chi);
        }
    }
}
