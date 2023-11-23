using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpMgmtUI.Controllers
{
    [Route("api/[controller]")] // with this set this class will listen on https://localhost:5001/api/firstapi this is the default one
    [ApiController] // indicates that this class is an API controller.
    // difference between Controller class and ControllerBase class is that Controller inherits from ControllerBase and adds support for views, while ControllerBase provides only the basic functionality for handling HTTP requests.
    public class FirstApiController : ControllerBase
    {
       
        [HttpGet]
        [Route("GetValues")] // https://localhost:5001/api/firstapi/getvalue
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet()]
        [Route("GetValue/{id}")] // https://localhost:5001/api/firstapi/getvalue/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("CreateValue")] // https://localhost:5001/api/firstapi/createvalue
        public void Post([FromBody] string value)
        {
        }

        [HttpPut()]
        [Route("EditValue/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FirstApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // Try this through postman by adding the data to be sent(json) in the body section of the POST req
        // Note: run the server(F5) before sending req through postman
        // Models.LoginData is used here to validate the incoming data from postman
        [HttpPost]
        [Route("DoLogin")]
        public IActionResult DoLogin([FromBody] Models.LoginData loginData)
        {
            if (loginData.UserName == null || loginData.Password == null)
            {
                return BadRequest(new { message = "Username/password is empty" });
            }
            else
            {
                if (loginData.UserName == "user" && loginData.Password == "webapi")
                {
                    return Ok(new { message = "User login succcessfull" });
                }
                else
                    return NotFound(new { message = "Username/password not found" });
            }
        }
    }
}
