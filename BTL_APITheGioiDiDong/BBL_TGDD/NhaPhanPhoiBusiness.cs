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
    public class NhaPhanPhoiBusiness : INhaPhanPhoiBusiness
    {
        private INhaPhanPhoiRepository _res;
        public NhaPhanPhoiBusiness(INhaPhanPhoiRepository res)
        {
            _res = res;
        }
        public NhaPhanPhoiModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public bool Create(NhaPhanPhoiModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhaPhanPhoiModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaNPP)
        {
            return _res.Delete(MaNPP);
        }
        public List<NhaPhanPhoiModel> Search(int pageIndex, int pageSize, out long total, string ten_npp, string dia_chi)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_npp, dia_chi);
        }
    }
}
