using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface IDonHangBusiness
    {
        DonHangModel GetDatabyID(string id);
        bool Create(DonHangModel model);
        bool Update(DonHangModel model);
        bool Delete(string MaDonHang);
        public List<DonHangModel> Search(int pageIndex, int pageSize, out long total, string ma_don_hang,string ten_khach_hang);
    }
}
