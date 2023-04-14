using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class PasajeroController : ApiController
    {


        [HttpPost]
        [Route("api/Pasajero/Add")]
        public IHttpActionResult Add([FromBody] ML.Pasajero pasajero)
        {
            ML.Result result = BL.Pasajero.Add(pasajero);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("api/Pasajero/Login/{UserName}Password={password}")]
        public IHttpActionResult Login(string UserName, string Password)
        {
            ML.Result result = BL.Pasajero.Login(UserName,Password);
            if (result.Correct)
            {
                return BadRequest("Autorice");
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
