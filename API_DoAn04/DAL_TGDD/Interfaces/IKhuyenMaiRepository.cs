using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface IKhuyenMaiRepository
    {
        KhuyenMaiModel GetDatabyID(string MaKhuyenMai);
        bool Create(KhuyenMaiModel model);
        bool Update(KhuyenMaiModel model);
        bool Delete(string MaKhuyenMai);
        public List<KhuyenMaiModel> Search(int pageIndex, int pageSize, out long total, string ma_khuyenmai, string ten_khuyenmai);
    }
}
