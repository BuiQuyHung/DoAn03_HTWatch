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
        public IEnumerable<NhaPhanPhoiModel> GetAllData()
        {
            return _res.GetAllData();
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
        public List<NhaPhanPhoiModel> Search(int pageIndex, int pageSize, out long total, string ma_npp, string ten_npp)
        {
            return _res.Search(pageIndex, pageSize, out total, ma_npp, ten_npp);
        }
    }
}
