using HeathProject.Models;
using HeathProject.Service.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeathProject.Controllers
{
    //Admin will Get All Post And Delete unwanted Post
    [Authorize(Roles =Roles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IAdminService service;
        public AdminController(IAdminService service)
        {
            this.service = service;
        }
        // GET: api/Admin 
        //GetAllPost
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAllPost()
        {
            try
            {
                return Ok(service.GetAllPost());
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        // DELETE: api/Delete/{postId}
        //Delete Unwanted Post
        [HttpDelete("{postId}")]
        public IActionResult DeletePost(int postId)
        {
            bool deleteflag = false;
            try
            {
                deleteflag = service.DeletePost(postId);
                return Ok(deleteflag);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
