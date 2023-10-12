using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.Login
{
    public interface ILoginRepo
    {
        //public (string, string,int) GenerateJSONWebToken(User user);
        public (string, string) GenerateJSONWebToken(User user);
        public User AuthenticateUser(User login);
    }
}
