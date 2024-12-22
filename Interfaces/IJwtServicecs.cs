
using share_a_plate_backend.Models;

namespace share_a_plate_backend.Interfaces
{
    public interface IJwtServicecs
    {
        string GenerateSecurityToken(User user);
    }
}
