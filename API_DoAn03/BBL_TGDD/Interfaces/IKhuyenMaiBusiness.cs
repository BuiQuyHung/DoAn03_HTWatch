using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface IKhuyenMaiBusiness
    {
        KhuyenMaiModel GetDatabyID(string id);
        bool Create(KhuyenMaiModel model);
        bool Update(KhuyenMaiModel model);
        bool Delete(string MaKhuyenMai);
        public List<KhuyenMaiModel> Search(int pageIndex, int pageSize, out long total, string ma_khuyenmai, string ten_khuyenmai);

    }
}
