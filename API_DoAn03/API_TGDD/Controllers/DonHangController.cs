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
    public class DonHangController : ControllerBase
    {
        private IDonHangBusiness _DonHangBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public DonHangController(IDonHangBusiness DonHangBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _DonHangBusiness = DonHangBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id")]
        [HttpGet]
        public DonHangModel GetDatabyID(string MaDonHang)
        {
            return _DonHangBusiness.GetDatabyID(MaDonHang);
        }
        [Route("Create-DonHang")]
        [HttpPost]
        public DonHangModel CreateItem([FromBody] DonHangModel model)
        {
            _DonHangBusiness.Create(model);
            return model;
        }
        [Route("Update-DonHang")]
        [HttpPost]
        public DonHangModel UpdateItem([FromBody] DonHangModel model)
        {
            _DonHangBusiness.Update(model);
            return model;
        }
        [Route("Delete-DonHang")]
        [HttpDelete]
        public bool Delete(string MaDonHang)
        {
            return _DonHangBusiness.Delete(MaDonHang);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = 1; // Giá trị mặc định hoặc giá trị bạn muốn xác định khi không tìm thấy khóa "page".
                if (formData.ContainsKey("page"))
                {
                    page = int.Parse(formData["page"].ToString());
                }

                // Tương tự, kiểm tra và xử lý cho khóa "pageSize".
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_don_hang = "";
                if (formData.Keys.Contains("ma_don_hang") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_don_hang"])))
                {
                    ma_don_hang = Convert.ToString(formData["ma_don_hang"]);
                }
                string ten_khach_hang = "";
                if (formData.Keys.Contains("ten_kh") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_kh"])))
                {
                    ten_khach_hang = Convert.ToString(formData["ten_kh"]);
                }

                long total = 0;
                var data = _DonHangBusiness.Search(page, pageSize, out total, ma_don_hang, ten_khach_hang);

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

    }
}
