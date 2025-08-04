using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IConfiguration _configuration;

        public LoginController(IRegistrationRepository registrationRepository, IConfiguration configuration)
        {
            _registrationRepository = registrationRepository;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _registrationRepository.GetByPhoneNumberAsync(request.PhoneNumber);
            if (user == null || !VerifyPassword(request.Password, user.Password))
                return Unauthorized("Invalid credentials");

            var token = GenerateJwtToken(user);
            return Ok(new { token, role = user.Role, username = user.Username });
        }

        private string GenerateJwtToken(Registration user)
        {
            var jwtKey = _configuration["Jwt:Key"] ?? "SuperSecretKeyForJwtToken12345!";
            var jwtIssuer = _configuration["Jwt:Issuer"] ?? "HospitalSystem";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("PatientID", user.PatientID.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPassword(string input, string hashed)
        {
            // For demo: use SHA256 hash, but in production use a strong hasher like ASP.NET Identity
            using var sha = SHA256.Create();
            var hash = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
            return hash == hashed;
        }
    }

    public class LoginRequest
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
