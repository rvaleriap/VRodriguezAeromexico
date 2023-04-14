using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class VueloController : ApiController
    {
        [HttpGet]
        [Route("api/Vuelo/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Vuelo.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("api/Vuelo/VueloReservado")]
     public IHttpActionResult VueloPasajeroAdd([FromBody] ML.VueloPasajero vueloPasajero)
        {
            ML.Result result = BL.Vuelo.VueloPasajeroAdd(vueloPasajero);
            if (result.Correct)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
           
        }


    }
}
