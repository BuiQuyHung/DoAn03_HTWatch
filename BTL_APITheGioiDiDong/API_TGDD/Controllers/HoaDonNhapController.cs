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
    public class HoaDonNhapController : ControllerBase
    {
        private IHoaDonNhapBusiness _hoadonnhapBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public HoaDonNhapController(IHoaDonNhapBusiness hoadonnhapBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _hoadonnhapBusiness = hoadonnhapBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id")]
        [HttpGet]
        public HoaDonNhapModel GetDatabyID(string MaHDNhap)
        {
            return _hoadonnhapBusiness.GetDatabyID(MaHDNhap);
        }
        [Route("Create-HoaDonNhap")]
        [HttpPost]
        public HoaDonNhapModel CreateItem([FromBody] HoaDonNhapModel model)
        {
            _hoadonnhapBusiness.Create(model);
            return model;
        }
        [Route("Update-HoaDonNhap")]
        [HttpPost]
        public HoaDonNhapModel UpdateItem([FromBody] HoaDonNhapModel model)
        {
            _hoadonnhapBusiness.Update(model);
            return model;
        }
        [Route("Delete-HoaDonNhap")]
        [HttpDelete]
        public bool Delete(string MaHDNhap)
        {
            return _hoadonnhapBusiness.Delete(MaHDNhap);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_hoa_don = "";
                if (formData.Keys.Contains("ma_hoa_don") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_hoa_don"]))) { ma_hoa_don = Convert.ToString(formData["ma_hoa_don"]); }
                string ma_NV = "";
                if (formData.Keys.Contains("ma_NV") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_NV"]))) { ma_NV = Convert.ToString(formData["ma_NV"]); }
                string ma_NPP = "";
                if (formData.Keys.Contains("ma_NPP") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_NPP"]))) { ma_NPP = Convert.ToString(formData["ma_NPP"]); }
                long total = 0;
                var data = _hoadonnhapBusiness.Search(page, pageSize, out total, ma_hoa_don, ma_NV, ma_NPP);
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
    }
}
