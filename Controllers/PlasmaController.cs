using HeathProject.Models;
using HeathProject.Service.DonatePlasma;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace HeathProject.Controllers
{
    //Get All Plasma Details, Add Plasma Details
    [Authorize(Roles = Roles.User + "," + Roles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class PlasmaController : ControllerBase
    {
        public IPlasmaService plasmaService;
        public PlasmaController(IPlasmaService plasmaService)
        {
            this.plasmaService = plasmaService;
        }
        // GET: api/<PlasmaController>
        [HttpGet]
        public ActionResult<IEnumerable<Plasma>> Get()
        {
            return plasmaService.GetAllPlasma();
        }

        // POST api/<PlasmaController>
        [HttpPost]
        public IActionResult DonatePlasma([FromBody]Plasma plasma)
        {
            try
            {
                int userId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
                return Ok(plasmaService.DonatePlasma(plasma,userId));
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
