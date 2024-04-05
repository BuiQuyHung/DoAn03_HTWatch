using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface IHoaDonNhapRepository
    {
        HoaDonNhapModel GetDatabyID(string MaHDNhap);
        bool Create(HoaDonNhapModel model);
        bool Update(HoaDonNhapModel model);
        bool Delete(string MaHDNhap);
        public List<HoaDonNhapModel> Search(int pageIndex, int pageSize, out long total, string ma_hoa_don, string ma_NV, string ma_NPP);
    }
}
