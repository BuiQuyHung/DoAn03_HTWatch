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
    public class HoaDonBanBusiness : IHoaDonBanBusiness
    {
        private IHoaDonBanRepository _res;
        public HoaDonBanBusiness(IHoaDonBanRepository res)
        {
            _res = res;
        }
        public HoaDonBanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(HoaDonBanModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HoaDonBanModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaHDBan)
        {
            return _res.Delete(MaHDBan);
        }
        public List<HoaDonBanModel> Search(int pageIndex, int pageSize, out long total, string ma_hoa_don, string ma_NV, string ma_KH)
        {
            return _res.Search(pageIndex, pageSize, out total,  ma_hoa_don,  ma_NV,  ma_KH);
        }
    }
}
