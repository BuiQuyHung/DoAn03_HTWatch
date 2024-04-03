using BBL_TGDD;
using BBL_TGDD.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        [Route("Create-SanPham")]
        [HttpPost]
        public SanPhamModel CreateItem([FromBody] SanPhamModel model)
        {
            _sanphamBusiness.Create(model);
            return model;
        }
        [Route("Update-SanPham")]
        [HttpPost]
        public SanPhamModel UpdateItem([FromBody] SanPhamModel model)
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
        [Route("thong-ke-hang-hoa-ton-kho")]
        [HttpGet]
        public List<ThongKeHangHoaTonKhoModel> ThongKeHangHoaTonKho()
        {
            return _sanphamBusiness.ThongKeHangHoaTonKho();
        }
    }
}
