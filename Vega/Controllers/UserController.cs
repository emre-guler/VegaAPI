using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vega.Data;
using Vega.Entities;
using Vega.Enums;
using Vega.Interfaces;
using Vega.Models;

namespace Vega.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly VegaContext _db;
        private readonly IUserService _userService;

        public UserController(
            VegaContext db,
            IUserService userService
        )
        {
            _db = db;
            _userService = userService;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginData)
        {
            if (!string.IsNullOrEmpty(loginData.PhoneNumber) && !string.IsNullOrEmpty(loginData.Password))
            {
                User user = await _userService.LoginControl(loginData);
                if (user is not null)
                {
                    
                }
            }
            return StatusCode((int)ErrorCode.InvalidCredentials, "Invalid Credentials");
        }
    }
}