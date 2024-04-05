using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface IMenuBusiness
    {
        MenuModel GetDatabyID(string id);
        bool Create(MenuModel model);
        bool Update(MenuModel model);
        bool Delete(string MaMenu);
        public List<MenuModel> Search(int pageIndex, int pageSize, out long total, string ma_menu, string ten_menu);
    }
}
