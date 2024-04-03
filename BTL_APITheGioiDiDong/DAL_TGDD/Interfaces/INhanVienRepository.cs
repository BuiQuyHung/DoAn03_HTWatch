using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface INhanVienRepository
    {
        NhanVienModel GetDatabyID(string MaNV);
        bool Create(NhanVienModel model);
        bool Update(NhanVienModel model);
        bool Delete(string MaNV);
        public List<NhanVienModel> Search(int pageIndex, int pageSize, out long total, string ma_nhan_vien, string ten_nhan_vien);
    }
}
