using HeathProject.Models;
using HeathProject.Service.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeathProject.Controllers
{
    //Login and Get by Id
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        //Login
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            IActionResult response = Unauthorized();
            User user = new User();
            try
            {
                user = loginService.AuthenticateUser(login);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
            if (user != null)
            {
                var tokenString = loginService.GenerateJSONWebToken(user);
                // response = Ok(new { token = tokenString.Item1, Role = tokenString.Item2,ID=tokenString.Item3 });
                response = Ok(new { token = tokenString.Item1, Role = tokenString.Item2 });
            }
            return response;
        }
        //Get UserID
        [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        [HttpGet]
        public IActionResult GetId()
        {

            try
            {
                int userId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
                return Ok(userId);
            }
          
              catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        
        
    }
}
