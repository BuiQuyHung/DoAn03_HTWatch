using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface IKhachRepository
    {
        KhachModel GetDatabyID(string MaKH);
        bool Create(KhachModel model);
        bool Update(KhachModel model);
        bool Delete(string MaKH);
        public List<KhachModel> Search(int pageIndex, int pageSize, out long total, string ma_khach, string ten_khach);
    }
}
