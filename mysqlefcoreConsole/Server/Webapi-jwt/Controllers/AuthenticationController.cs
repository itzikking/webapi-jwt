using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mysqlefcoreConsole.Models;
using mysqlefcoreConsole.Services;

namespace Webapi_jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        // GET: api/Authentication
        [HttpGet]
        public IActionResult Get()
        {
            AuthenticationService authenticationService = new AuthenticationService();
            Result result = new Result();
            try
            {
                result = authenticationService.Get();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(result);
        }

        //// GET: api/Authentication/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Authentication
        [HttpPost]
        public IActionResult Post([FromBody] Autentication autentication)
        {
            AuthenticationService authenticationService = new AuthenticationService();
            Result result = new Result();
            try
            {
                result = authenticationService.Post(autentication);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
            return Ok(result);
        }

        //// PUT: api/Authentication/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
