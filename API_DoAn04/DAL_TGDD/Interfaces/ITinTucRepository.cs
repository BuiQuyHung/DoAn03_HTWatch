using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface ITinTucRepository
    {
        TinTucModel GetDatabyID(string MaTinTuc);
        bool Create(TinTucModel model);
        bool Update(TinTucModel model);
        bool Delete(string MaTinTuc);
        public List<TinTucModel> Search(int pageIndex, int pageSize, out long total, string ma_tin_tuc, string tieu_de);
    }
}
