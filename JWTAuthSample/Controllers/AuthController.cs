using JWTAuthSample.DTO;
using JWTAuthSample.Repository;
using JWTAuthSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthSample.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = FakeUserRepository.GetByUsername(request.Username);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _jwtService.GenerateToken(user);

            return Ok(new
            {
                token,
                expiresIn = 3600,
                role = user.Role
            });
        }
    }

}
