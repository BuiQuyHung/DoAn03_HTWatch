using DAL_TGDD.Interfaces;
using DataAccessLayer;
using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TGDD
{
    public class  MenuRepository : IMenuRepository
    {
        private IDatabaseHelper _dbHelper;
        public MenuRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public MenuModel GetDatabyID(string MaMenu)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_menu_get_by_id",
                     "@MaMenu", MaMenu);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MenuModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(MenuModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_menu_create",
                "@TenMenu", model.TenMenu,
                "@Cap", model.Cap,
                "@MaMenuCha", model.MaMenuCha);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(MenuModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_menu_update",
                "@MaMenu", model.MaMenu,
                "@TenMenu", model.TenMenu,
                "@Cap", model.Cap,
                "@MaMenuCha", model.MaMenuCha);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(string MaMenu)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_menu_delete",
                "@MaMenu", MaMenu
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MenuModel> Search(int pageIndex, int pageSize, out long total, string ma_menu, string ten_menu)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_menu_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ma_menu", ma_menu,
                    "@ten_menu", ten_menu);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<MenuModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

