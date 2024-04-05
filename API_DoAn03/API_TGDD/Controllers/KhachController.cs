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
    public class KhachController : ControllerBase
    {
        private IKhachBusiness _khachBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public KhachController(IKhachBusiness khachBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _khachBusiness = khachBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{MaKH}")]
        [HttpGet]
        public KhachModel GetDatabyID(string MaKH)
        {
            return _khachBusiness.GetDatabyID(MaKH);
        }
        [Route("Create-KhachHang")]
        [HttpPost]
        public KhachModel CreateItem([FromBody] KhachModel model)
        {
            _khachBusiness.Create(model);
            return model;
        }
        [Route("Update-KhachHang")]
        [HttpPost]
        public KhachModel UpdateItem([FromBody] KhachModel model)
        {
            _khachBusiness.Update(model);
            return model;
        }
        [Route("Delete-KhachHang")]
        [HttpDelete]
        public bool Delete(string MaKH)
        {
            return _khachBusiness.Delete(MaKH);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_khach = "";
                if (formData.Keys.Contains("ma_khach") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_khach"]))) { ma_khach = Convert.ToString(formData["ma_khach"]); }
                string ten_khach = "";
                if (formData.Keys.Contains("ten_khach") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khach"]))) { ten_khach = Convert.ToString(formData["ten_khach"]); }
                long total = 0;
                var data = _khachBusiness.Search(page, pageSize, out total, ma_khach, ten_khach);
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
