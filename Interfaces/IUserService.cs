using share_a_plate_backend.Models;

namespace share_a_plate_backend.Interfaces
{
    public interface IUserService
    {
        // interface for user service
        Task<User> Login(string email, string password);
        Task<User> Register(User user, string password);
        Task<bool> UserExists(string email);
        Task<User> Logout(string email);
        Task<bool> LogoutConfirmed(
            string email);
    }
}
