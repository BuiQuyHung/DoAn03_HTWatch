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
    public class HoaDonBanController : ControllerBase
    {
        private IHoaDonBanBusiness _hoadonbanBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public HoaDonBanController(IHoaDonBanBusiness hoadonbanBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _hoadonbanBusiness = hoadonbanBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id")]
        [HttpGet]
        public HoaDonBanModel GetDatabyID(string MaHDBan)
        {
            return _hoadonbanBusiness.GetDatabyID(MaHDBan);
        }
        [Route("Create-HoaDonBan")]
        [HttpPost]
        public HoaDonBanModel CreateItem([FromBody] HoaDonBanModel model)
        {
            _hoadonbanBusiness.Create(model);
            return model;
        }
        [Route("Update-HoaDonBan")]
        [HttpPost]
        public HoaDonBanModel UpdateItem([FromBody] HoaDonBanModel model)
        {
            _hoadonbanBusiness.Update(model);
            return model;
        }
        [Route("Delete-HoaDonBan")]
        [HttpDelete]
        public bool Delete(string MaHDBan)
        {
            return _hoadonbanBusiness.Delete(MaHDBan);
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
                string ma_KH = "";
                if (formData.Keys.Contains("ma_KH") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_KH"]))) { ma_KH = Convert.ToString(formData["ma_KH"]); }
                long total = 0;
                var data = _hoadonbanBusiness.Search(page, pageSize, out total, ma_hoa_don, ma_NV, ma_KH);
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
