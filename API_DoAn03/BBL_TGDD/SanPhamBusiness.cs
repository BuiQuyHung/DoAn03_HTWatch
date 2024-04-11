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
    public class SanPhamBusiness : ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
        {
            _res = res;
        }
        public SanPhamModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(SanPhamModel model)
        {
            return _res.Create(model);
        }
        public bool Update(SanPhamModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaSP)
        {
            return _res.Delete(MaSP);
        }
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string ma_san_pham, string ten_san_pham)
        {
            return _res.Search(pageIndex, pageSize, out total, ma_san_pham, ten_san_pham);
        }
        public List<SanPhamModel> Search1(int pageIndex, int pageSize, out long total, string ma_danh_muc)
        {
            return _res.Search1(pageIndex, pageSize, out total, ma_danh_muc);
        }
        public List<ThongKeHangHoaTonKhoModel> ThongKeHangHoaTonKho()
        {
            return _res.ThongKeHangHoaTonKho();
        }
    }
}
