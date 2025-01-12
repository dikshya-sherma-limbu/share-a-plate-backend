using share_a_plate_backend.DTOs;
using share_a_plate_backend.Models;

namespace share_a_plate_backend.Interfaces
{
    public interface IDonationService
    {
        // interface for donation service
        //Task<OrganizationDonation> CreateDonation(OrganizationDonationDto organizationDonationDto);
        //Task<OrganizationDonation> GetDonation(int donationId);
        //Task<OrganizationDonation> UpdateDonation(int donationId, OrganizationDonationDto organizationDonationDto);
        //Task<OrganizationDonation> DeleteDonation(int donationId);
        Task<List<OrganizationDonation>> GetOrganizationDonations();
        Task<List<IndividualDonation>> GetIndividualDonations();
        Task<List<OrganizationDonation>> GetUsersOrganizationDonation();
        Task<List<IndividualDonation>> GetUsersIndividualDonation();
        
        Task DeleteIndividualDonation(int donationId);
        Task DeleteOrganizationDonation(int donationId);



    }
}
