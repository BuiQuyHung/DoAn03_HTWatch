using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public interface IUserRepository
    {
        UserModel GetUser(string username, string password);
        UserModel GetDatabyID(string id);
        bool Create(UserModel model);
        bool Update(UserModel model);
        bool Delete(string id);
        List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);
        UserModel GetUser(string username);
    }
}
