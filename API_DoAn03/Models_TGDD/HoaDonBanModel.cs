using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_TGDD
{
    public class HoaDonBanModel
    {
        public int MaHDBan { get; set; }
        public DateTime NgayBan { get; set; }
        public int MaNV { get; set; }
        public int MaKH { get; set; }
        public decimal TongTien { get; set; }
        public List<ChiTietHoaDonBanModel> list_json_chitiethoadonban { get; set; }
    }
    public class ChiTietHoaDonBanModel
    {
        public int MaCTHDBan { get; set; }
        public int MaHDBan { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }
    }
}
