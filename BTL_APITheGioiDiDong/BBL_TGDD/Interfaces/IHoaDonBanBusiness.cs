using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface IHoaDonBanBusiness
    {
        HoaDonBanModel GetDatabyID(string id);
        bool Create(HoaDonBanModel model);
        bool Update(HoaDonBanModel model);
        bool Delete(string MaHDBan);
        public List<HoaDonBanModel> Search(int pageIndex, int pageSize, out long total, string ma_hoa_don, string ma_NV, string ma_KH);
    }
}
