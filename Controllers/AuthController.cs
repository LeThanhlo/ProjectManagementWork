using Container_App.Model.Users;
using Container_App.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace Container_App.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel request)
        {
            var res = await _authService.Login(request.Username, request.Password);
            if (res == null) return Unauthorized();

            return Ok(res);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string request)
        {
            var token = await _authService.RefreshToken(request);
            if (token == null) return Unauthorized();

            return Ok(token);
        }
    }
}
