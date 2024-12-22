using share_a_plate_backend.Models;

namespace share_a_plate_backend.Interfaces
{
    public interface IUserRepository
    {
        // interface for user repository
        Task<User> Login(string email, string password);
        Task<User> Register(User user, string password);
       
        Task<User> Logout(string email);

    }
}
