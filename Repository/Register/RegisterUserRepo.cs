using HeathProject.DbContexts;
using HeathProject.Helper;
using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.Register
{
    public class RegisterUserRepo : IRegisterUserRepo
    {
        public testContext db;
        public RegisterUserRepo(testContext db)
        {
            this.db = db;
        }

        public bool RegisterUser(User user)  
        {
                user.Password = DbHelper.Encrypt(user.Password);
                db.Add(user);
                db.SaveChanges();

            return true;
        }
        public bool ForgotPassword(UpdatePasswordModel updatePassword)
        {
            var user = db.Users.Where(x => x.UserId == updatePassword.UserId || x.Phone == updatePassword.MobileNo).FirstOrDefault();

            if(user!= null)
            {
                user.Password = DbHelper.Encrypt(updatePassword.Password);
                db.SaveChanges();
                return true;
            }

            return false;

        }

        public User GetDetails(int userId)
        {

            User user = db.Users.Where(x => x.UserId == userId).FirstOrDefault();
            return user;
        }

        public bool UserExist(long mobile)
        {
                User user = db.Users.SingleOrDefault(x => x.Phone == mobile);

                if (user != null)
                {
                    return true;
                }
                return false;

        }

        public List<User> GetAllUser()
        {
           List<User> users=db.Users.ToList();
            return users;
        }
    }
}
