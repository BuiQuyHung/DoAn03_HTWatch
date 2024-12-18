using DAL_TGDD.Interfaces;
using Models_TGDD;
using BBL_TGDD.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System;
using Helper;


namespace BBL_TGDD
{
    public partial class UserBusiness : IUserBusiness
    {
        private IUserRepository _res;
        private string Secret;
        public UserBusiness(IUserRepository res, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _res = res;
        }
      
        public UserModel Authenticate(string username, string password)
        {
            var user = _res.GetUser(username, password);
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(Secret);
            var key = Encoding.ASCII.GetBytes("chuỗi-khóa-bí-mật-dài-có-ít-nhất-32-ký-tự");


            // Ensure key size is at least 256 bits (32 bytes)
            if (key.Length < 32)
            {
                throw new ApplicationException("Secret key length is insufficient.");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.hoten.ToString()),
                new Claim(ClaimTypes.StreetAddress, user.diachi)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            return user;
        }

        public UserModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(UserModel model)
        {
            return _res.Create(model);
        }
        public bool Update(UserModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
        {
            return _res.Search(pageIndex, pageSize, out total, hoten, taikhoan);
        }
    }
}
