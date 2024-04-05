using Models_TGDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL_TGDD.Interfaces
{
    public partial interface IUserBusiness
    {
        UserModel Login(string UserID, string Pass);
    }
}
