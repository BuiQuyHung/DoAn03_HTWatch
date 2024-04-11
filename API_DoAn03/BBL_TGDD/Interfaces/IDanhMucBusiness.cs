using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface IDanhMucBusiness
    {
        IEnumerable<DanhMucModel> GetAllData();
        DanhMucModel GetDatabyID(string id);
        bool Create(DanhMucModel model);
        bool Update(DanhMucModel model);
        bool Delete(string MaDanhMuc);
        public List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, string ma_danh_muc, string ten_danh_muc);
    }
}
