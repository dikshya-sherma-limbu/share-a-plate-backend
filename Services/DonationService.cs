using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteIndividualDonation(int donationId)
        {
            try
            {

                await _donationRepository.DeleteIndividualDonationRepo(donationId);

                
            }
            catch (DbUpdateException dbEx)
            {
                throw new InvalidOperationException($"A database error occurred while deleting donation {donationId}.", dbEx);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while deleting donation {donationId}.", ex);
            }

        }

        public async Task DeleteOrganizationDonation(int donationId)
        {
            try
            {
                await _donationRepository.DeleteOrganizationDonationRepo(donationId);

            }
            catch (DbUpdateException dbEx)
            {
                //_logger.LogError(dbEx, "Database update error while deleting donation with ID {DonationId}", donationId);
                throw new InvalidOperationException($"A database error occurred while deleting Organization donation {donationId}.", dbEx);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while deleting Organization donation {donationId}.", ex);
            }
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

        public async Task<List<IndividualDonation>> GetUsersIndividualDonation()
        {
            // fetch list of User's  specific Individual donations from the repository
            List<IndividualDonation> userIndividualDonations = await _donationRepository.GetUsersIndividualDonationsRepo();
            return userIndividualDonations;
            throw new NotImplementedException();
        }

        public async Task<List<OrganizationDonation>> GetUsersOrganizationDonation()
        {

            // fetch list of User's  specific Organization donations from the repository
            List<OrganizationDonation> userOrganizationDonations = await _donationRepository.GetUsersOrganizationDonationsRepo();
            return userOrganizationDonations;
            throw new NotImplementedException();
        }
    }
}
