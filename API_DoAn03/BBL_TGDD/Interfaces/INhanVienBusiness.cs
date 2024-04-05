using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface INhanVienBusiness
    {
        NhanVienModel GetDatabyID(string id);
        bool Create(NhanVienModel model);
        bool Update(NhanVienModel model);
        bool Delete(string MaNV);
        public List<NhanVienModel> Search(int pageIndex, int pageSize, out long total, string ma_nhan_vien, string ten_nhan_vien);
    }
}
