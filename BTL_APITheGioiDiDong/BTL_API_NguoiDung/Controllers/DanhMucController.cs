using BBL_TGDD.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models_TGDD;

namespace BTL_API_NguoiDung.Controllers
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
            [Route("get-by-id/{MaDM}")]
            [HttpGet]
            public DanhMucModel GetDatabyID(string MaDM)
            {
                return _danhmucBusiness.GetDatabyID(MaDM);
            }
          
            
            [Route("search")]
            [HttpPost]
            public IActionResult Search([FromBody] Dictionary<string, object> formData)
            {
                try
                {
                    var page = int.Parse(formData["page"].ToString());
                    var pageSize = int.Parse(formData["pageSize"].ToString());
                    string ten_dm = "";
                    if (formData.Keys.Contains("ten_DM") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_DM"]))) { ten_dm = Convert.ToString(formData["ten_DM"]); }
                    long total = 0;
                    var data = _danhmucBusiness.Search(page, pageSize, out total, ten_dm);
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
