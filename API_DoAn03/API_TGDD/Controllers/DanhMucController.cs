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
    public class DanhMucController : ControllerBase
    {
        private IDanhMucBusiness _danhmucBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public DanhMucController(IDanhMucBusiness danhmucBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _danhmucBusiness = danhmucBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-all-data")]
        [HttpGet]
        public IEnumerable<DanhMucModel> GetAllData()
        {
            return _danhmucBusiness.GetAllData();
        }
        [Route("get-by-id/{MaDanhMuc}")]
        [HttpGet]
        public DanhMucModel GetDatabyID(string MaDanhMuc)
        {
            return _danhmucBusiness.GetDatabyID(MaDanhMuc);
        }
        [Route("Create-DanhMuc")]
        [HttpPost]
        public DanhMucModel CreateItem([FromBody] DanhMucModel model)
        {
            _danhmucBusiness.Create(model);
            return model;
        }
        [Route("Update-DanhMuc")]
        [HttpPost]
        public DanhMucModel UpdateItem([FromBody] DanhMucModel model)
        {
            _danhmucBusiness.Update(model);
            return model;
        }
        [Route("Delete-DanhMuc")]
        [HttpDelete]
        public bool Delete(string MaDanhMuc)
        {
            return _danhmucBusiness.Delete(MaDanhMuc);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_danh_muc = "";
                if (formData.Keys.Contains("ma_danh_muc") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_danh_muc"]))) { ma_danh_muc = Convert.ToString(formData["ma_danh_muc"]); }
                string ten_danh_muc = "";
                if (formData.Keys.Contains("ten_danh_muc") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_danh_muc"]))) { ten_danh_muc = Convert.ToString(formData["ten_danh_muc"]); }
                long total = 0;
                var data = _danhmucBusiness.Search(page, pageSize, out total, ma_danh_muc, ten_danh_muc);
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
