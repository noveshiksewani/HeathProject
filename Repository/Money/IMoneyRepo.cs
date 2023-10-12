using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeathProject.Models;

namespace HeathProject.Repository
{
    public interface IMoneyRepo
    {
        bool OrderCreate(Money money,int userId);
        User GetUserById(int id);
        bool OrderComplete(OrderComplete order);
        List<Money> GetAllMoney();
    }
}
