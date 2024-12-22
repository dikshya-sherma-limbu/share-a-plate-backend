using share_a_plate_backend.DTOs;
using share_a_plate_backend.Models;

namespace share_a_plate_backend.Interfaces
{
    public interface IUserService
    {
        // interface for user service
        Task<string> Login(LoginDto loginDto);
        Task<User> Register(User user, string password);
    
        Task<User> Logout(string email);
       
    }
}
