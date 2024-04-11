using DAL_TGDD.Interfaces;
using Models_TGDD;
using BBL_TGDD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD
{
    public class DanhMucBusiness : IDanhMucBusiness
    {
        private IDanhMucRepository _res;
        public DanhMucBusiness(IDanhMucRepository res)
        {
            _res = res;
        }
        public IEnumerable<DanhMucModel> GetAllData()
        {
            return _res.GetAllData();
        }
        public DanhMucModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(DanhMucModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DanhMucModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaDanhMuc)
        {
            return _res.Delete(MaDanhMuc);
        }
        public List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, string ma_danh_muc, string ten_danh_muc)
        {
            return _res.Search(pageIndex, pageSize, out total, ma_danh_muc, ten_danh_muc);
        }
    }
}
