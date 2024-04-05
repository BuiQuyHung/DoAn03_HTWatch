using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface IMenuRepository
    {
        MenuModel GetDatabyID(string MaMenu);
        bool Create(MenuModel model);
        bool Update(MenuModel model);
        bool Delete(string MaMenu);
        public List<MenuModel> Search(int pageIndex, int pageSize, out long total, string ma_menu, string ten_menu);
    }
}
