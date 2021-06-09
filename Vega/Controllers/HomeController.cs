using Microsoft.AspNetCore.Mvc;

namespace Vega.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Main() 
        {
            return Ok("Welcome to the castle of Vega Project! Do not try anything!");
        }
    }
}