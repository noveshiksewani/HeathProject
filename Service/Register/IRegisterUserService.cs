using HeathProject.Models;
using HeathProject.Repository.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Register
{
    public interface IRegisterUserService
    {
        User GetDetails(int userId);
       List<User> GetAllUser();
        bool RegisterUser(User user);

        bool ForgotPassword(UpdatePasswordModel updatePassword);

        bool UserExist(long mobile);

    }
}
