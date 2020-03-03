using Microsoft.IdentityModel.Tokens;
using mysqlefcore;
using mysqlefcoreConsole.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace mysqlefcoreConsole.Services
{
    public class AuthenticationService
    {
        DB db;
        Result result = new Result();

        public AuthenticationService()
        {
            db = new DB();
        }

        public Result Get()
        {
            Users users = new Users();
            List<Users> ListOfusers = new List<Users>();
            try
            {
                ListOfusers = db.Users.Where(w => w.id != 0).ToList();
                if (users != null)
                {
                    result.users = ListOfusers;
                    result.message = "OK";
                    result.status = 200;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public Result Post(Autentication autentication)
        {
            try
            {
                var user = db.Users.Where(w => w.username == autentication.username && w.password == autentication.password).FirstOrDefault();
                if (user != null && user.password == autentication.password && user.username == autentication.username)
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("UserID",user.id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1), // time
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHadle = new JwtSecurityTokenHandler();
                    var securityToken = tokenHadle.CreateToken(tokenDescriptor);
                    var token = tokenHadle.WriteToken(securityToken);

                    result.autentication = token;
                    result.message = "OK";
                    result.status = 200;
                }
                else
                {
                    result.message = "User not found";
                    result.status = 401;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}

