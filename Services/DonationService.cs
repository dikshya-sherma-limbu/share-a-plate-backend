using AutoMapper;
using share_a_plate_backend.Interfaces;
using share_a_plate_backend.Models;

namespace share_a_plate_backend.Services
{
    public class DonationService : IDonationService
    {
        private readonly IMapper _mapper;
        private readonly IDonationRepository _donationRepository;

        // Constructor
        public DonationService(IMapper mapper, IDonationRepository donationRepository)
        {
            _mapper = mapper;
            _donationRepository = donationRepository;
        }

        public async Task<List<IndividualDonation>> GetIndividualDonations()
        {
            // fetch list of donations from the repository
            List<IndividualDonation> individualDonations = await _donationRepository.GetIndividualDonationsRepo();
            return individualDonations;
            throw new NotImplementedException();
        }

        public async Task<List<OrganizationDonation>> GetOrganizationDonations()
        {
            // fetch list of donations from the repository
            List<OrganizationDonation> organizationDonations = await _donationRepository.GetOrganizationDonationsRepo();
            return organizationDonations;
            throw new NotImplementedException();
        }
    }
}
