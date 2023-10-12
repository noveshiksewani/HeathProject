using HeathProject.Models;
using HeathProject.Service.QuarantinePlaces;
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
    //Get All Quarantine Place, Add Quarantine Place
   [Authorize(Roles = Roles.User + "," + Roles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class QuarantinePlaceController : ControllerBase
    {
        public IQuarantinePlaceService placeService;
        public QuarantinePlaceController(IQuarantinePlaceService placeService)
        {
            this.placeService = placeService;
        }
        // GET: api/<QuarantinePlaceController>
        [HttpGet]
        public ActionResult<IEnumerable<QuarantinePlace>> GetQuarantinePlaces()
        {
            try
            {
                return placeService.GetQuarantinePlaces();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST api/<QuarantinePlaceController>
        [HttpPost]
        public IActionResult GiveQuarantinePlace([FromBody]QuarantinePlace quarantinePlace)
        {
            try
            {
                int userId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
                return Ok(placeService.GiveQuarantinePlace(quarantinePlace,userId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
