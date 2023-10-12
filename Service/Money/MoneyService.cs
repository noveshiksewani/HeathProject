using HeathProject.Repository;
using System;
using HeathProject.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Money
{
    public class MoneyService : IMoneyService
    {
        public IMoneyRepo db;

        public MoneyService(IMoneyRepo db)
        {
            this.db = db;
        }

        public bool OrderCreate(Models.Money money,int userId)
        {
            return db.OrderCreate(money,userId);
        }

        public User GetUserById(int id)
        {
            return db.GetUserById(id);
        }

        public bool OrderComplete(OrderComplete orderComplete)
        {
            return db.OrderComplete(orderComplete);
        }

        public List<Models.Money> GetAllMoney()
        {
            return db.GetAllMoney();
        }
    }
}
