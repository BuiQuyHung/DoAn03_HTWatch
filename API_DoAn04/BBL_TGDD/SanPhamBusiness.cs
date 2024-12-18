using DAL_TGDD.Interfaces;
using Models_TGDD;
using BBL_TGDD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

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
        public IEnumerable<SanPhamModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(SanPhamModel2 model)
        {
            return _res.Create(model);
        }
        public bool Update(SanPhamModel2 model)
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
        public List<ThongKeSanPhamTonKhoModel> ThongKeSanPhamTonKho(int pageIndex, int pageSize, out long total)
        {
            return _res.ThongKeSanPhamTonKho(pageIndex, pageSize, out total);
        }
        public List<ThongKeSanPhamBanChayModel> ThongKeSanPhamBanChay(int pageIndex, int pageSize, out long total, DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            return _res.ThongKeSanPhamBanChay(pageIndex, pageSize, out total, NgayBatDau, NgayKetThuc);
        }
        public List<BaoCaoDoanhThuModel> BaoCaoDoanhThu(int pageIndex, int pageSize, out long total, DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            return _res.BaoCaoDoanhThu(pageIndex, pageSize, out total, NgayBatDau, NgayKetThuc);
        }
        public List<BaoCaoDoanhThuTheoNamModel> BaoCaoDoanhThuTheoNam(int Nam)
        {
            return _res.BaoCaoDoanhThuTheoNam(Nam);
        }
    }
}
