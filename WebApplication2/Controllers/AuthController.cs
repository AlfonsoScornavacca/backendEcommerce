using Business.Abstractions;
using Business.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication2.Controllers { 

        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly IAuthService _authService;
            public AuthController(IAuthService authService) =>
                _authService = authService;

            [HttpPost("login")]
            public async Task<IActionResult> Get([FromBody] LoginRequest request)
            {
                var token = await _authService.Login(request);
                if (token != null)
                {
                    return Ok(token);
                }

                return BadRequest("Invalid credentials.");
            }

            [Authorize]
            [HttpGet("me")]
            public async Task<IActionResult> Me()
            {
                var claimEmail = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Email");
                if (claimEmail == null)
                    return BadRequest("User not found.");

                return Ok(await _authService.Me(claimEmail.Value));
            }
        }

}
