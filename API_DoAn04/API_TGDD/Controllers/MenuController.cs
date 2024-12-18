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
    public class MenuController : ControllerBase
    {
        private IMenuBusiness _menuBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public MenuController(IMenuBusiness menuBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _menuBusiness = menuBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{MaMenu}")]
        [HttpGet]
        public MenuModel GetDatabyID(string MaMenu)
        {
            return _menuBusiness.GetDatabyID(MaMenu);
        }
        [Route("Create-Menu")]
        [HttpPost]
        public MenuModel CreateItem([FromBody] MenuModel model)
        {
            _menuBusiness.Create(model);
            return model;
        }
        [Route("Update-Menu")]
        [HttpPost]
        public MenuModel UpdateItem([FromBody] MenuModel model)
        {
            _menuBusiness.Update(model);
            return model;
        }
        [Route("Delete-Menu")]
        [HttpDelete]
        public bool Delete(string MaMenu)
        {
            return _menuBusiness.Delete(MaMenu);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ma_menu = "";
                if (formData.Keys.Contains("ma_menu") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_menu"]))) { ma_menu = Convert.ToString(formData["ma_menu"]); }
                string ten_menu = "";
                if (formData.Keys.Contains("ten_menu") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_menu"]))) { ten_menu = Convert.ToString(formData["ten_menu"]); }
                long total = 0;
                var data = _menuBusiness.Search(page, pageSize, out total, ma_menu, ten_menu);
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
