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
    public class KhuyenMaiBusiness : IKhuyenMaiBusiness
    {
        private IKhuyenMaiRepository _res;
        public KhuyenMaiBusiness(IKhuyenMaiRepository res)
        {
            _res = res;
        }
        public KhuyenMaiModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(KhuyenMaiModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhuyenMaiModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaKhuyenMai)
        {
            return _res.Delete(MaKhuyenMai);
        }
        public List<KhuyenMaiModel> Search(int pageIndex, int pageSize, out long total, string ma_khuyenmai, string ten_khuyenmai)
        {
            return _res.Search(pageIndex, pageSize, out total, ma_khuyenmai, ten_khuyenmai);
        }
    }
}
