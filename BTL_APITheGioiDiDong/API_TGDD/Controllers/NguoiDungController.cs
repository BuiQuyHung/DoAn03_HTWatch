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
    public class NguoiDungController : ControllerBase
    {
        private INguoiDungBusiness _nguoidungBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        private object _bus;

        public NguoiDungController(INguoiDungBusiness nguoidungBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _nguoidungBusiness = nguoidungBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{UserID}")]
        [HttpGet]
        public NguoiDungModel GetDatabyID(string UserID)
        {
            return _nguoidungBusiness.GetDatabyID(UserID);
        }
        [Route("Create-NguoiDung")]
        [HttpPost]
        public NguoiDungModel CreateItem([FromBody] NguoiDungModel model)
        {
            _nguoidungBusiness.Create(model);
            return model;
        }
        [Route("Update-NguoiDung")]
        [HttpPost]
        public NguoiDungModel UpdateItem([FromBody] NguoiDungModel model)
        {
            _nguoidungBusiness.Update(model);
            return model;
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string UserID = "";
                if (formData.Keys.Contains("UserID") && !string.IsNullOrEmpty(Convert.ToString(formData["UserID"]))) { UserID = Convert.ToString(formData["UserID"]); }
                int Per = 0;
                if (formData.Keys.Contains("Per") && formData["Per"] != null && formData["Per"].ToString() != "")
                {
                    Per = Convert.ToInt32(formData["Per"].ToString());

                }
                long total = 0;
                var data = _nguoidungBusiness.Search(page, pageSize, out total, UserID, Per);
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
