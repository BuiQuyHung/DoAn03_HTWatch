using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface ISanPhamRepository
    {
        SanPhamModel GetDatabyID(string MaSP);
        bool Create(SanPhamModel model);
        bool Update(SanPhamModel model);
        bool Delete(string MaSP);
        public List<ThongKeHangHoaTonKhoModel> ThongKeHangHoaTonKho();
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string ma_san_pham, string ten_san_pham);
        public List<SanPhamModel> Search1(int pageIndex, int pageSize, out long total, string ma_danh_muc);
    }
}
