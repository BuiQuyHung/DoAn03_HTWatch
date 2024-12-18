using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface INguoiDungRepository
    {
        NguoiDungModel GetDatabyID(string UserID);
        bool Create(NguoiDungModel model);
        bool Update(NguoiDungModel model);
        bool Delete(string UserID);
        public List<NguoiDungModel> Search(int pageIndex, int pageSize, out long total, string UserID, int Per);
    }
}
