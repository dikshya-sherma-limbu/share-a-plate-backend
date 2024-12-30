using System.ComponentModel.DataAnnotations;

namespace share_a_plate_backend.DTOs
{
    public class RegisterDto
    {
        // Data Transfer Object for Registering a User
        //firstname, lastname, email, password, location, number
        [Required]
        public string UserFirstName { get; set; }
        [Required]
        public string UserLastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public long Number { get; set; }
    }
}
