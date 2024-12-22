using Microsoft.IdentityModel.Tokens;
using share_a_plate_backend.Configuration;
using share_a_plate_backend.DTOs;
using share_a_plate_backend.Interfaces;
using share_a_plate_backend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace share_a_plate_backend.Services
{
    public class JwtService : IJwtServicecs
    {
        //IConfiguration Object: allows us to access the appsettings.json file for the JWT configuration
        private readonly IConfiguration _configuration;
      
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateSecurityToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email), // store the user's email in the token
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()) // store the user's id in the token
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], // the server that created the token
                audience: _configuration["Jwt:Audience"], // the recipient of the token
                claims: claims, // the claims that the token holds
                expires: DateTime.Now.AddMinutes(30), // token expires in 30 minutes
                signingCredentials: creds // the credentials used to sign the token
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
