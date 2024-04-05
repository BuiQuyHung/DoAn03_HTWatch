using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface INguoiDungBusiness
    {
        NguoiDungModel GetDatabyID(string id);
        bool Create(NguoiDungModel model);
        bool Update(NguoiDungModel model);
        bool Delete(string UserID);
        public List<NguoiDungModel> Search(int pageIndex, int pageSize, out long total, string UserID, int Per);
    }
}
