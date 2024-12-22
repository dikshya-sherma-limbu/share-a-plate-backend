using AutoMapper;
using share_a_plate_backend.Data;
using share_a_plate_backend.DTOs;
using share_a_plate_backend.Interfaces;
using share_a_plate_backend.Models;

namespace share_a_plate_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;   
        private readonly IJwtServicecs _jwtService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtServicecs jwtService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            // Validate the input DTO
            if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                throw new ArgumentNullException("Email or password is empty");
            }

            // Fetch user from the repository
            var user = await _userRepository.Login(loginDto.Email, loginDto.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            // Generate a JWT token for the user and return it as a string to the client
            var token = _jwtService.GenerateSecurityToken(user);
            return token;



        }

        public Task<User> Logout(string email)
        {
            throw new NotImplementedException();
        }

      

        public Task<User> Register(User user, string password)
        {
            throw new NotImplementedException();
        }

   
    }
}
