using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.DonateFood
{
    public interface IFoodService
    {
        bool DonateFood(Food food,int userId);
        List<Food> GetAllFood();
    }
}
