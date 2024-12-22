using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace share_a_plate_backend.Configuration
{
    public static class JwtConfiguration
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                // specify the authentication scheme to use
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // holds the parameters for the token validation process
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, // Validate the server that created that token
                    ValidateAudience = true, // Ensure that the recipient of the token is authorized to receive it
                    ValidateLifetime = true, // Check that the token is not expired and that the signing key of the issuer is valid
                    ValidateIssuerSigningKey = true, //verify the token signature is not tampered with and is valid
                    ValidIssuer = configuration["Jwt:Issuer"],      // Get from appsettings.json or environment variable
                    ValidAudience = configuration["Jwt:Audience"],  // Get from appsettings.json or environment variable
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])) // Get from appsettings.json or environment variable
                };
            });

            return services;
        }
    }
}
