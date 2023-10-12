using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeathProject.Models;

namespace HeathProject.Service.Money
{
    public interface IMoneyService
    {
        bool OrderCreate(Models.Money money,int userId);
        User GetUserById(int id);
        bool OrderComplete(OrderComplete orderComplete);
        List<Models.Money> GetAllMoney();
    }
}
