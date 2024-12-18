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
    public class KhuyenMaiController : ControllerBase
    {
        private IKhuyenMaiBusiness _khuyenmaiBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public KhuyenMaiController(IKhuyenMaiBusiness khuyenmaiBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _khuyenmaiBusiness = khuyenmaiBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{MaKhuyenMai}")]
        [HttpGet]
        public KhuyenMaiModel GetDatabyID(string MaKhuyenMai)
        {
            return _khuyenmaiBusiness.GetDatabyID(MaKhuyenMai);
        }
        [Route("Create-KhuyenMai")]
        [HttpPost]
        public KhuyenMaiModel CreateItem([FromBody] KhuyenMaiModel model)
        {
            _khuyenmaiBusiness.Create(model);
            return model;
        }
        [Route("Update-KhuyenMai")]
        [HttpPost]
        public KhuyenMaiModel UpdateItem([FromBody] KhuyenMaiModel model)
        {
            _khuyenmaiBusiness.Update(model);
            return model;
        }
        [Route("Delete-KhuyenMai")]
        [HttpDelete]
        public bool Delete(string MaKhuyenMai)
        {
            return _khuyenmaiBusiness.Delete(MaKhuyenMai);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_khuyenmai = "";
                if (formData.Keys.Contains("ma_khuyenmai") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_khuyenmai"]))) { ma_khuyenmai = Convert.ToString(formData["ma_khuyenmai"]); }
                string ten_khuyenmai = "";
                if (formData.Keys.Contains("ten_khuyenmai") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khuyenmai"]))) { ten_khuyenmai = Convert.ToString(formData["ten_khuyenmai"]); }
                long total = 0;
                var data = _khuyenmaiBusiness.Search(page, pageSize, out total, ma_khuyenmai, ten_khuyenmai);
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
