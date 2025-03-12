using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
            var token = GenerateJwtToken();
            return Ok(new { token });
        }

        private string GenerateJwtToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ik15VGVzdFVzZXIiLCJzdWIiOiJNeVRlc3RVc2VyIiwianRpIjoiMmRlMTk5Y2YiLCJzY29wZSI6Im15YXBpOnNlY3JldHMiLCJhdWQiOlsiaHR0cDovL2xvY2FsaG9zdDo2MDMyNCIsImh0dHBzOi8vbG9jYWxob3N0OjQ0MzUzIiwiaHR0cDovL2xvY2FsaG9zdDo1MTYwIiwiaHR0cHM6Ly9sb2NhbGhvc3Q6NzI3NCJdLCJuYmYiOjE3NDE3OTg0NjcsImV4cCI6MTc0OTc0NzI2NywiaWF0IjoxNzQxNzk4NDY4LCJpc3MiOiJkb3RuZXQtdXNlci1qd3RzIn0.q9PxvvPfPpSI61az4plT_IYACPZ5ALL18OuhbSC_UB4"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:7274",
                audience: "https://localhost:7274",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
