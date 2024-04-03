using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface IHoaDonBanRepository
    {
        HoaDonBanModel GetDatabyID(string MaHDBan);
        bool Create(HoaDonBanModel model);
        bool Update(HoaDonBanModel model);
        bool Delete(string MaHDBan);
        public List<HoaDonBanModel> Search(int pageIndex, int pageSize, out long total, string ma_hoa_don, string ma_NV, string ma_KH);
    }
}
