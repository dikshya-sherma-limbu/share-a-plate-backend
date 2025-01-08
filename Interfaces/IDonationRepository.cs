
using share_a_plate_backend.Models;
using System.Collections;

namespace share_a_plate_backend.Interfaces
{
    public interface IDonationRepository
    {
        // interface for donation repository
        //Task<OrganizationDonation> CreateDonation(OrganizationDonation organizationDonation);

        Task<List<OrganizationDonation>> GetOrganizationDonationsRepo();
        Task<List<IndividualDonation>> GetIndividualDonationsRepo();


    }
}
