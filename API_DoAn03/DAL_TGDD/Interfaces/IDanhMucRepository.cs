using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface IDanhMucRepository
    {
        IEnumerable<DanhMucModel> GetAllData();
        DanhMucModel GetDatabyID(string MaDanhMuc);
        bool Create(DanhMucModel model);
        bool Update(DanhMucModel model);
        bool Delete(string MaDanhMuc);
        public List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, string ma_danh_muc, string ten_danh_muc);
    }
}
