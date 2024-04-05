using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface ITinTucBusiness
    {
        TinTucModel GetDatabyID(string id);
        bool Create(TinTucModel model);
        bool Update(TinTucModel model);
        bool Delete(string MaTinTuc);
        public List<TinTucModel> Search(int pageIndex, int pageSize, out long total, string ma_tin_tuc, string tieu_de);
    }
}
