using BBL_TGDD;
using BBL_TGDD.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model;
using Models_TGDD;

namespace API_TGDD.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _sanphamBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public SanPhamController(ISanPhamBusiness sanphamBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _sanphamBusiness = sanphamBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{MaSP}")]
        [HttpGet]
        public SanPhamModel GetDatabyID(string MaSP)
        {
            return _sanphamBusiness.GetDatabyID(MaSP);
        }
        [Route("get-data")]
        [HttpGet]
        public IEnumerable<SanPhamModel> GetData()
        {
            return _sanphamBusiness.GetData();
        }
        [Route("Create-SanPham")]
        [HttpPost]
        public SanPhamModel2 CreateItem([FromBody] SanPhamModel2 model)
        {
            _sanphamBusiness.Create(model);
            return model;
        }
        [Route("Update-SanPham")]
        [HttpPost]
        public SanPhamModel2 UpdateItem([FromBody] SanPhamModel2 model)
        {
            _sanphamBusiness.Update(model);
            return model;
        }
        [Route("Delete-SanPham")]
        [HttpDelete]
        public bool Delete(string MaSP)
        {
            return _sanphamBusiness.Delete(MaSP);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_san_pham = "";
                if (formData.Keys.Contains("ma_san_pham") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_san_pham"]))) { ma_san_pham = Convert.ToString(formData["ma_san_pham"]); }
                string ten_san_pham = "";
                if (formData.Keys.Contains("ten_san_pham") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_san_pham"]))) { ten_san_pham = Convert.ToString(formData["ten_san_pham"]); }
                long total = 0;
                var data = _sanphamBusiness.Search(page, pageSize, out total, ma_san_pham, ten_san_pham);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("search1")]
        [HttpPost]
        public IActionResult Search1([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_danh_muc = "";
                if (formData.Keys.Contains("MaDanhMuc") && !string.IsNullOrEmpty(Convert.ToString(formData["MaDanhMuc"]))) { ma_danh_muc = Convert.ToString(formData["MaDanhMuc"]); }
                long total = 0;
                var data = _sanphamBusiness.Search1(page, pageSize, out total, ma_danh_muc);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("thongke-sanpham-tonkho")]
        [HttpPost]
        public IActionResult ThongKeSanPhamTonKho([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());

                long total = 0;
                var data = _sanphamBusiness.ThongKeSanPhamTonKho(page, pageSize, out total);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("thongke-sanpham-banchay")]
        [HttpPost]

        public IActionResult ThongKeSanPhamBanChay([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                DateTime NgayBatDau = DateTime.MinValue; // Khởi tạo Ngay là null
                if (formData.Keys.Contains("NgayBatDau") && !string.IsNullOrEmpty(Convert.ToString(formData["NgayBatDau"])))
                {
                    NgayBatDau = DateTime.Parse(Convert.ToString(formData["NgayBatDau"])); // Chuyển đổi từ chuỗi sang DateTime
                }
                DateTime NgayKetThuc = DateTime.MinValue; // Khởi tạo Ngay là null
                if (formData.Keys.Contains("NgayKetThuc") && !string.IsNullOrEmpty(Convert.ToString(formData["NgayKetThuc"])))
                {
                    NgayKetThuc = DateTime.Parse(Convert.ToString(formData["NgayKetThuc"])); // Chuyển đổi từ chuỗi sang DateTime
                }
                long total = 0;
                var data = _sanphamBusiness.ThongKeSanPhamBanChay(page, pageSize, out total, NgayBatDau, NgayKetThuc);
                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = page,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [Route("Bao-cao-doanh-thu")]
        [HttpPost]
        public IActionResult BaoCaoDoanhThu([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                DateTime NgayBatDau = DateTime.MinValue; // Khởi tạo Ngay là null
                if (formData.Keys.Contains("NgayBatDau") && !string.IsNullOrEmpty(Convert.ToString(formData["NgayBatDau"])))
                {
                    NgayBatDau = DateTime.Parse(Convert.ToString(formData["NgayBatDau"])); // Chuyển đổi từ chuỗi sang DateTime
                }
                DateTime NgayKetThuc = DateTime.MinValue; // Khởi tạo Ngay là null
                if (formData.Keys.Contains("NgayKetThuc") && !string.IsNullOrEmpty(Convert.ToString(formData["NgayKetThuc"])))
                {
                    NgayKetThuc = DateTime.Parse(Convert.ToString(formData["NgayKetThuc"])); // Chuyển đổi từ chuỗi sang DateTime
                }
                long total = 0;
                var data = _sanphamBusiness.BaoCaoDoanhThu(page, pageSize, out total, NgayBatDau, NgayKetThuc);
                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = page,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [Route("Bao-cao-doanh-thu-theo-nam")]
        [HttpPost]
        public List<BaoCaoDoanhThuTheoNamModel> BaoCaoDoanhThuTheoNam(int Nam)
        {
            return _sanphamBusiness.BaoCaoDoanhThuTheoNam(Nam);
        }
    }
}
