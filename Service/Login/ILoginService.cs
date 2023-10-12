using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Login
{
    public interface ILoginService
    {
        //  public (string, string,int) GenerateJSONWebToken(User user);
        public (string, string) GenerateJSONWebToken(User user);
        public User AuthenticateUser(User login);
    }
}
