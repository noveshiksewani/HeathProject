using HeathProject.Models;
using HeathProject.Service.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HeathProject.Controllers
{
    //Get All Users, Add User, Get User By UserID, Add Forgot Password, Check User Exist or Not
    [Route("api/[controller]")]
    [ApiController]

    public class RegisterController : ControllerBase
    {
        public IRegisterUserService service;

        public RegisterController(IRegisterUserService service)
        {
            this.service = service;
        }
        //Get All Users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(service.GetAllUser());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        //Add User
        [HttpPost]
        public ActionResult Register(User user)
        {

            if(ModelState.IsValid)
            {
                service.RegisterUser(user);
                return Ok(HttpStatusCode.Created);
            }
            else
            {
                return Ok(HttpStatusCode.BadRequest);
            }
        }
       //Get User By UserID
        [HttpGet("{userId}")]
        public IActionResult UserDetail(int userId)
        {

            User user = service.GetDetails(userId);

            return Ok(user);

        }
        //Add Forgot Password
        [HttpPost("forgotpassword")]
        public ActionResult ForgotPassword(UpdatePasswordModel updatePassword)
        {
            if(ModelState.IsValid)
            {
                if(service.ForgotPassword(updatePassword))
                {
                    return Ok(HttpStatusCode.OK);
                }

                return Ok(new { HttpStatusCode.NotFound });
            }

            return Ok(HttpStatusCode.BadRequest);
        }

        //Check User Exist or Not
        [HttpPost("userExist")]
        public ActionResult UserExist(long mobile)
        {
            if (!service.UserExist(mobile))
            {
                return Ok(HttpStatusCode.BadRequest);

            }
            return Ok(HttpStatusCode.OK);
        }
    }
}
