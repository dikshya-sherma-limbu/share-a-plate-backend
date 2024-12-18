using AutoMapper;
using share_a_plate_backend.Data;
using share_a_plate_backend.Interfaces;
using share_a_plate_backend.Models;

namespace share_a_plate_backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        // Constructor injection for dependencies
        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<User> Login(string email, string password)
        {
            try
            {
              
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }


            throw new NotImplementedException();
        }

        public Task<User> Logout(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogoutConfirmed(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> Register(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
