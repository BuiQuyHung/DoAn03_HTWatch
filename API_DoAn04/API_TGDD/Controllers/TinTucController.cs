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
    public class TinTucController : ControllerBase
    {
        private ITinTucBusiness _tintucBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public TinTucController(ITinTucBusiness tintucBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _tintucBusiness = tintucBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{MaTinTuc}")]
        [HttpGet]
        public TinTucModel GetDatabyID(string MaTinTuc)
        {
            return _tintucBusiness.GetDatabyID(MaTinTuc);
        }
        [Route("Create-TinTuc")]
        [HttpPost]
        public TinTucModel CreateItem([FromBody] TinTucModel model)
        {
            _tintucBusiness.Create(model);
            return model;
        }
        [Route("Update-TinTuc")]
        [HttpPost]
        public TinTucModel UpdateItem([FromBody] TinTucModel model)
        {
            _tintucBusiness.Update(model);
            return model;
        }
        [Route("Delete-TinTuc")]
        [HttpDelete]
        public bool Delete(string MaTinTuc)
        {
            return _tintucBusiness.Delete(MaTinTuc);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_tin_tuc = "";
                if (formData.Keys.Contains("ma_tin_tuc") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_tin_tuc"]))) { ma_tin_tuc = Convert.ToString(formData["ma_tin_tuc"]); }
                string tieu_de = "";
                if (formData.Keys.Contains("tieu_de") && !string.IsNullOrEmpty(Convert.ToString(formData["tieu_de"]))) { tieu_de = Convert.ToString(formData["tieu_de"]); }
                long total = 0;
                var data = _tintucBusiness.Search(page, pageSize, out total, ma_tin_tuc, tieu_de);
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
