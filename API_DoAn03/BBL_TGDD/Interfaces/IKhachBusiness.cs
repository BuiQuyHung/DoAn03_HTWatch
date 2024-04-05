using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface IKhachBusiness
    {
        KhachModel GetDatabyID(string id);
        bool Create(KhachModel model);
        bool Update(KhachModel model);
        bool Delete(string MaKH);
        public List<KhachModel> Search(int pageIndex, int pageSize, out long total, string ma_khach, string ten_khach);
    }
}
