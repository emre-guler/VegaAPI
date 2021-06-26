using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vega.Data;
using Vega.DTO;
using Vega.Entities;
using Vega.Enums;
using Vega.Interfaces;
using Vega.Models;

namespace Vega.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly VegaContext _db;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IMailService _mailService;

        public UserController(
            VegaContext db,
            IUserService userService,
            IJwtService jwtService,
            IMailService mailService
        )
        {
            _db = db;
            _userService = userService;
            _jwtService = jwtService;
            _mailService = mailService;
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginData)
        {
            if (!string.IsNullOrEmpty(loginData.PhoneNumber) && !string.IsNullOrEmpty(loginData.Password))
            {
                User user = await _userService.Login(loginData);
                if (user is not null)
                {
                    string userJWT = _jwtService.Create(user);
                    Response.Cookies.Append("vegaJWT", userJWT, new CookieOptions {
                        HttpOnly = true
                    });
                    return Ok(userJWT);
                }
            }
            return StatusCode((int)ErrorCode.InvalidCredentials, "Invalid Credentials");
        }

        [AllowAnonymous]
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerData)
        {
            if (!string.IsNullOrEmpty(registerData.Fullname) && !string.IsNullOrEmpty(registerData.MailAddress) && !string.IsNullOrEmpty(registerData.Password) && !string.IsNullOrEmpty(registerData.PhoneNumber))
            {
                bool registerResult = await _userService.Register(registerData);
                if (registerResult)
                {
                    return Ok(true);
                }
                else 
                {
                    return StatusCode((int)ErrorCode.AlreadyExist, "This user already exist.");
                }
            }
            return StatusCode((int)ErrorCode.MustBeFilled, "All fields must be filled correctly.");
        }

        [AllowAnonymous]
        [HttpPost("/reset-password-request")]
        public async Task<IActionResult> PasswordResetRequest([FromBody] string userMailAddress)
        {
            if (!string.IsNullOrEmpty(userMailAddress))
            {
                bool resetResult = await _userService.ResetPasswordRequest(userMailAddress);
                if (resetResult)
                {
                    return Ok(true);
                }
                else
                {
                    return StatusCode((int)ErrorCode.NotFound, "User not found.");
                }
            }
            
            return StatusCode((int) ErrorCode.MustBeFilled, "All fields must be filled correctly.");
        }

        [Authorize]
        [HttpPost("/mail-verification-request")]
        public async Task<IActionResult> MailVerificationRequest()
        {
            ClaimsIdentity userClaims = HttpContext.User.Identity as ClaimsIdentity;
            JwtClaimDto userData = _jwtService.ReadToken(userClaims);
            if (userData is not null)
            {
                bool userControl = await _userService.IsVerified(userData.Id);
                if(userControl)
                {
                    await _userService.MailVerification(userData.Id);
                    return Ok(true);
                }
                else
                {
                    return StatusCode((int)ErrorCode.AlreadyVerified, "User already verified.");
                }
            }

            return StatusCode((int)ErrorCode.Unauthorized, "Unauthorized");
        }

        [Authorize]
        [HttpGet("/mail-verification/{hashedData}")]
        public async Task<IActionResult> MailVerificationPage(string hashedData)
        {
            ClaimsIdentity userClaims = HttpContext.User.Identity as ClaimsIdentity;
            JwtClaimDto userData = _jwtService.ReadToken(userClaims);
            if (userData is not null)
            {
                bool verifyPageControl = await _userService.ControlVerfiyPage(userData.Id, hashedData);
                if (verifyPageControl)
                {
                    return Ok(true);
                }
                
                return StatusCode((int)ErrorCode.LinkExpired, "Link expired");
            }

            return StatusCode((int)ErrorCode.Unauthorized, "Unauthorized");        
        }

        [Authorize]
        [HttpPost("/mail-verification{hashedData}")]
        public async Task<IActionResult> MailVerification(string hashedData, int code)
        {
            ClaimsIdentity userClaims = HttpContext.User.Identity as ClaimsIdentity;
            JwtClaimDto userData = _jwtService.ReadToken(userClaims);
            if (userData is not null)
            {
                bool verifyPageControl = await _userService.ControlVerfiyPage(userData.Id, hashedData);
                if (verifyPageControl)
                {
                    bool codeControl = await _userService.ControlVerifyCode(userData.Id, hashedData, code);
                    if (codeControl)
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return StatusCode((int)ErrorCode.InvalidCode, "Invalid code, try again");
                    }
                }
                
                return StatusCode((int)ErrorCode.LinkExpired, "Link expired");
            }

            return StatusCode((int)ErrorCode.Unauthorized, "Unauthorized");
        }
    }
}