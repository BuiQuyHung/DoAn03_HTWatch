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
    public class NguoiDungBusiness : INguoiDungBusiness
    {
        private INguoiDungRepository _res;
        public NguoiDungBusiness(INguoiDungRepository res)
        {
            _res = res;
        }
        public NguoiDungModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(NguoiDungModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NguoiDungModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string UserID)
        {
            return _res.Delete(UserID);
        }
        public List<NguoiDungModel> Search(int pageIndex, int pageSize, out long total, string UserID, int Per)
        {
            return _res.Search(pageIndex, pageSize, out total, UserID, Per);
        }
    }
}
