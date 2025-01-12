using AutoMapper;
using Microsoft.EntityFrameworkCore;
using share_a_plate_backend.Data;
using share_a_plate_backend.Interfaces;
using share_a_plate_backend.Models;
using share_a_plate_backend.Services;

namespace share_a_plate_backend.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        //ApplicationDbContext  for database operations
        private readonly ApplicationDbContext _context;
        // IMapper for mapping objects
        private readonly IMapper _mapper;

        private  JwtClaimDecoder _jwtClaimDecoder;
        private int userId;

        // Constructor injection for dependencies
        public DonationRepository(ApplicationDbContext dbContext, IMapper mapper, JwtClaimDecoder jwtClaimDecoder)
        {
            _context = dbContext;
            _mapper = mapper;
            _jwtClaimDecoder = jwtClaimDecoder;
           userId = _jwtClaimDecoder.GetUserIdFromClaims();

        }

        public async Task DeleteIndividualDonationRepo(int donationId)
        {
            var donationInfo = await _context.IndividualDonations
                                      .FirstOrDefaultAsync(d => d.DonorId == donationId);

            if (donationInfo == null)
            {
                throw new KeyNotFoundException($"No donation found with ID {donationId}");
            }

            _context.IndividualDonations.Remove(donationInfo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrganizationDonationRepo(int donationId)
        {

            var donationInfo = await _context.OrganizationDonations
                                     .FirstOrDefaultAsync(d => d.DonationId == donationId);

            if (donationInfo == null)
            {
                throw new KeyNotFoundException($"No donation found with ID {donationId}");
            }

            _context.OrganizationDonations.Remove(donationInfo);
            await _context.SaveChangesAsync();
        }



        // get the userId from the token

        public async Task<List<IndividualDonation>> GetIndividualDonationsRepo()
        {
            try
            {

                // fetch list of individual donations from the repository
                var individualDonations = await _context.IndividualDonations
                    .Where(d => d.UserId != userId)
                    .ToListAsync();
                return individualDonations;
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public async Task<List<OrganizationDonation>> GetOrganizationDonationsRepo()
        {
            try
            {
                var organizationDonations = await _context.OrganizationDonations
                    .Where(d => d.UserId != userId)
                    .ToListAsync();
                return organizationDonations;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<IndividualDonation>> GetUsersIndividualDonationsRepo()
        {
            try
            {
                
                var userIndividualDonations = await _context.IndividualDonations
                    .Where(d => d.UserId == userId)
                    .ToListAsync();
                return userIndividualDonations;
            }
            catch (Exception )
            {
                throw ;
            }
            
        }

        public async Task<List<OrganizationDonation>> GetUsersOrganizationDonationsRepo()
        {
            try
            {
                var userOrganizationDonations = await _context.OrganizationDonations
                   .Where(d => d.UserId == userId)
                   .ToListAsync();
                return userOrganizationDonations;

            }
            catch (Exception)
            {
                throw;
            }
                
        }
    }
}
