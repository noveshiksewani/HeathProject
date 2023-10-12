using HeathProject.Models;
using HeathProject.Repository.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Login
{
    public class LoginService : ILoginService
    {
        public ILoginRepo loginRepo;
        public LoginService(ILoginRepo loginRepo)
        {
            this.loginRepo = loginRepo;
        }

        public User AuthenticateUser(User login)
        {
            return loginRepo.AuthenticateUser(login);
        }

        public (string, string) GenerateJSONWebToken(User user)
        {
            return loginRepo.GenerateJSONWebToken(user);
        }
    }
}
