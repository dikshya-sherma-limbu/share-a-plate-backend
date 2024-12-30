using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace share_a_plate_backend.Models
{
    [Table("Users")]
    public class User
    {
        // Auto-incremented primary key
        [Key] // Marks UserId as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Enables auto-increment
        public int UserId { get; set; }

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
        // Navigation property for Individual Donations(One user can have many individual donations)
        public virtual ICollection<IndividualDonation> IndividualDonations { get; set; }

        // Navigation property for Organization Donations (One user can have many organization donations)
        public virtual ICollection<OrganizationDonation> OrganizationDonations { get; set; }

        //IndividualDonations = new List<IndividualDonation>();
        //OrganizationDonations = new List<OrganizationDonation>();

        public User()
        {
            // Initialize collections in constructor
            IndividualDonations = new HashSet<IndividualDonation>();
            OrganizationDonations = new HashSet<OrganizationDonation>();
        }

        

        // Constructor with parameters
        public User(string userFirstName, string userLastName, string email, string password, string location, long number) : this()
        {
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            Email = email;
            Password = password;
            Location = location;
            Number = number;

        }
        public override string ToString()
        {
            return $"UserId: {UserId}, First Name: {UserFirstName}, Email: {Email}";
        }

        public static implicit operator int(User? v)
        {
            throw new NotImplementedException();
        }
    }
}
