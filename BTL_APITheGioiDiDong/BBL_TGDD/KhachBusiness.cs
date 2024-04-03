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
    public class KhachBusiness : IKhachBusiness
    {
        private IKhachRepository _res;
        public KhachBusiness(IKhachRepository res)
        {
            _res = res;
        }
        public KhachModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(KhachModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhachModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaKH)
        {
            return _res.Delete(MaKH);
        }
        public List<KhachModel> Search(int pageIndex, int pageSize, out long total, string ma_khach, string ten_khach)
        {
            return _res.Search(pageIndex, pageSize, out total, ma_khach, ten_khach);
        }
    }
}
