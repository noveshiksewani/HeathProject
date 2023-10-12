using HeathProject.Models;
using HeathProject.Repository.DonateFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.DonateFood
{
    public class FoodService : IFoodService
    {
        public IFoodRepo foodRepo;
        public FoodService(IFoodRepo foodRepo)
        {
            this.foodRepo = foodRepo;
        }
        public bool DonateFood(Food food,int userId)
        {
            return foodRepo.DonateFood(food,userId);
        }

        public List<Food> GetAllFood()
        {
            return foodRepo.GetAllFood();
        }
    }
}
