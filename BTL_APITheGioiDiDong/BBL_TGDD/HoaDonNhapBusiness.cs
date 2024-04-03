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
    public class HoaDonNhapBusiness : IHoaDonNhapBusiness
    {
        private IHoaDonNhapRepository _res;
        public HoaDonNhapBusiness(IHoaDonNhapRepository res)
        {
            _res = res;
        }
        public HoaDonNhapModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(HoaDonNhapModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HoaDonNhapModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaHDNhap)
        {
            return _res.Delete(MaHDNhap);
        }
        public List<HoaDonNhapModel> Search(int pageIndex, int pageSize, out long total, string ma_hoa_don, string ma_NV, string ma_NPP)
        {
            return _res.Search(pageIndex, pageSize, out total,  ma_hoa_don,  ma_NV,  ma_NPP);
        }
    }
}
