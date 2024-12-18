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
    public class NhanVienController : ControllerBase
    {
        private INhanVienBusiness _nhanvienBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public NhanVienController(INhanVienBusiness nhanvienBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _nhanvienBusiness = nhanvienBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{MaNV}")]
        [HttpGet]
        public NhanVienModel GetDatabyID(string MaNV)
        {
            return _nhanvienBusiness.GetDatabyID(MaNV);
        }
        [Route("Create-NhanVien")]
        [HttpPost]
        public NhanVienModel CreateItem([FromBody] NhanVienModel model)
        {
            _nhanvienBusiness.Create(model);
            return model;
        }
        [Route("Update-NhanVien")]
        [HttpPost]
        public NhanVienModel UpdateItem([FromBody] NhanVienModel model)
        {
            _nhanvienBusiness.Update(model);
            return model;
        }
        [Route("Delete-NhanVien")]
        [HttpDelete]
        public bool Delete(string MaNV)
        {
            return _nhanvienBusiness.Delete(MaNV);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_nhan_vien = "";
                if (formData.Keys.Contains("ma_nhan_vien") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_nhan_vien"]))) { ma_nhan_vien = Convert.ToString(formData["ma_nhan_vien"]); }
                string ten_nhan_vien = "";
                if (formData.Keys.Contains("ten_nhan_vien") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_nhan_vien"]))) { ten_nhan_vien = Convert.ToString(formData["ten_nhan_vien"]); }
                long total = 0;
                var data = _nhanvienBusiness.Search(page, pageSize, out total, ma_nhan_vien, ten_nhan_vien);
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
