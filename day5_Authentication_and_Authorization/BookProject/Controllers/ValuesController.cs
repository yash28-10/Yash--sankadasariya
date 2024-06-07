using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet("admin")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAdminValue()
        {
            return Ok("This is a value for Admin only");
        }


        [HttpGet("user")]
        [Authorize(Policy = "User")]
        public IActionResult GetUserValue()
        {
            return Ok("This is a value for User only");
        }


        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAll()
        {
            return Ok("This is a value for all authenticated user");
        }
    }
}
