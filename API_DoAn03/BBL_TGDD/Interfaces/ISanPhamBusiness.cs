using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface ISanPhamBusiness
    {
        SanPhamModel GetDatabyID(string id);
        bool Create(SanPhamModel model);
        bool Update(SanPhamModel model);
        bool Delete(string MaSP);
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string ma_san_pham, string ten_san_pham);
        public List<SanPhamModel> Search1(int pageIndex, int pageSize, out long total, string ma_danh_muc);
        public List<ThongKeHangHoaTonKhoModel> ThongKeHangHoaTonKho();

    }
}
