using DAL_TGDD.Interfaces;
using Models_TGDD;
using BBL_TGDD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD
{
    public class MenuBusiness : IMenuBusiness
    {
        private IMenuRepository _res;
        public MenuBusiness(IMenuRepository res)
        {
            _res = res;
        }
        public MenuModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(MenuModel model)
        {
            return _res.Create(model);
        }
        public bool Update(MenuModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaMenu)
        {
            return _res.Delete(MaMenu);
        }
        public List<MenuModel> Search(int pageIndex, int pageSize, out long total, string ma_menu, string ten_menu)
        {
            return _res.Search(pageIndex, pageSize, out total, ma_menu, ten_menu);
        }
    }
}
