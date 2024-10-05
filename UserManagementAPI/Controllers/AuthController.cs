using DataEntry.Services.Services.Authentication;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Services.Models;

namespace UserManagementAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel loginUser)
        {
            var loginRres = await _authService.LoginAsync(loginUser);

            if (!loginRres.IsSuccess)
            {
                return Unauthorized();
            }

            return Ok(new { Token = loginRres.Data});
        }
    }
}
