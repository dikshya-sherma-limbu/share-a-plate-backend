using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace share_a_plate_backend.DTOs
{
    public class LoginDto
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
