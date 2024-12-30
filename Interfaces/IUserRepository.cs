using share_a_plate_backend.Models;

namespace share_a_plate_backend.Interfaces
{
    public interface IUserRepository
    {
        // interface for user repository
        Task<User> Login(string email, string password);
       
        Task<User> Register(User user);

        Task<Boolean> GetUserByEmail(string email);
        Task<User> Logout(string email);

    }
}
