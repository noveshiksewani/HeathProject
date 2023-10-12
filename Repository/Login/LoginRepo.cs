using HeathProject.DbContexts;
using HeathProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HeathProject.Helper;
using HeathProject.CustomException;

namespace HeathProject.Repository.Login
{
    public class LoginRepo : ILoginRepo
    {
        public IConfiguration _config;
        public testContext authorizeDbContext;

        public LoginRepo(IConfiguration config, testContext authorizeDbContext)
        {
            this.authorizeDbContext = authorizeDbContext;
            _config = config;
        }
        public (string,string) GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                
        new Claim(ClaimTypes.Role,user.Role) , new Claim(ClaimTypes.PrimarySid , user.UserId.ToString() )};


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return (new JwtSecurityTokenHandler().WriteToken(token), user.Role);
            // return (new JwtSecurityTokenHandler().WriteToken(token),user.Role,user.UserId);
        }
        public User AuthenticateUser(User login)
        {
            User user = null;
            string password = DbHelper.Encrypt(login.Password);
            user = authorizeDbContext.Users.Where(user => (user.UserName.Equals(login.UserName))||(user.Email.Equals(login.UserName))|| (user.Phone.Equals(login.UserName))).FirstOrDefault();
            if(user!=null)
            {
                if(user.Password.Equals(password))
                {
                    return user;
                }
                else
                {
                    throw new InvalidDataException("Invalid Username or Password");
                }
            }
            else
            {
                throw new InvalidDataException("Invalid Username or Password");
            }
            
        }
    }
}
