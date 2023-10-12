using HeathProject.Models;
using HeathProject.Service.DonateFood;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeathProject.Controllers
{
    //Get All Food Details, Donate Food
    [Authorize(Roles = Roles.User + "," + Roles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        public IFoodService foodService;
        public FoodController(IFoodService foodService)
        {
            this.foodService = foodService;
        }
        //Get All Food Details
        //GET: api/Food
        [HttpGet]
        public ActionResult<IEnumerable<Food>> GetAllFood()
        {
            try
            {
                return foodService.GetAllFood();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        //Donate Food(Add Food Details)
        // POST api/Food
        [HttpPost]
        public IActionResult DonateFood([FromBody]Food food)
        {
            try
            {
                int userId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
                return Ok(foodService.DonateFood(food,userId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
