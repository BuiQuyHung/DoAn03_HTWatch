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
    public class DonHangBusiness : IDonHangBusiness
    {
        private IDonHangRepository _res;
        public DonHangBusiness(IDonHangRepository res)
        {
            _res = res;
        }
        public DonHangModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(DonHangModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DonHangModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaDonHang)
        {
            return _res.Delete(MaDonHang);
        }
        public List<DonHangModel> Search(int pageIndex, int pageSize, out long total, string ma_don_hang, string ten_khach_hang)
        {
            return _res.Search(pageIndex, pageSize, out total, ma_don_hang, ten_khach_hang);
        }
    }
}
