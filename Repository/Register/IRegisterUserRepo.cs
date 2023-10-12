using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.Register
{
    public interface IRegisterUserRepo   ////
    {
        User GetDetails(int userId);
        List<User> GetAllUser();
        bool RegisterUser(User user);
        bool ForgotPassword(UpdatePasswordModel updatePassword);

        bool UserExist(long mobile);
    }
}
