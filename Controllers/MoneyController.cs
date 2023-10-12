using HeathProject.Models;
using HeathProject.Service.Money;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeathProject.Controllers
{
    //Get All Money, Create Order, Get Order status
    [Authorize(Roles = Roles.User + "," + Roles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoneyController : ControllerBase
    {

        public IMoneyService moneyService;

        public MoneyController(IMoneyService moneyService)
        {
            this.moneyService = moneyService;

        }
        //Get All Money
        [HttpGet]
        public ActionResult<IEnumerable<Money>> GetAllMoney()
        {
            try
            {
                return moneyService.GetAllMoney();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        //Order Create
        [HttpPost]
        public IActionResult OrderCreate(Money money)
        {

            RazorpayClient razorpay = new RazorpayClient("rzp_test_jONXJgNvQSkBVT", "uqa8W9zXuMBKAsiHfLIomeKN");

            Dictionary<string, object> options = new Dictionary<string, object>();

            options.Add("amount",(money.Amount * 100));
            options.Add("currency", "INR");
            options.Add("payment_capture", 1);

            Order order = new Order();
            var orderinfo = order.Create(options);

            money.OrderId = orderinfo["id"];
            int userId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);

            money.UserId = userId;


            if (moneyService.OrderCreate(money,userId))
            {


                var user = moneyService.GetUserById(userId);

                Dictionary<string, object> moneyData = new Dictionary<string, object>();
                moneyData.Add("amount", orderinfo["amount"] /100);
                moneyData.Add("name", user.Name);
                moneyData.Add("order_id", orderinfo["id"]);
                moneyData.Add("email", user.Email);
                moneyData.Add("phone", user.Phone);
                return Ok(moneyData);
            }
            else
            {
                return Ok(HttpStatusCode.BadRequest);
            }

        }

        //Show Status of Order
        [HttpPost("ordercomplete")]
        public IActionResult OrderComplete(OrderComplete order)
        {
            if (order.order_id != "") { 
                if (moneyService.OrderComplete(order))
                {
                    return Ok(HttpStatusCode.OK);
                }
            return Ok(HttpStatusCode.NoContent);
            }
           
           return Ok(HttpStatusCode.NoContent);




        }
    }
}
