using share_a_plate_backend.DTOs;
using share_a_plate_backend.Models;

namespace share_a_plate_backend.Interfaces
{
    public interface IUserService
    {
        // interface for user service
        Task<string> Login(LoginDto loginDto);
       Task<User>  Register(RegisterDto registerDto);
        Task<User> Logout(string email);
       
    }
}
