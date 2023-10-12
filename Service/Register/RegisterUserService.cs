using HeathProject.Models;
using HeathProject.Repository.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Register
{
    public class RegisterUserService : IRegisterUserService 
    {

        public IRegisterUserRepo users;

        public RegisterUserService(IRegisterUserRepo users)
        {
            this.users = users;

        }

        public bool RegisterUser(User user)
        {
            return users.RegisterUser(user);
        }
        public User GetDetails(int userId)
        {
            return users.GetDetails(userId);
        }

        public bool ForgotPassword(UpdatePasswordModel updatePassword)
        {
            return users.ForgotPassword(updatePassword);
        }

        public  bool UserExist(long mobile)
        {
            return users.UserExist(mobile);
        }

        public List<User> GetAllUser()
        {
            return users.GetAllUser();
        }
    }
}
