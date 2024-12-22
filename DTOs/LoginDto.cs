using System.ComponentModel.DataAnnotations;

namespace share_a_plate_backend.DTOs
{
    public class LoginDto
    {
       
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}
