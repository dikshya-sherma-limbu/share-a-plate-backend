using AutoMapper;
using share_a_plate_backend.DTOs;
using share_a_plate_backend.Models;

namespace share_a_plate_backend.AutoMapper
{
    public class UserAutoMapper: Profile
    {
        public UserAutoMapper()
        {
            // mapping from LoginDto to User
            CreateMap<LoginDto, User>();
            // mapping from RegisterDto to User
            CreateMap<RegisterDto, User>();

        }
    }
}
