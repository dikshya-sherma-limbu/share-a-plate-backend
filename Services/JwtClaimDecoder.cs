using Microsoft.EntityFrameworkCore.Query;

namespace share_a_plate_backend.Services
{
    public class JwtClaimDecoder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtClaimDecoder(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserIdFromClaims()
        {
            
            // Access the claims from HttpContext.User
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            // parse the userId into an integer
            int userId = int.Parse(userIdClaim.Value);
            
            System.Console.WriteLine("User ID: " + userId);
            if (userIdClaim == null)
            {
                throw new Exception("User ID not found in token.");
            }


            return userId;
        }
    }

}
