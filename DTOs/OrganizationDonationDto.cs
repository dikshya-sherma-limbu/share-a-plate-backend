using System.ComponentModel.DataAnnotations;

namespace share_a_plate_backend.DTOs
{
    public class OrganizationDonationDto
    {

        [Required]
        public string OrganizationName { get; set; } // Name of the organization

        [Required]
        public string ContactPerson { get; set; } // Name of the contact person
        [Required]
        public string FoodDetails { get; set; } // Description of food items being donated

        public string? FoodCategory { get; set; } // Optional: Cooked, Raw, Packaged, Drinks
        [Required]
        public string EventLocation { get; set; } // Location of the donation program

        [Required]
        public DateTime EventDate { get; set; } // Date of the donation event

        //Default Contructor
        public OrganizationDonationDto() { }

        // Parameterized Constructor
        public OrganizationDonationDto(string organizationName, string contactPerson, string foodDetails, string foodCategory, string eventLocation, DateTime eventDate)
        {
            OrganizationName = organizationName;
            ContactPerson = contactPerson;
            FoodDetails = foodDetails;
            FoodCategory = foodCategory;
            EventLocation = eventLocation;
            EventDate = eventDate;
        }
    }
}
