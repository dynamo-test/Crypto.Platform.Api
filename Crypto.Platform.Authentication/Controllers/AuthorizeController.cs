using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Crypto.Platform.Authentication.Settings;

namespace Crypto.Platform.Authentication.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class AuthorizeController : Controller
    {
        private readonly JwtSettings _jwtSettings;
        public AuthorizeController(IConfiguration config)
        {
            this._jwtSettings = config.GetSection("Jwt").Get<JwtSettings>();
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Get()
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, this._jwtSettings.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtSettings.SecurityKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var Sectoken = new JwtSecurityToken(this._jwtSettings.Issuer, this._jwtSettings.Audience, authClaims, expires: DateTime.Now.AddMinutes(this._jwtSettings.Expires), signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }
    }
}
