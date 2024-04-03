using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_TGDD
{
    public class HoaDonNhapModel
    {
        public string MaHDNhap { get; set; }
        public int MaCTHDNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNV { get; set; }
        public string MaNPP { get; set; }
        public string TongTien { get; set; }
        public List<ChiTietHoaDonNhapModel> list_json_chitiethoadonnhap { get; set; }
    }
    public class ChiTietHoaDonNhapModel
    {
        public int MaCTHDNhap { get; set; }
        public int MaHDNhap { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
