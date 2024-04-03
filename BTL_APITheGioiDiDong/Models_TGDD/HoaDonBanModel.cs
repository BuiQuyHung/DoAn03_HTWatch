using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_TGDD
{
    public class HoaDonBanModel
    {
        public string MaHDBan { get; set; }
        public int MaCTHDBan { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public string TongTien { get; set; }
        public List<ChiTietHoaDonBanModel> list_json_chitiethoadonban { get; set; }
    }
    public class ChiTietHoaDonBanModel
    {
        public int MaCTHDBan { get; set; }
        public int MaHDBan { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
