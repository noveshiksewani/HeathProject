using HeathProject.DbContexts;
using HeathProject.Helper;
using HeathProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository
{
    public class MoneyRepo : IMoneyRepo
    {

        public testContext db;

        public MoneyRepo(testContext db)
        {
            this.db = db;
        }
        DonationHelper dbHelper = new DonationHelper();
        public bool OrderCreate(Money money,int userId)
        {
            if (money != null)
            {
                db.Money.Add(money);
                db.SaveChanges();

                Donation donation = new Donation();

                donation = dbHelper.InsertDonation("Oxygen", "Donor", userId, money.MoneyId);
                db.Donations.Add(donation);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool OrderComplete(OrderComplete order)
        {
            var orderInfo = db.Money.SingleOrDefault(x => x.OrderId.Equals(order.order_id));
            if(orderInfo != null)
            {
                orderInfo.Status = 1;
                db.SaveChanges();
                return true;
            }
            return false;



        }


        public User GetUserById(int id)
        {
            if(id != null)
            {
                User user = db.Users.SingleOrDefault(x => x.UserId == id);
                return user;

            }
            return null;

            
        }

        public List<Money> GetAllMoney()
        {
            return db.Money.Include(x => x.User).ToList();
        }
    }
}
