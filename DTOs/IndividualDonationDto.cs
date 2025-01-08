using System.ComponentModel.DataAnnotations;

namespace share_a_plate_backend.DTOs
{
    public class IndividualDonationDto
    {

        [Required]
        public string FoodDetails { get; set; }

        public string? FoodCategory { get; set; } // Optional: Cooked, Raw, Packaged, Drinks

        public string? FoodQuantity { get; set; } // Optional: Quantity or number of servings
        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime AvailableUntil { get; set; }

        public string? FoodPhotoPath { get; set; } // Optional: Path for uploaded food photo

        // Default constructor for the model class (required for serialization) 
        public IndividualDonationDto() { }

        // Constructor for initializing the model
        public IndividualDonationDto(
            string foodDetails,
            string? foodCategory,
            string? foodQuantity,
            string location,
            DateTime availableUntil,
            string? foodPhotoPath)
        {
            FoodDetails = foodDetails;
            FoodCategory = foodCategory;
            FoodQuantity = foodQuantity;
            Location = location;
            AvailableUntil = availableUntil;
            FoodPhotoPath = foodPhotoPath;
        }

    }
}
