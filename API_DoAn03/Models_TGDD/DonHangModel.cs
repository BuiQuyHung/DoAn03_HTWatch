using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_TGDD
{
    public class DonHangModel
    {
        public int MaDonHang { get; set; }
        public string TenKH { get; set; }
   
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayTao { get; set; }

        public List<ChiTietDonHangModel> list_json_chitietdonhang { get; set; }
    }
    public class ChiTietDonHangModel
    {
        public int MaChiTietHoaDonBan { get; set; }
        public int MaHoaDonBan { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public string GiaSP { get; set; }
        public string TongTien { get; set; }
    }
}
