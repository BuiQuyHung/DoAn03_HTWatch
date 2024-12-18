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
    public class NhaPhanPhoiController : ControllerBase
    {
        private INhaPhanPhoiBusiness _nhaphanphoiBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public NhaPhanPhoiController(INhaPhanPhoiBusiness nhaphanphoiBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _nhaphanphoiBusiness = nhaphanphoiBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-all-data")]
        [HttpGet]
        public IEnumerable<NhaPhanPhoiModel> GetAllData()
        {
            return _nhaphanphoiBusiness.GetAllData();
        }
        [Route("get-by-id/{MaNPP}")]
        [HttpGet]
        public NhaPhanPhoiModel GetDatabyID(string MaNPP)
        {
            return _nhaphanphoiBusiness.GetDatabyID(MaNPP);
        }
        [Route("Create-NhaPhanPhoi")]
        [HttpPost]
        public NhaPhanPhoiModel CreateItem([FromBody] NhaPhanPhoiModel model)
        {
            _nhaphanphoiBusiness.Create(model);
            return model;
        }
        [Route("Update-NhaPhanPhoi")]
        [HttpPost]
        public NhaPhanPhoiModel UpdateItem([FromBody] NhaPhanPhoiModel model)
        {
            _nhaphanphoiBusiness.Update(model);
            return model;
        }
        [Route("Delete-NhaPhanPhoi")]
        [HttpDelete]
        public bool Delete(string MaNPP)
        {
            return _nhaphanphoiBusiness.Delete(MaNPP);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_npp = "";
                if (formData.Keys.Contains("ma_nha_phan_phoi") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_nha_phan_phoi"]))) { ma_npp = Convert.ToString(formData["ma_nha_phan_phoi"]); }
                string ten_npp = "";
                if (formData.Keys.Contains("ten_nha_phan_phoi") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_nha_phan_phoi"]))) { ten_npp = Convert.ToString(formData["ten_nha_phan_phoi"]); }
                long total = 0;
                var data = _nhaphanphoiBusiness.Search(page, pageSize, out total, ma_npp, ten_npp);
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
