using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface INhaPhanPhoiBusiness
    {
        NhaPhanPhoiModel GetDatabyID(string id);
        bool Create(NhaPhanPhoiModel model);
        bool Update(NhaPhanPhoiModel model);
        bool Delete(string MaNPP);
        public List<NhaPhanPhoiModel> Search(int pageIndex, int pageSize, out long total, string ma_npp, string ten_npp);
    }
}
