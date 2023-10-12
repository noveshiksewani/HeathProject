using HeathProject.Models;
using HeathProject.Service.OxygenFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace HeathProject.Controllers
{
    //Get All Oxygen Details, Add Oxygen
    [Authorize(Roles = Roles.User + "," + Roles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class OxygenController : ControllerBase
    {
        public IOxygenService service;
        public OxygenController(IOxygenService service)
        {
            this.service = service;
        }
        //Get All Oxygen
        // GET: api/<OxygenController>
        [HttpGet]
        public ActionResult<IEnumerable<Oxygen>> GetAllOxygen()
        {
            try
            {
                return Ok(service.GetAllOxygen());
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        //Add Oxygen
        // POST api/<OxygenController>
        [HttpPost]
        public IActionResult DonateOxygen([FromBody]Oxygen oxygen)
        {
            try
            {
                int userId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
                return Ok(service.DonateOxygen(oxygen,userId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
