using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using share_a_plate_backend.Data;
using share_a_plate_backend.Interfaces;
using share_a_plate_backend.Models;
using System.Data;
using System.Security.Claims;

namespace share_a_plate_backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        // Constructor injection for dependencies
        public UserRepository(IMapper mapper, IHttpContextAccessor httpContextAccessor,ApplicationDbContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }


        // Implement the GetUserByEmail method to get a user by email
        public Task<Boolean> GetUserByEmail(string email)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }catch (Exception e)
            {
                Console.WriteLine("Error while user checking: "+e.Message);
            }
            throw new NotImplementedException();
        }

        public async Task<User> Login(string email, string password)
        {
            try
            {
                using (var context = _context)
                {
                    var user = await context.Users
                        .AsNoTracking() // Ensures EF Core does not track entities
                        .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

                    if (user != null)
                    { 
                        return user;
                    }
                    else
                    {
                        throw new ArgumentNullException("User not found");
                    }
                }

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

        // Implement the Register method to register a new user
        public async Task<User> Register(User user)
        {
            try
            {
                using (var context = _context)
                {
                   await context.Users.AddAsync(user);
                   await context.SaveChangesAsync();

                    return user;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while registering user: " + e.Message);
            }
            throw new NotImplementedException();
        }

        
    }
}
