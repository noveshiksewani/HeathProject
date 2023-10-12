using HeathProject.CustomException;
using HeathProject.DbContexts;
using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeathProject.Helper;
using Microsoft.EntityFrameworkCore;

namespace HeathProject.Repository.DonateFood
{
    public class FoodRepo : IFoodRepo
    {
        public testContext context;
        public FoodRepo(testContext context)
        {
            this.context = context;
        }
        DonationHelper db = new DonationHelper();
        public bool DonateFood(Food food,int userId)
        {
            if (food != null)
            {
                context.Foods.Add(food);
                context.SaveChanges();
                Donation donation = new Donation();
                
                donation = db.InsertDonation("Food","Donor",userId,food.FoodId);
                context.Donations.Add(donation);
                context.SaveChanges();
                return true;
            }
            else
                throw new InvalidDataException("Food Details Invalid");
        }

        public List<Food> GetAllFood()
        {
           /* select* from Donation inner  join Food on Donation.donationTypeId = Food.foodId where donationType = 'food'*/
            var result = (from cp in context.Donations.Include(x => x.User)
                          join p in context.Foods on cp.DonationTypeId equals p.FoodId
                          where cp.DonationType == "food"
                          select new Food
                          {
                              FoodId = p.FoodId,
                              Description = p.Description,
                              User = cp.User
                          }).ToList();
            //foods = context.Foods.ToList();
            //if (foods != null)
            //{
            //    return foods;
            //}
            //else
            //    throw new InvalidDataException("Food Donation is not Available");

            return result;
        }
    }
}
